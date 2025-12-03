using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM1_DATABASE
{
    public partial class Product_Management : Form
    {
        private readonly string connectionString =
           "server=LAPTOP-5BLS6617\\SQLEXPRESS; database=StoreX_SalesDB; Integrated Security=True";
        SqlConnection conn;
        // Selected product ID; -1 means add-new mode
        private int selectedProductId = -1;
        public Product_Management()
        {
            InitializeComponent();
        }
        // HELPER: Create images folder
        // Returns the full path to the images folder (bin/Debug/images)
        private string EnsureImagesFolder()
        {
            string imagesFolder = Path.Combine(Application.StartupPath, "images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }
            return imagesFolder;
        }
        // LOAD FORM: load categories, suppliers, products
        private void Product_Management_Load(object sender, EventArgs e)
        {
            // Load data for controls
            LoadCategories();
            LoadSuppliers();
            LoadProducts(); // load into dgvProduct including image column (thumbnail)
            // Reset form (clear input)
            ResetForm();
            // Apply UI permissions if using UserSession (if not present, ignore)
            try
            {
                if (UserSession.AuthorityLevel == 3) // Warehouse staff
                {
                    // Warehouse staff may only update inventory, cannot delete
                    btnDelete.Enabled = false;
                }
                else if (UserSession.AuthorityLevel == 2) // Salesperson
                {
                    // Sales may view/add/edit depending on policy; not blocked here
                }
            }
            catch
            {
                // No UserSession -> continue normally
            }
            LoadCategories();
            LoadSuppliers();
            LoadProducts();
            ResetForm();
            try
            {
                if (UserSession.AuthorityLevel == 3)
                    btnDelete.Enabled = false;
            }
            catch { }
        }
        private void LoadCategories()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT CategoryID, CategoryName FROM Category ORDER BY CategoryName";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbCategory_Product.DataSource = dt;
                cbCategory_Product.DisplayMember = "CategoryName";
                cbCategory_Product.ValueMember = "CategoryID";
                cbCategory_Product.SelectedIndex = -1;
            }
        }
        // Load suppliers into cbSupplier_Product
        private void LoadSuppliers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT SupplierID, SupplierName FROM Supplier ORDER BY SupplierName";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbSupplier_Product.DataSource = dt;
                cbSupplier_Product.DisplayMember = "SupplierName";
                cbSupplier_Product.ValueMember = "SupplierID";
                cbSupplier_Product.SelectedIndex = -1;
            }
        }
        // Load products into dgvProduct
        // - Add ProductImage column of type Image to display thumbnail
        // - Hide the original ImagePath column
        private void LoadProducts(string searchKeyword = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Also retrieve ImagePath to map to image
                string sql = @"
                    SELECT P.ProductID, P.ProductName, P.SellingPrice, P.InventoryQuantity,
                           C.CategoryName, S.SupplierName, P.ImagePath
                    FROM Product P
                    JOIN Category C ON P.CategoryID = C.CategoryID
                    JOIN Supplier S ON P.SupplierID = S.SupplierID
                    WHERE (@search = '' OR P.ProductName LIKE '%' + @search + '%' 
                           OR C.CategoryName LIKE '%' + @search + '%' OR S.SupplierName LIKE '%' + @search + '%')
                    ORDER BY P.ProductID DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@search", searchKeyword ?? "");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                // Add ProductImage column of type Image for binding images (thumbnail)
                if (!dt.Columns.Contains("ProductImage"))
                    dt.Columns.Add("ProductImage", typeof(Image));
                //// Map ImagePath -> load Image object (if exists)
                foreach (DataRow row in dt.Rows)
                {
                    object imgObj = row["ImagePath"];
                    if (imgObj != null && imgObj != DBNull.Value)
                    {
                        string imgPath = imgObj.ToString(); // e.g. "images/xxx.jpg" or full path
                        // Create full path: prefer app folder (relative)
                        string candidate1 = Path.Combine(Application.StartupPath, imgPath.TrimStart('/', '\\'));
                        string candidate2 = imgPath; // original (if saved as full path)
                        if (File.Exists(candidate1))
                        {  try
                            {
                                // Load image (note: Image.FromFile will lock the file, acceptable for display)
                                row["ProductImage"] = System.Drawing.Image.FromFile(candidate1);
                            }
                            catch
                            {
                                row["ProductImage"] = null;
                            }
                        }
                        else if (File.Exists(candidate2))
                        {
                            try
                            {
                                row["ProductImage"] = System.Drawing.Image.FromFile(candidate2);
                            }
                            catch
                            {
                                row["ProductImage"] = null;
                            }
                        }
                        else
                        {
                            // If not found, leave null (could set default image)
                            row["ProductImage"] = null;
                        }
                    }
                    else
                    {
                        row["ProductImage"] = null;
                    }
                }
                // Assign DataTable to DataGridView
                dgvProduct.DataSource = dt;

                // Configure image column display (if present)
                if (dgvProduct.Columns.Contains("ProductImage"))
                {
                    var col = dgvProduct.Columns["ProductImage"] as DataGridViewImageColumn;
                    if (col == null)
                    {
                        // If DataGridView created object column, convert to ImageColumn
                        dgvProduct.Columns.Remove("ProductImage");
                        DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                        imgCol.Name = "ProductImage";
                        imgCol.HeaderText = "Ảnh";
                        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        dgvProduct.Columns.Insert(0, imgCol); // insert image column as first column
                        // then set value for each row
                        foreach (DataGridViewRow row in dgvProduct.Rows)
                        {
                            DataRowView drv = row.DataBoundItem as DataRowView;
                            if (drv != null)
                                row.Cells["ProductImage"].Value = drv["ProductImage"];
                        }
                    }
                    else
                    {
                        col.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    }
                }
                // Hide ImagePath column if desired (to avoid showing raw path)
                if (dgvProduct.Columns.Contains("ImagePath"))
                    dgvProduct.Columns["ImagePath"].Visible = false;
                // Auto size
                dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        // Reset UI inputs to defaults (used for Add new)
        private void ResetForm()
        {
            selectedProductId = -1;
            txtName_Product_Management.Clear();
            txtPrice_Product.Clear();
           // txtImagePath_Product.Text = "";
            cbCategory_Product.SelectedIndex = -1;
            cbSupplier_Product.SelectedIndex = -1;
            // Disable edit/delete until a row is selected
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd_Product.Enabled = true;
        }
        private void Product_Name_Click(object sender, EventArgs e) {  }
        private void Search_Product_Click(object sender, EventArgs e) { }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductId == -1)
            {
                MessageBox.Show("Please select a product to delete.", "Notification", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Check in Order_Details
                string checkSql = "SELECT COUNT(*) FROM Order_Details WHERE ProductID=@pid";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@pid", selectedProductId);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Product exists in orders, cannot delete.", "Cannot delete",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to delete the product?", "Confirm", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                string delSql = "DELETE FROM Product WHERE ProductID=@id";
                SqlCommand delCmd = new SqlCommand(delSql, conn);
                delCmd.Parameters.AddWithValue("@id", selectedProductId);
                int rows = delCmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Product deleted successfully.", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed to delete product.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadProducts();
            ResetForm();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCategories();
            LoadSuppliers();
            LoadProducts();
            ResetForm();
        }
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
                selectedProductId = Convert.ToInt32(row.Cells["ProductID"].Value);
                txtName_Product_Management.Text = row.Cells["ProductName"].Value.ToString();
                txtPrice_Product.Text = row.Cells["SellingPrice"].Value.ToString();
                cbCategory_Product.Text = row.Cells["CategoryName"].Value.ToString();
                cbSupplier_Product.Text = row.Cells["SupplierName"].Value.ToString();
                // Enable edit/delete buttons
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd_Product.Enabled = false;
            }
        }
        private void btnAdd_Product_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName_Product_Management.Text))
            {
                MessageBox.Show("Product name cannot be empty!", "Error"); return;
            }
            if (!decimal.TryParse(txtPrice_Product.Text, out decimal price))
            {
                MessageBox.Show("Invalid price!", "Error"); return;
            }
            if (!int.TryParse(txtQuantity_Product.Text, out int qty))
            {
                MessageBox.Show("Invalid quantity!", "Error");   return;
            }
            if (cbCategory_Product.SelectedValue == null || cbSupplier_Product.SelectedValue == null)
            {
                MessageBox.Show("Please select category and supplier!", "Error");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
            INSERT INTO Product (ProductName, SellingPrice, InventoryQuantity, CategoryID, SupplierID, ImagePath)
            VALUES (@n, @p, @q, @c, @s, @img)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@n", txtName_Product_Management.Text);
                cmd.Parameters.AddWithValue("@p", price);
                cmd.Parameters.AddWithValue("@q", qty);
                cmd.Parameters.AddWithValue("@c", cbCategory_Product.SelectedValue);
                cmd.Parameters.AddWithValue("@s", cbSupplier_Product.SelectedValue);
                // If you don't have an image path, insert NULL into ImagePath:
                cmd.Parameters.AddWithValue("@img", DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Product added successfully!");
            LoadProducts();
            ResetForm();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedProductId == -1)
            {
                MessageBox.Show("Please select a product to edit!", "Notification");
                return;
            }
            txtName_Product_Management.Enabled = true;
            txtPrice_Product.Enabled = true;
            txtQuantity_Product.Enabled = true;
            cbCategory_Product.Enabled = true;
            cbSupplier_Product.Enabled = true;
            btnSave_Product.Enabled = true;
            MessageBox.Show("You are editing the product. Press Save to update.", "Notification");
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) { }
        private void txtName_Product_Management_TextChanged(object sender, EventArgs e) {  }
        private void txtPrice_Product_TextChanged(object sender, EventArgs e) { }
        private void cbCategory_Product_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbSupplier_Product_SelectedIndexChanged(object sender, EventArgs e) {  }
        private void txtQuantity_Product_TextChanged(object sender, EventArgs e) { }
        private void btnSave_Product_Click(object sender, EventArgs e)
        {
            if (selectedProductId == -1)
            {
                MessageBox.Show("No product selected to update.", "Error");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName_Product_Management.Text))
            {
                MessageBox.Show("Product name cannot be empty!", "Error");
                return;
            }
            decimal price;
            int qty;
            if (!decimal.TryParse(txtPrice_Product.Text, out price))
            {
                MessageBox.Show("Invalid price!", "Error");
                return;
            }
            if (!int.TryParse(txtQuantity_Product.Text, out qty))
            {
                MessageBox.Show("Invalid quantity!", "Error");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
            UPDATE Product 
            SET ProductName=@n, SellingPrice=@p, InventoryQuantity=@q,
                CategoryID=@c, SupplierID=@s,
                ImagePath = CASE WHEN @img IS NULL THEN ImagePath ELSE @img END
            WHERE ProductID=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@n", txtName_Product_Management.Text);
                cmd.Parameters.AddWithValue("@p", price);
                cmd.Parameters.AddWithValue("@q", qty);
                cmd.Parameters.AddWithValue("@c", cbCategory_Product.SelectedValue);
                cmd.Parameters.AddWithValue("@s", cbSupplier_Product.SelectedValue);
                cmd.Parameters.AddWithValue("@id", selectedProductId);
                cmd.Parameters.AddWithValue("@img", DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Update successful!");
            LoadProducts();
            ResetForm();
        }
    }
}

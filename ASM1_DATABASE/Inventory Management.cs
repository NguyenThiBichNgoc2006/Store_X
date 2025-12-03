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
    public partial class Inventory_Management : Form
    {
        private string connectionString =
            "server = LAPTOP-5BLS6617\\SQLEXPRESS; database = StoreX_SalesDB; Integrated Security=True";
        SqlConnection conn;
        private int selectedProductID = -1;
        // Temporary log table
        private DataTable inventoryLog = new DataTable();
        public Inventory_Management()
        {
            InitializeComponent();
            // Create temporary log columns
            inventoryLog.Columns.Add("ProductID");
            inventoryLog.Columns.Add("ProductName");
            inventoryLog.Columns.Add("OldQty");
            inventoryLog.Columns.Add("NewQty");
            inventoryLog.Columns.Add("ChangeQty");
            inventoryLog.Columns.Add("Time");

        }
        private void Inventory_Management_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            LoadInventory();
            dgvLog_Inventory.DataSource = inventoryLog; // bind temporary log
        }
        private void LoadSuppliers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT SupplierID, SupplierName FROM Supplier", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbSupplier_Inventory.DataSource = dt;
                cbSupplier_Inventory.DisplayMember = "SupplierName";
                cbSupplier_Inventory.ValueMember = "SupplierID";
                cbSupplier_Inventory.SelectedIndex = -1; // nothing selected
            }
        }
        private void LoadInventory(string filter = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT 
                        P.ProductID,
                        P.ProductName,
                        P.InventoryQuantity,
                        C.CategoryName,
                        S.SupplierName,
                        P.SellingPrice
                    FROM Product P
                    JOIN Category C ON P.CategoryID = C.CategoryID
                    JOIN Supplier S ON P.SupplierID = S.SupplierID " + filter;

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvInventory.DataSource = dt;
            }
        }
        private void Log_Inventory_Click(object sender, EventArgs e) { }
        private void btnExport_Report_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "CSV file (*.csv)|*.csv";
            save.FileName = "Inventory_Report.csv";
            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(save.FileName))
                {
                    // Header
                    for (int i = 0; i < dgvInventory.Columns.Count; i++)
                    {
                        sw.Write(dgvInventory.Columns[i].HeaderText + ",");
                    }
                    sw.WriteLine();
                    // Rows
                    foreach (DataGridViewRow row in dgvInventory.Rows)
                    {
                        for (int i = 0; i < dgvInventory.Columns.Count; i++)
                            sw.Write(row.Cells[i].Value + ",");
                        sw.WriteLine();
                    }
                }
                MessageBox.Show("Report exported successfully!", "Information");
            }
        }
        private void btnLow_Stock_Alert_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT ProductName, " +
                    "InventoryQuantity FROM Product WHERE InventoryQuantity < 10", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvInventory.DataSource = dt;
                MessageBox.Show($"There are {dt.Rows.Count} products with stock < 10!", "Warning");
            }
        }
        private void txtUpdate_Qty_TextChanged(object sender, EventArgs e){ }
        private void cbFilter_Invertory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = cb_Filter_Invertory.SelectedItem?.ToString();
            if (option == "Low Stock")
                LoadInventory("WHERE P.InventoryQuantity < 10");
            else if (option == "Out of Stock")
                LoadInventory("WHERE P.InventoryQuantity = 0");
            else
                LoadInventory();
        }
        private string GetProductName(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ProductName FROM Product WHERE ProductID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteScalar()?.ToString();
            }
        }
        private int GetOldQty(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT InventoryQuantity FROM Product WHERE ProductID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        private void cbSupplier_Inventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSupplier_Inventory.SelectedIndex == -1)
            {
                LoadInventory();
                return;
            }
            int supID = Convert.ToInt32(cbSupplier_Inventory.SelectedValue);
            LoadInventory($"WHERE P.SupplierID = {supID}");
        }
        private void dgvLog_Inventory_CellContentClick(object sender, DataGridViewCellEventArgs e) {}
        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedProductID = Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells["ProductID"].Value);
                txtUpdate_Qty.Text = dgvInventory.Rows[e.RowIndex].Cells["InventoryQuantity"].Value.ToString();
            }
        }
    }
}

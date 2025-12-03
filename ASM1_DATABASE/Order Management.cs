using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;    // SQL Server connection
using System.Drawing;
using iTextSharp.text;              // PDF export library
using iTextSharp.text.pdf;          // PDF export library
using System.IO;                    // File handling
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ASM1_DATABASE
{
    public partial class Order_Management : Form
    {
        private const string connectionString = 
            "server = LAPTOP-5BLS6617\\SQLEXPRESS; database = StoreX_SalesDB; Integrated Security=True";
        SqlConnection conn;
        // Table storing temporary order items
        private DataTable orderItems = new DataTable();
        // Total amount
        private decimal totalOrder = 0;
        // Most recently saved Order ID
        private int lastSavedOrderId = 0;
        // May store last saved Customer/Employee/PaymentMethod names after saving
        private string lastSavedCustomerName;
        public Order_Management()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            // Add a handler so leaving the quantity textbox will attempt to add the item
            // (alternative to pressing Enter)
            this.txtQuantity_Order.Leave += TxtQuantity_Order_Leave;
        }
        private void Order_Management_Load(object sender, EventArgs e)
        {
            InitializeOrderItemsTable();
            LoadCustomers();
            LoadPaymentMethods();
            LoadProducts();
            LoadEmployees();
            // Ensure form opens in a clean "new order" state
            orderItems.Clear();
            RecalculateTotal();
            // Reset any persisted state so textboxes / combos are empty
            lastSavedOrderId = 0;
            ClearInputFields();
            // Default UI state
            dtpOrderDate.Value = DateTime.Now;
            txtTotal_Order.Text = "0";
            btnPrintInvoice_Order.Enabled = false;
            btnSave_Order.Enabled = true;
            ApplyRolePermission();   // Apply Admin / Sales permissions
        }
        private void ApplyRolePermission()
        {
            // 1 = Admin | 2 = Salesperson
            if (UserSession.AuthorityLevel == 2)
            {
                // Sales can only create sales → cannot delete orders
                btnDelete_Order.Enabled = false;
                // Sales should not reprint past invoices
                // btnPrintInvoice_Order.Enabled = false;
                // Only disable Print if there is no saved order (creating a new order)
                if (lastSavedOrderId == 0)
                {
                    btnPrintInvoice_Order.Enabled = false;
                }
                MessageBox.Show("You are signed in as Sales. Some features are restricted.");
            }
        }
        private void InitializeOrderItemsTable()
        {
            orderItems.Columns.Add("ProductID", typeof(int));
            orderItems.Columns.Add("ProductName", typeof(string));
            orderItems.Columns.Add("UnitPrice", typeof(decimal));
            orderItems.Columns.Add("Quantity", typeof(int));
            orderItems.Columns.Add("LineTotal", typeof(decimal));

            dgvOrderItems.DataSource = orderItems;
            dgvOrderItems.Columns["ProductID"].Visible = false;
            dgvOrderItems.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
            dgvOrderItems.Columns["LineTotal"].DefaultCellStyle.Format = "N0";
        }
        private void LoadCustomers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT CustomerID, CustomerName FROM Customer ORDER BY CustomerName", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cbCustomer_Order.DataSource = dt;
                cbCustomer_Order.DisplayMember = "CustomerName";
                cbCustomer_Order.ValueMember = "CustomerID";
            }
        }

        private void LoadPaymentMethods()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT PaymentMethodID, MethodName FROM PaymentMethod ORDER BY MethodName", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cbPayment_Order.DataSource = dt;
                cbPayment_Order.DisplayMember = "MethodName";
                cbPayment_Order.ValueMember = "PaymentMethodID";
            }
        }
        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT ProductID, ProductName, SellingPrice, InventoryQuantity FROM Product ORDER BY ProductName", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbProduct_Order.DataSource = dt;
                cbProduct_Order.DisplayMember = "ProductName";
                cbProduct_Order.ValueMember = "ProductID";
            }
        }
        private void Position_Click(object sender, EventArgs e) { }
        private void btnPrintInvoice_Order_Click(object sender, EventArgs e)
        {
            if (lastSavedOrderId == 0)
            {
                MessageBox.Show("Please save the order before printing.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lastSavedOrderId == 0)
            {
                MessageBox.Show("No recent order to print. Please save the order before printing.", 
                    "Print Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int orderId = lastSavedOrderId;
            try
            {
                // Load order header and details
                DataRow header = null;
                DataTable details = new DataTable();
                using (SqlConnection c = new SqlConnection(connectionString))
                {
                    c.Open();
                    string sqlHeader = @"
                        SELECT o.OrderID, o.OrderDate, o.TotalAmount, c.CustomerName, e.EmployeeName, pm.MethodName
                        FROM [Order] o
                        LEFT JOIN Customer c ON o.CustomerID = c.CustomerID
                        LEFT JOIN Employee e ON o.EmployeeID = e.EmployeeID
                        LEFT JOIN PaymentMethod pm ON o.PaymentMethodID = pm.PaymentMethodID
                        WHERE o.OrderID = @id";
                    using (SqlCommand cmd = new SqlCommand(sqlHeader, c))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("Order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            header = dt.Rows[0];
                        }
                    }
                    string sqlDetails = @"
                        SELECT od.ProductID, p.ProductName, od.Quantity, od.UnitPrice
                        FROM Order_Details od
                        JOIN Product p ON od.ProductID = p.ProductID
                        WHERE od.OrderID = @id";
                    using (SqlCommand cmd = new SqlCommand(sqlDetails, c))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(details);
                        }
                    }
                }

                // Build PDF invoice using iTextSharp
                string fileName = $"Invoice_{orderId}.pdf";
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
                using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 36, 36, 36, 36);
                    iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs);
                    doc.Open();
                    var titleFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 16);
                    var labelFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 10);
                    var boldFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 10);
                    // Header
                    doc.Add(new iTextSharp.text.Paragraph("StoreX - Sales Invoice", titleFont));
                    doc.Add(new iTextSharp.text.Paragraph(" "));
                    doc.Add(new iTextSharp.text.Paragraph($"Invoice ID: {header["OrderID"]}", boldFont));
                    doc.Add(new iTextSharp.text.Paragraph($"Date: {Convert.ToDateTime(header["OrderDate"]).ToString("yyyy-MM-dd HH:mm")}", labelFont));
                    doc.Add(new iTextSharp.text.Paragraph($"Customer: {header["CustomerName"]}", labelFont));
                    doc.Add(new iTextSharp.text.Paragraph($"Employee: {header["EmployeeName"]}", labelFont));
                    doc.Add(new iTextSharp.text.Paragraph($"Payment Method: {header["MethodName"]}", labelFont));
                    doc.Add(new iTextSharp.text.Paragraph(" "));

                    // Items table
                    iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(new float[] { 6f, 40f, 18f, 12f, 20f });
                    table.WidthPercentage = 100;
                    table.SpacingBefore = 6f;

                    // Table header
                    void AddCell(string text, iTextSharp.text.Font f = null, int align = iTextSharp.text.Element.ALIGN_LEFT)
                    {
                        var cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(text, f ?? labelFont));
                        cell.HorizontalAlignment = align;
                        cell.Padding = 4f;
                        table.AddCell(cell);
                    }

                    AddCell("No.", boldFont, iTextSharp.text.Element.ALIGN_CENTER);
                    AddCell("Product Name", boldFont);
                    AddCell("Unit Price", boldFont, iTextSharp.text.Element.ALIGN_RIGHT);
                    AddCell("Qty", boldFont, iTextSharp.text.Element.ALIGN_CENTER);
                    AddCell("Line Total", boldFont, iTextSharp.text.Element.ALIGN_RIGHT);
                    int idx = 1;
                    decimal calcTotal = 0m;
                    foreach (DataRow r in details.Rows)
                    {
                        decimal unit = Convert.ToDecimal(r["UnitPrice"]);
                        int qty = Convert.ToInt32(r["Quantity"]);
                        decimal line = unit * qty;
                        calcTotal += line;
                        AddCell(idx.ToString(), labelFont, iTextSharp.text.Element.ALIGN_CENTER);
                        AddCell(r["ProductName"].ToString(), labelFont);
                        AddCell(unit.ToString("N0"), labelFont, iTextSharp.text.Element.ALIGN_RIGHT);
                        AddCell(qty.ToString(), labelFont, iTextSharp.text.Element.ALIGN_CENTER);
                        AddCell(line.ToString("N0"), labelFont, iTextSharp.text.Element.ALIGN_RIGHT);
                        idx++;
                    }
                    // Add table and total
                    doc.Add(table);
                    doc.Add(new iTextSharp.text.Paragraph(" "));
                    doc.Add(new iTextSharp.text.Paragraph($"Grand Total: {calcTotal.ToString("N0")}", boldFont));
                    // Optionally show TotalAmount from header to be consistent with DB
                    doc.Add(new iTextSharp.text.Paragraph($"Total in DB: {Convert.ToDecimal(header["TotalAmount"]).ToString("N0")}", labelFont));
                    doc.Close();
                }

                // Open the generated PDF
                try
                {
                    System.Diagnostics.Process.Start(filePath);
                }
                catch
                {
                    MessageBox.Show($"Invoice saved at: {filePath}", "Print Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbCustomer_Order_SelectedIndexChanged(object sender, EventArgs e) {}
        private void cbPayment_Order_SelectedIndexChanged(object sender, EventArgs e){  }
        private void txtTotal_Order_TextChanged(object sender, EventArgs e) {        }
        private void txtSearch_Order_TextChanged(object sender, EventArgs e) {  }
        private void btnSave_Order_Click(object sender, EventArgs e)
        { 
            if (orderItems.Rows.Count == 0 && cbProduct_Order.SelectedItem is DataRowView)
            {
                MessageBox.Show("Missing information.");
                return;
            }
            int customerId = Convert.ToInt32(cbCustomer_Order.SelectedValue);
            int paymentId = Convert.ToInt32(cbPayment_Order.SelectedValue);
            DateTime date = dtpOrderDate.Value;
            int employeeId = UserSession.EmployeeID;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    // INSERT order
                    string sqlOrder =
                        @"INSERT INTO [Order] (OrderDate, TotalAmount, CustomerID, EmployeeID, PaymentMethodID)
                          OUTPUT INSERTED.OrderID
                          VALUES (@d,@t,@c,@p,@e)";

                    SqlCommand cmdO = new SqlCommand(sqlOrder, conn, tran);
                    cmdO.Parameters.AddWithValue("@d", date);
                    cmdO.Parameters.AddWithValue("@t", totalOrder);
                    cmdO.Parameters.AddWithValue("@c", customerId);
                    cmdO.Parameters.AddWithValue("@p", paymentId);
                    cmdO.Parameters.AddWithValue("@e", employeeId); 
                    int orderId = (int)cmdO.ExecuteScalar();
                    lastSavedOrderId = orderId;
                    //// INSERT order detail + update stock
                    foreach (DataRow r in orderItems.Rows)
                    {
                        int pid = (int)r["ProductID"];
                        int qty = (int)r["Quantity"];
                        decimal price = (decimal)r["UnitPrice"];
                        string sqlD =
                            @"INSERT INTO Order_Details (OrderID,ProductID,Quantity,UnitPrice)
                              VALUES (@o,@p,@q,@u)";
                        SqlCommand cmdD = new SqlCommand(sqlD, conn, tran);
                        cmdD.Parameters.AddWithValue("@o", orderId);
                        cmdD.Parameters.AddWithValue("@p", pid);
                        cmdD.Parameters.AddWithValue("@q", qty);
                        cmdD.Parameters.AddWithValue("@u", price);
                        cmdD.ExecuteNonQuery();
                        string sqlStock =
                            @"UPDATE Product SET InventoryQuantity = InventoryQuantity - @q WHERE ProductID=@p";
                        SqlCommand cmdS = new SqlCommand(sqlStock, conn, tran);
                        cmdS.Parameters.AddWithValue("@q", qty);
                        cmdS.Parameters.AddWithValue("@p", pid);
                        cmdS.ExecuteNonQuery();
                    }
                    tran.Commit();
                    MessageBox.Show("Order saved successfully.");
                    txtPrice_Order.Clear();
                    txtQuantity_Order.Text = "0";
                    txtSearch_Order.Clear();
                    btnSave_Order.Enabled = false; // Disable Save button (already saved)
                    btnPrintInvoice_Order.Enabled = true; // Enable Print button
                    // Optionally append a saved note to the total
                    txtTotal_Order.Text = totalOrder.ToString("N0") + " (Saved)";
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error saving order: " + ex.Message);
                }
            }
        }
        private void OrderDate_Click(object sender, EventArgs e) { }
        private void Items_Order_Click(object sender, EventArgs e) { }
        private void Product_Order_Click(object sender, EventArgs e) { }
        private void txtPrice_Order_TextChanged(object sender, EventArgs e) { }
        // Reset Form state to 'Ready for new order'
        private void StartNewOrder()
        {
            // Only perform reset if currently showing a saved order
            if (lastSavedOrderId != 0)
            {
                // Reset the saved order ID
                lastSavedOrderId = 0;
                // Clear old order data (to start a new cart)
                orderItems.Clear();
                RecalculateTotal();
                // Reset fields to defaults (Customer/Payment/Date)
                ClearInputFields();
                // Update button states
                btnPrintInvoice_Order.Enabled = false; // Disable Print
                btnSave_Order.Enabled = true;          // Enable Save
                // Ensure Total displays correctly (RecalculateTotal already did)
            }
        }
        private void cbProduct_Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartNewOrder();
            // When user selects a product show its price and a preview grand total
            if (cbProduct_Order.SelectedItem is DataRowView drv)
            {
                decimal price = Convert.ToDecimal(drv["SellingPrice"]);
                txtPrice_Order.Text = price.ToString("N0");

                int qty = 1;
                if (!int.TryParse(txtQuantity_Order.Text, out qty) || qty <= 0) qty = 1;

                // preview = existing order total + this line's total (price * qty)
                decimal previewTotal = totalOrder + price * qty;
                txtTotal_Order.Text = previewTotal.ToString("N0");
            }
            else
            {
                // no product selected → show current order total
                txtPrice_Order.Clear();
                txtTotal_Order.Text = totalOrder.ToString("N0");
            }
        }
        private void dgvOrderItems_CellClick(object sender, DataGridViewCellEventArgs e){ }
        private void btnDelete_Order_Click(object sender, EventArgs e)
        {
            // If user deletes an item after saving, treat as starting a new order / cancelling the old one.
            if (lastSavedOrderId != 0)
            {
                // If deleting an item from a saved order → start new order to clear the old cart and begin new
                StartNewOrder();
            }
            if (dgvOrderItems.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            int index = dgvOrderItems.CurrentRow.Index;
            decimal remove = Convert.ToDecimal(orderItems.Rows[index]["LineTotal"]);
            orderItems.Rows.RemoveAt(index);
            totalOrder -= remove;
            txtTotal_Order.Text = totalOrder.ToString("N0");
        }
        private void txtQuantity_Order_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StartNewOrder();
                AddItemToOrder();
                e.SuppressKeyPress = true;   // Prevent system "ding"
            }
        }
        private void AddItemToOrder()
        {
            if (cbProduct_Order.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a product.");
                return;
            }
            if (!int.TryParse(txtQuantity_Order.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Quantity must be a positive integer.");
                return;
            }
            var drv = cbProduct_Order.SelectedItem as DataRowView;
            int productId = Convert.ToInt32(drv["ProductID"]);
            string name = drv["ProductName"].ToString();
            decimal price = Convert.ToDecimal(drv["SellingPrice"]);
            int stock = Convert.ToInt32(drv["InventoryQuantity"]);
            // check inventory
            int exist = 0;
            foreach (DataRow r in orderItems.Rows)
            {
                if ((int)r["ProductID"] == productId) exist += (int)r["Quantity"];
            }
            if (exist + qty > stock)
            {
                MessageBox.Show("Insufficient stock.");
                return;
            }
            // if this product already exists → increase qty
            DataRow existed = orderItems.AsEnumerable()
                .FirstOrDefault(r => r.Field<int>("ProductID") == productId);
            if (existed != null)
            {
                int newQty = existed.Field<int>("Quantity") + qty;
                existed["Quantity"] = newQty;
                existed["LineTotal"] = newQty * price;
            }
            else
            {
                orderItems.Rows.Add(productId, name, price, qty, price * qty);
            }

            RecalculateTotal();
            txtQuantity_Order.Text = "0";
        }
        private void RecalculateTotal()
        {
            totalOrder = orderItems.AsEnumerable()
                .Sum(r => r.Field<decimal>("LineTotal"));
            txtTotal_Order.Text = totalOrder.ToString("N0");
        }
        private void txtPrice_Order_TextChanged_1(object sender, EventArgs e) { }
        // Add this event handler method to fix CS0103
        private void TxtQuantity_Order_Leave(object sender, EventArgs e)
        {
            StartNewOrder();
            AddItemToOrder();
        }
        // Clear inputs after saving an order
        private void ClearInputFields()
        {
            try
            {
                cbProduct_Order.SelectedIndex = -1;
            }
            catch { /* ignore if data-bound combo doesn't accept -1 */ }
            try
            {
                cbCustomer_Order.SelectedIndex = -1;
            }
            catch { }
            try
            {
                cbPayment_Order.SelectedIndex = -1;
            }
            catch { }
            txtPrice_Order.Clear();
            txtQuantity_Order.Text = "0";
            txtSearch_Order.Clear();
            // show current total (RecalculateTotal already set it)
            txtTotal_Order.Text = totalOrder.ToString("N0");
            // reset order date to now (optional)
            dtpOrderDate.Value = DateTime.Now;
        }
        private void Employee_Order_Click(object sender, EventArgs e) { }
        private void cbImployeeID_SelectedIndexChanged(object sender, EventArgs e) { }
        private void LoadEmployees()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT EmployeeID, EmployeeName FROM Employee ORDER BY EmployeeName", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                // Assign data to ComboBox cbImployeeID
                cbImployeeID.DataSource = dt;
                cbImployeeID.DisplayMember = "EmployeeName"; // Display name
                cbImployeeID.ValueMember = "EmployeeID";     // Use ID when selected
            }
        }
        private void btnRefresh_Order_Click(object sender, EventArgs e)
        {
            // Reload lookup data
            LoadCustomers();
            LoadPaymentMethods();
            LoadProducts();
            // Clear current in-memory order items and totals
            orderItems.Clear();
            RecalculateTotal();
            // Reset input fields and order date
            ClearInputFields();
            dtpOrderDate.Value = DateTime.Now;
            // Reset last saved order id and re-apply role permissions
            lastSavedOrderId = 0;
            try { ApplyRolePermission(); } catch { }
            lastSavedOrderId = 0; // Reset
            StartNewOrder(); // Clear items, reset input
            // Optional brief feedback
            MessageBox.Show("Order data has been refreshed.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtQuantity_Order_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ASM1_DATABASE
{
    public partial class Customer_Management : Form
    {
        private const string connectionString = "server = LAPTOP-5BLS6617\\SQLEXPRESS;" +
            " database = StoreX_SalesDB; Integrated Security=True";
        SqlConnection conn;
        private int selectedCustomerId = -1;
        public Customer_Management()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }
        private void LoadCustomerData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT CustomerID, CustomerName, Phone, Address, Email, RegistrationDate
                    FROM Customer
                    ORDER BY RegistrationDate DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomer.DataSource = dt;
            }
        }
        private void Customer_Management_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
        }
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];
                selectedCustomerId = Convert.ToInt32(row.Cells["CustomerID"].Value);
                txtName_Customer.Text = row.Cells["CustomerName"].Value.ToString();
                txtPhone_Customer.Text = row.Cells["Phone"].Value.ToString();
                txtAddress_Customer.Text = row.Cells["Address"].Value.ToString();
                txtEmail_Customer.Text = row.Cells["Email"].Value.ToString();
                // Format date

                txtReg_Date_Customer.Text =
                    Convert.ToDateTime(row.Cells["RegistrationDate"].Value).ToString("dd/MM/yyyy");
            }
        }
                 
                      
        private bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email,
                   @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        private bool IsPhoneValid(string phone)
        {
            return Regex.IsMatch(phone, @"^[0-9]{9,12}$");
        }
        private void btnSave_Customer_Click(object sender, EventArgs e)
        {
            string name = txtName_Customer.Text.Trim();
            string phone = txtPhone_Customer.Text.Trim();
            string address = txtAddress_Customer.Text.Trim();
            string email = txtEmail_Customer.Text.Trim();
            // Validate 
            if (name == "" || phone == "")
            {
                MessageBox.Show("Name and phone number cannot be left blank!");
                return;
            }
            if (!IsPhoneValid(phone))
            {
                MessageBox.Show("The phone number must consist of only 9-12 digits!");
                return;
            }
            if (email != "" && !IsEmailValid(email))
            {
                MessageBox.Show("Invalid email address!");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd;

                
                if (selectedCustomerId == -1)
                {
                    cmd = new SqlCommand(@"
                        INSERT INTO Customer (CustomerName, Phone, Address, Email, RegistrationDate)
                        VALUES (@name, @phone, @address, @email, GETDATE())", conn);
                    MessageBox.Show("Customer added successfully!");
                }
                else
                {
                    cmd = new SqlCommand(@"
                        UPDATE Customer 
                        SET CustomerName=@name,
                            Phone=@phone,
                            Address=@address,
                            Email=@email
                        WHERE CustomerID=@id", conn);
                    cmd.Parameters.AddWithValue("@id", selectedCustomerId);
                    MessageBox.Show("Customer update successful!");
                }
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
            }
            LoadCustomerData();
        }
                       
        private void btnDelete_Customer_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Please choose the customer!");
                return;
            }
            // Do not delete customers with orders.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand check = new SqlCommand(
                    "SELECT COUNT(*) FROM [Order] WHERE CustomerID=@id", conn);
                check.Parameters.AddWithValue("@id", selectedCustomerId);
                if ((int)check.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Cannot delete. The customer has existing orders!",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to delete this customer?",
                    "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                SqlCommand del = new SqlCommand(
                    "DELETE FROM Customer WHERE CustomerID=@id", conn);
                del.Parameters.AddWithValue("@id", selectedCustomerId);
                del.ExecuteNonQuery();
            }
            MessageBox.Show("Customer successfully deleted!");
            LoadCustomerData();
        }


      
        private void txtSeachCustomer_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSeachCustomer.Text.Trim();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT CustomerID, CustomerName, Phone, Address, Email, RegistrationDate
                    FROM Customer
                    WHERE CustomerName LIKE @kw OR Phone LIKE @kw
                    ORDER BY CustomerName ASC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomer.DataSource = dt;
            }
        }
        private void btnView_History_Customer_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Please choose the customer!");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT O.OrderID, O.OrderDate, O.TotalAmount, PM.MethodName
                    FROM [Order] O
                    JOIN PaymentMethod PM ON O.PaymentMethodID = PM.PaymentMethodID
                    WHERE O.CustomerID=@ID
                    ORDER BY O.OrderDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@ID", selectedCustomerId);

                DataTable dt = new DataTable();
                da.Fill(dt);
            }
        }

        private void txtEmail_Customer_TextChanged(object sender, EventArgs e){}
        private void txtReg_Date_Customer_TextChanged(object sender, EventArgs e) {        }
        private void btnEdit_Customer_Click(object sender, EventArgs e)
        {
            // Require a selected customer
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Please select the customer to edit!", "Notification",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Enable editing controls
            txtName_Customer.Enabled = true;
            txtPhone_Customer.Enabled = true;
            txtAddress_Customer.Enabled = true;
            txtEmail_Customer.Enabled = true;
            // Keep registration date read-only (it's set automatically on insert)
            try { txtReg_Date_Customer.Enabled = false; } catch { }
            // Enable Save, disable Add to avoid accidental inserts
            btnSave_Customer.Enabled = true;
            // Optionally disable delete while editing to prevent conflicting actions
            try { btnDelete_Customer.Enabled = false; } catch { }
            // Put focus on first editable field
            txtName_Customer.Focus();
            // Inform the user
            MessageBox.Show("You are editing the customer. Press Save to save the changes.", "Edit", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnRefresh_Customer_Click(object sender, EventArgs e)
        {
            try
            {
                // Reload data source
                LoadCustomerData();
                // Clear current selection / inputs
                selectedCustomerId = -1;
                txtName_Customer.Clear();
                txtPhone_Customer.Clear();
                txtAddress_Customer.Clear();
                txtEmail_Customer.Clear();
                txtReg_Date_Customer.Clear();
                // Clear DataGridView selection and reset buttons
                try { dgvCustomer.ClearSelection(); } catch { }
                btnDelete_Customer.Enabled = false;
                btnEdit_Customer.Enabled = false;
                btnSave_Customer.Enabled = true;
                // Set focus to first input
                txtName_Customer.Focus();
                // Optional feedback
                MessageBox.Show("Customer data refresh complete.", "Refresh",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when refreshing data:" + ex.Message, "Eror", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

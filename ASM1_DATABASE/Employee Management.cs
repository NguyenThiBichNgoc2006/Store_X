using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM1_DATABASE
{
    public partial class Employee_Management : Form
    {
        private readonly string connectionString =
           "server=LAPTOP-5BLS6617\\SQLEXPRESS; database=StoreX_SalesDB; Integrated Security=True";
        SqlConnection conn;
        // ID of the selected employee (used for edit/delete)
        private int selectedEmployeeId = -1;
        public Employee_Management()
        {
            InitializeComponent();
        }
        // DB stores password as HASHBYTES (varbinary). This helper returns byte[] for comparison/storage.
        private byte[] HashPasswordToBytes(string password)
        {
            if (password == null) return null;
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        // Load Employee data into the DataGridView
        private void LoadEmployeeData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Select columns to show (do NOT select plaintext password)
                string sql = @"SELECT EmployeeID, EmployeeName, Position, AuthorityLevel, Username, Phone 
                               FROM Employee ORDER BY EmployeeID";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEmployee.DataSource = dt;
                dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        // Populate Position dropdown (Admin, Salesperson, Warehouse staff)
        // When position is selected, AuthorityLevel is auto-set
        private void LoadPositionDropdown()
        {
            // Hard-coded list; could be loaded from DB if positions are stored externally
            cbPosition.Items.Clear();
            cbPosition.Items.Add("Admin");
            cbPosition.Items.Add("Salesperson");
            cbPosition.Items.Add("Warehouse staff");
        }
        // Reset form to default state (after load or after save/delete)
        private void ResetForm()
        {
            selectedEmployeeId = -1;
            txtName_Employee.Clear();
            txtUsername_Employee.Clear();
            txtPassword_Employee.Clear();
            txtPhone_Employee.Clear();
            cbPosition.SelectedIndex = -1;
            txtAuthority.Clear();
            // Disable edit/delete by default (enabled when a row is selected)
            btnEdit_Employee.Enabled = false;
            btnDelete_Employee.Enabled = false;
            btnSave_Employee.Enabled = true; // enabled for both add/edit
        }
        private void Position_Click(object sender, EventArgs e)  {  }
        private void txtAuthority_TextChanged(object sender, EventArgs e){  }
        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchEmployee.Text.Trim();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"SELECT EmployeeID, EmployeeName, Position, AuthorityLevel, Username, Phone
                               FROM Employee
                               WHERE EmployeeName LIKE @k OR Username LIKE @k
                               ORDER BY EmployeeID";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@k", "%" + keyword + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEmployee.DataSource = dt;
            }
        }
        // FORM LOAD
        // - Apply role-based UI restrictions: if user is not Admin, hide/disable sensitive actions
        // - Load employee list and positions
        private void Employee_Management_Load(object sender, EventArgs e)
        {
            // Apply role restrictions if UserSession exists
            try
            {
                // Initial load
                LoadPositionDropdown();
                LoadEmployeeData();
                ResetForm();
                // UI restrictions by role: 1=Admin,2=Sales,3=Warehouse
                if (UserSession.AuthorityLevel == 2) // Salesperson
                {
                    // Sales cannot manage employees -> disable/lock controls
                    btnAdd_Employee.Enabled = false;
                    btnEdit_Employee.Enabled = false;
                    btnDelete_Employee.Enabled = false;
                    btnSave_Employee.Enabled = false;
                    // Still allowed to view list
                    MessageBox.Show("You are logged in as Sales. Employee management functions are restricted.", "Authorization");
                }
                else if (UserSession.AuthorityLevel == 3) // Warehouse
                {
                    // Warehouse staff are not allowed to access Employee form -> close
                    MessageBox.Show("You do not have permission to access this feature.", "Authorization");
                    this.Close();
                    return;
                }
                // Admin (1) keeps all controls enabled
            }
            catch
            {
                // If no UserSession (e.g. running standalone) allow load without role enforcement
                LoadEmployeeData();
                ResetForm();
            }

        }

        private void EmployeeManagement_Click(object sender, EventArgs e){        }
        private void Search_Employee_Click(object sender, EventArgs e){        }
        private void Name_Employee_Click(object sender, EventArgs e){}
        // When a row is clicked in the DataGridView -> show data in textboxes
        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e){}
        // When a position is selected in cbPosition -> auto-set AuthorityLevel accordingly
        private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPosition.SelectedItem == null) return;

            string pos = cbPosition.SelectedItem.ToString();

            switch (pos)
            {
                case "Admin":
                    txtAuthority.Text = "1";
                    break;
                case "Salesperson":
                    txtAuthority.Text = "2";
                    break;
                case "Warehouse staff":
                    txtAuthority.Text = "3";
                    break;
                default:
                    txtAuthority.Clear();
                    break;
            }
        }
        private void txtName_Employee_TextChanged(object sender, EventArgs e) { }
        private void txtUsername_Employee_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_Employee_TextChanged(object sender, EventArgs e) {}
        private void txtPhone_Employee_TextChanged(object sender, EventArgs e){}
        private void btnAdd_Employee_Click(object sender, EventArgs e)
        {
            // Add button: switch form to "new" mode (clear fields)
            ResetForm();
            txtName_Employee.Focus();
        }
        private void btnEdit_Employee_Click(object sender, EventArgs e)
        {
            // Edit button: allow editing fields (username remains locked)
            if (selectedEmployeeId == -1)
            {
                MessageBox.Show("Please select an employee to edit.", "Notice");
                return;
            }
            // lock username from editing 
            txtUsername_Employee.Enabled = false; 
            // enable fields for editing
            txtName_Employee.Enabled = true;
            txtPassword_Employee.Enabled = true; // allow password change
            txtPhone_Employee.Enabled = true;
            cbPosition.Enabled = true;
            btnSave_Employee.Enabled = true;
        }
        // Delete button: delete an employee
        // - Validation: do not allow deleting yourself (optional policy)
        // - Confirm before deleting
        private void btnDelete_Employee_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeId == -1)
            {
                MessageBox.Show("Please select an employee to delete.", "Notice");
                return;
            }
            // Prevent deleting the currently logged-in user (safety)
            if (UserSession.EmployeeID == selectedEmployeeId)
            {
                MessageBox.Show("You cannot delete yourself.", "Error");
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete the selected employee?", "Confirm")
                == DialogResult.No) return;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Employee WHERE EmployeeID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", selectedEmployeeId);
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    MessageBox.Show("Employee deleted successfully.", "Success");
                }
                else
                {
                    MessageBox.Show("Failed to delete employee.", "Error");
                }
            }
           //  Check if this is the last Admin
            string checkAdmin = "SELECT COUNT(*) FROM Employee WHERE AuthorityLevel = 1";
            SqlCommand cmdCheck = new SqlCommand(checkAdmin, conn);
            int adminCount = Convert.ToInt32(cmdCheck.ExecuteScalar());

            if (adminCount <= 1)
            {
                MessageBox.Show("Cannot delete the last Admin account in the system!", "Not allowed");
                return;
            }
            // Refresh list and reset form
            LoadEmployeeData();
            ResetForm();
        }
        private bool IsPhoneValid(string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >= 9 && phone.Length <= 11;
        }
        // - If selectedEmployeeId == -1 => Insert (add new)
        // - Otherwise => Update
        // - Password will be hashed if provided
        // - When inserting, check username uniqueness
        private void btnSave_Employee_Click(object sender, EventArgs e)
        {

            string name = txtName_Employee.Text.Trim();
            string position = cbPosition.SelectedItem?.ToString();
            string authorityText = txtAuthority.Text.Trim();
            string username = txtUsername_Employee.Text.Trim();
            string password = txtPassword_Employee.Text; // do not Trim to preserve special chars
            string phone = txtPhone_Employee.Text.Trim();

            // Basic validation
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Name, position and username must not be empty.", "Missing data");
                return;
            }
            if (!int.TryParse(authorityText, out int authority))
            {
                MessageBox.Show("Authority Level is invalid.", "Error");
                return;
            }
            if (!IsPhoneValid(phone))
            {
                MessageBox.Show("Phone number is invalid (digits only, 9-11 characters).");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Insert new -> check username uniqueness
                if (selectedEmployeeId == -1)
                {
                    // Check username existence
                    string checkSql = "SELECT COUNT(*) FROM Employee WHERE Username = @username";
                    SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@username", username);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate username");
                        return;
                    }
                    // If password empty -> inform (password required when creating)
                    if (string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Please enter a password for the new employee.", "Missing password");
                        return;
                    }
                    // Hash password -> store as VARBINARY/byte[]
                    byte[] passwordBytes = HashPasswordToBytes(password);
                    string insertSql = @"
                        INSERT INTO Employee (EmployeeName, Position, AuthorityLevel, Username, Password, Phone)
                        VALUES (@name, @pos, @auth, @username, @pwd, @phone)";
                    SqlCommand insertCmd = new SqlCommand(insertSql, conn);
                    insertCmd.Parameters.AddWithValue("@name", name);
                    insertCmd.Parameters.AddWithValue("@pos", position);
                    insertCmd.Parameters.AddWithValue("@auth", authority);
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@pwd", passwordBytes);
                    insertCmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);

                    int rows = insertCmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Employee added successfully.", "Success");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add employee.", "Error");
                    }
                }
                else
                {
                    // Update employee (do not change username unless supporting that)
                    // If password provided -> hash and update it too
                    if (!string.IsNullOrEmpty(password))
                    {
                        byte[] passwordBytes = HashPasswordToBytes(password);
                        string updateSql = @"
                            UPDATE Employee
                            SET EmployeeName=@name, Position=@pos, AuthorityLevel=@auth,
                                Password=@pwd, Phone=@phone
                            WHERE EmployeeID=@id";

                        SqlCommand updateCmd = new SqlCommand(updateSql, conn);
                        updateCmd.Parameters.AddWithValue("@name", name);
                        updateCmd.Parameters.AddWithValue("@pos", position);
                        updateCmd.Parameters.AddWithValue("@auth", authority);
                        updateCmd.Parameters.AddWithValue("@pwd", passwordBytes);
                        updateCmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                        updateCmd.Parameters.AddWithValue("@id", selectedEmployeeId);

                        int rows = updateCmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Employee updated successfully (including password).", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Update failed.", "Error");
                        }
                    }
                    else
                    {
                        // Update without changing password
                        string updateSql = @"
                            UPDATE Employee
                            SET EmployeeName=@name, Position=@pos, AuthorityLevel=@auth, Phone=@phone
                            WHERE EmployeeID=@id";

                        SqlCommand updateCmd = new SqlCommand(updateSql, conn);
                        updateCmd.Parameters.AddWithValue("@name", name);
                        updateCmd.Parameters.AddWithValue("@pos", position);
                        updateCmd.Parameters.AddWithValue("@auth", authority);
                        updateCmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                        updateCmd.Parameters.AddWithValue("@id", selectedEmployeeId);

                        int rows = updateCmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Employee updated successfully.", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Update failed.", "Error");
                        }
                    }
                }
            } // using conn

            // After Insert/Update -> reload data and reset form
            LoadEmployeeData();
            ResetForm();
        }
        // Helper: Convert position string to authority level (if needed elsewhere)
        
        private int PositionToAuthority(string position)
        {
            if (string.IsNullOrEmpty(position)) return 0;
            switch (position)
            {
                case "Admin": return 1;
                case "Salesperson": return 2;
                case "Warehouse staff": return 3;
                default: return 0;
            }
        }
        
        // When the form closes, reset selection/state
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvEmployee.Rows[e.RowIndex];

            selectedEmployeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);

            txtName_Employee.Text = row.Cells["EmployeeName"].Value.ToString();
            cbPosition.SelectedItem = row.Cells["Position"].Value.ToString();
            txtAuthority.Text = row.Cells["AuthorityLevel"].Value.ToString();
            txtUsername_Employee.Text = row.Cells["Username"].Value.ToString();
            txtPhone_Employee.Text = row.Cells["Phone"].Value?.ToString() ?? "";

            txtPassword_Employee.Clear();

            btnEdit_Employee.Enabled = true;
            btnDelete_Employee.Enabled = true;
        }
    }
}

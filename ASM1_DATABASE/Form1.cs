using System;
using System.Data;
using System.Data.SqlClient;
// cryptography library
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace ASM1_DATABASE
{
    // This class helps pass user information to MainForm (and child forms if needed)
    public partial class Login : Form
    {
        SqlConnection conn;
        private const string connectionString = "server = LAPTOP-5BLS6617\\SQLEXPRESS; database = StoreX_SalesDB; Integrated Security=True";
                     
        public Login()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);


        }

       
        // Hash password -> return byte[] (matches HASHBYTES('SHA2_256', ...) in SQL)
        private byte[] HashPasswordToBytes(string password)
        {
            if (password == null) return null;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return hashBytes;
            }
        }  
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; // do not Trim() password to avoid altering user input (per requirement)
            // Validate input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Username and Password.", "Missing information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Hash password to byte[] to compare with Password column (saved as HASHBYTES in SQL)
            byte[] hashedPassword = HashPasswordToBytes(password);

            // Query database with parameterized query (prevent SQL Injection)
            string sql = @"
                SELECT EmployeeID, EmployeeName, Position, AuthorityLevel
                FROM Employee
                WHERE Username = @username AND Password = @password;";
            // Use the connection string declared above to create a new connection
            using (SqlConnection loginConn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, loginConn))

                try
                {
                    {
                        // Add parameters: username as string; password as varbinary
                        cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = username;

                        // Use SqlDbType.VarBinary and length 32 (for SHA-256)
                        cmd.Parameters.Add("@password", SqlDbType.VarBinary, 32).Value = hashedPassword;
                        loginConn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Login successful: store user data into UserSession
                                UserSession.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                                UserSession.EmployeeName = reader["EmployeeName"].ToString();
                                UserSession.Position = reader["Position"].ToString();
                                UserSession.AuthorityLevel = Convert.ToInt32(reader["AuthorityLevel"]);
                                MessageBox.Show(
                                $"Login successful. Welcome {UserSession.EmployeeName} ({UserSession.Position})",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //  Open MainForm and pass session
                                MainForm main = new MainForm();
                                main.Show();

                                //  Hide Login form after opening MainForm
                                this.Hide();
                            }
                            else
                            {
                                // Login failed
                                MessageBox.Show("Incorrect username or password.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle connection/query errors
                    MessageBox.Show("Error during login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the application?", "Confirm", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
    public static class UserSession
    {
        public static int EmployeeID { get; set; }
        public static string EmployeeName { get; set; }
        public static string Position { get; set; }
        public static int AuthorityLevel { get; set; }
    }
}

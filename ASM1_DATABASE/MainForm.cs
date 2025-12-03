using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM1_DATABASE
{
    public partial class MainForm : Form
    {
        private readonly string connectionString =
          "server=LAPTOP-5BLS6617\\SQLEXPRESS; database=StoreX_SalesDB; Integrated Security=True";

        // Minimum / maximum allowed size for child forms 
        private readonly Size childMinSize = new Size(700, 500);
        private readonly Size childMaxSize = new Size(1200, 900);
        // Keep reference to currently opened child so we can adjust it on resize
        private Form currentChild = null;
        public MainForm()
        {
            InitializeComponent();

            // Keep panel responsive to size changes
            panel_Main.SizeChanged += Panel_Main_SizeChanged;
            this.Resize += MainForm_Resize;
        }
        // Hàm này giúp mở các form con (Product, Customer...) vào panel bên phải
        private void OpenChildForm(Form childForm)
        {// Delete the old child form if it already exists in the panel
            panel_Main.Controls.Clear();
            currentChild = childForm;
            // Place the form into the panel (we do NOT dock Fill — we'll size it with constraints)
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.StartPosition = FormStartPosition.Manual;
            childForm.AutoScaleMode = AutoScaleMode.None;

            // Compute desired size clamped by min/max
            Size desired = panel_Main.ClientSize;
            desired.Width = Math.Max(childMinSize.Width, Math.Min(childMaxSize.Width, desired.Width));
            desired.Height = Math.Max(childMinSize.Height, Math.Min(childMaxSize.Height, desired.Height));
            childForm.Size = desired;

            // Center child inside panel
            childForm.Location = new Point(
                Math.Max(0, (panel_Main.ClientSize.Width - childForm.Width) / 2),
                Math.Max(0, (panel_Main.ClientSize.Height - childForm.Height) / 2)
            );
            // Allow scrolling if panel smaller than min size (so UI doesn't get clipped)
            panel_Main.AutoScroll = true;
            panel_Main.Controls.Add(childForm);
            panel_Main.Tag = childForm;
            childForm.Show();
        }
        // Called when panel size changes to re-layout current child
        private void Panel_Main_SizeChanged(object sender, EventArgs e)
        {
            AdjustCurrentChildSize();
        }
        // Also handle form resize (in case panel resizes with form)
        private void MainForm_Resize(object sender, EventArgs e)
        {
            AdjustCurrentChildSize();
        }
        private void AdjustCurrentChildSize()
        {
            if (currentChild == null) return;
            // Recompute clamped size based on current panel size
            Size desired = panel_Main.ClientSize;
            desired.Width = Math.Max(childMinSize.Width, Math.Min(childMaxSize.Width, desired.Width));
            desired.Height = Math.Max(childMinSize.Height, Math.Min(childMaxSize.Height, desired.Height));
            currentChild.Size = desired;
            // Re-center
            currentChild.Location = new Point(
                Math.Max(0, (panel_Main.ClientSize.Width - currentChild.Width) / 2),
                Math.Max(0, (panel_Main.ClientSize.Height - currentChild.Height) / 2)
            );
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e){}

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Get permissions from UserSession (saved after Login)
            int role = UserSession.AuthorityLevel;
            // Role-based access control
            if (role == 1) //  ADMIN
            {
                
            }
            else if (role == 2) // SALESPERSON
            {
               btnEmployee.Visible = false;     
                btnStatistic.Visible = false;    
                btnInventory.Visible = false;    
            }
            else if (role == 3) //  WAREHOUSE STAFF
            {
                // Warehouse: Dashboard, Inventory
                btnCustomer.Visible = false;
                btnOrder.Visible = false;
                btnEmployee.Visible = false;
                btnStatistic.Visible = false;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e){}
        private void btnStatistic_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Statistics_Report_Screen());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Order_Management());
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Customer_Management());
        }
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Employee_Management());
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Product_Management());
        }     
        private void btnInventory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Inventory_Management());
        }
        private void btnLogout_Mainform_Click(object sender, EventArgs e)
        {
            // Confirm logout with the user
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // Clear the in-memory session
            UserSession.EmployeeID = 0;
            UserSession.EmployeeName = null;
            UserSession.Position = null;
            UserSession.AuthorityLevel = 0;
             // Try to show existing Login form if present, otherwise open a new one
            var existingLogin = Application.OpenForms.OfType<Login>().FirstOrDefault();
            if (existingLogin != null)
            {
                existingLogin.Show();
                existingLogin.BringToFront();
            }
            else
            {
                var login = new Login();
                login.Show();
            }
            // Close the main form (will return control to the Login form)
            this.Close();
        }
    }
}
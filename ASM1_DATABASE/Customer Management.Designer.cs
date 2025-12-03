namespace ASM1_DATABASE
{
    partial class Customer_Management
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customer_Management));
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.btnSave_Customer = new System.Windows.Forms.Button();
            this.btnDelete_Customer = new System.Windows.Forms.Button();
            this.btnEdit_Customer = new System.Windows.Forms.Button();
            this.txtReg_Date_Customer = new System.Windows.Forms.TextBox();
            this.txtEmail_Customer = new System.Windows.Forms.TextBox();
            this.txtName_Customer = new System.Windows.Forms.TextBox();
            this.RegDate_Customer = new System.Windows.Forms.Label();
            this.Email_Customer = new System.Windows.Forms.Label();
            this.Address_Customer = new System.Windows.Forms.Label();
            this.Name_Customer = new System.Windows.Forms.Label();
            this.txtSeachCustomer = new System.Windows.Forms.TextBox();
            this.Search_Customer = new System.Windows.Forms.Label();
            this.CustomerManagement = new System.Windows.Forms.Label();
            this.txtAddress_Customer = new System.Windows.Forms.TextBox();
            this.btnView_History_Customer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Phone = new System.Windows.Forms.Label();
            this.txtPhone_Customer = new System.Windows.Forms.TextBox();
            this.btnRefresh_Customer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.CausesValidation = false;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Location = new System.Drawing.Point(386, 109);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.RowHeadersWidth = 51;
            this.dgvCustomer.RowTemplate.Height = 24;
            this.dgvCustomer.Size = new System.Drawing.Size(537, 300);
            this.dgvCustomer.TabIndex = 72;
            this.dgvCustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellClick);
            // 
            // btnSave_Customer
            // 
            this.btnSave_Customer.Location = new System.Drawing.Point(54, 424);
            this.btnSave_Customer.Name = "btnSave_Customer";
            this.btnSave_Customer.Size = new System.Drawing.Size(75, 40);
            this.btnSave_Customer.TabIndex = 71;
            this.btnSave_Customer.Text = "Save";
            this.btnSave_Customer.UseVisualStyleBackColor = true;
            this.btnSave_Customer.Click += new System.EventHandler(this.btnSave_Customer_Click);
            // 
            // btnDelete_Customer
            // 
            this.btnDelete_Customer.Location = new System.Drawing.Point(267, 424);
            this.btnDelete_Customer.Name = "btnDelete_Customer";
            this.btnDelete_Customer.Size = new System.Drawing.Size(75, 40);
            this.btnDelete_Customer.TabIndex = 70;
            this.btnDelete_Customer.Text = "Delete";
            this.btnDelete_Customer.UseVisualStyleBackColor = true;
            this.btnDelete_Customer.Click += new System.EventHandler(this.btnDelete_Customer_Click);
            // 
            // btnEdit_Customer
            // 
            this.btnEdit_Customer.Location = new System.Drawing.Point(162, 424);
            this.btnEdit_Customer.Name = "btnEdit_Customer";
            this.btnEdit_Customer.Size = new System.Drawing.Size(75, 40);
            this.btnEdit_Customer.TabIndex = 69;
            this.btnEdit_Customer.Text = "Edit";
            this.btnEdit_Customer.UseVisualStyleBackColor = true;
            this.btnEdit_Customer.Click += new System.EventHandler(this.btnEdit_Customer_Click);
            // 
            // txtReg_Date_Customer
            // 
            this.txtReg_Date_Customer.Location = new System.Drawing.Point(147, 298);
            this.txtReg_Date_Customer.Name = "txtReg_Date_Customer";
            this.txtReg_Date_Customer.Size = new System.Drawing.Size(195, 22);
            this.txtReg_Date_Customer.TabIndex = 64;
            this.txtReg_Date_Customer.TextChanged += new System.EventHandler(this.txtReg_Date_Customer_TextChanged);
            // 
            // txtEmail_Customer
            // 
            this.txtEmail_Customer.Location = new System.Drawing.Point(147, 262);
            this.txtEmail_Customer.Name = "txtEmail_Customer";
            this.txtEmail_Customer.Size = new System.Drawing.Size(195, 22);
            this.txtEmail_Customer.TabIndex = 63;
            this.txtEmail_Customer.TextChanged += new System.EventHandler(this.txtEmail_Customer_TextChanged);
            // 
            // txtName_Customer
            // 
            this.txtName_Customer.Location = new System.Drawing.Point(147, 143);
            this.txtName_Customer.Name = "txtName_Customer";
            this.txtName_Customer.Size = new System.Drawing.Size(195, 22);
            this.txtName_Customer.TabIndex = 61;
            // 
            // RegDate_Customer
            // 
            this.RegDate_Customer.AutoSize = true;
            this.RegDate_Customer.Location = new System.Drawing.Point(37, 301);
            this.RegDate_Customer.Name = "RegDate_Customer";
            this.RegDate_Customer.Size = new System.Drawing.Size(65, 16);
            this.RegDate_Customer.TabIndex = 59;
            this.RegDate_Customer.Text = "Reg Date";
            // 
            // Email_Customer
            // 
            this.Email_Customer.AutoSize = true;
            this.Email_Customer.Location = new System.Drawing.Point(37, 265);
            this.Email_Customer.Name = "Email_Customer";
            this.Email_Customer.Size = new System.Drawing.Size(41, 16);
            this.Email_Customer.TabIndex = 58;
            this.Email_Customer.Text = "Email";
            // 
            // Address_Customer
            // 
            this.Address_Customer.AutoSize = true;
            this.Address_Customer.Location = new System.Drawing.Point(37, 227);
            this.Address_Customer.Name = "Address_Customer";
            this.Address_Customer.Size = new System.Drawing.Size(58, 16);
            this.Address_Customer.TabIndex = 57;
            this.Address_Customer.Text = "Address";
            // 
            // Name_Customer
            // 
            this.Name_Customer.AutoSize = true;
            this.Name_Customer.Location = new System.Drawing.Point(37, 146);
            this.Name_Customer.Name = "Name_Customer";
            this.Name_Customer.Size = new System.Drawing.Size(44, 16);
            this.Name_Customer.TabIndex = 56;
            this.Name_Customer.Text = "Name";
            // 
            // txtSeachCustomer
            // 
            this.txtSeachCustomer.Location = new System.Drawing.Point(147, 109);
            this.txtSeachCustomer.Name = "txtSeachCustomer";
            this.txtSeachCustomer.Size = new System.Drawing.Size(195, 22);
            this.txtSeachCustomer.TabIndex = 55;
            this.txtSeachCustomer.TextChanged += new System.EventHandler(this.txtSeachCustomer_TextChanged);
            // 
            // Search_Customer
            // 
            this.Search_Customer.AutoSize = true;
            this.Search_Customer.Location = new System.Drawing.Point(37, 109);
            this.Search_Customer.Name = "Search_Customer";
            this.Search_Customer.Size = new System.Drawing.Size(50, 16);
            this.Search_Customer.TabIndex = 54;
            this.Search_Customer.Text = "Search";
            // 
            // CustomerManagement
            // 
            this.CustomerManagement.AutoSize = true;
            this.CustomerManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerManagement.Location = new System.Drawing.Point(229, 25);
            this.CustomerManagement.Name = "CustomerManagement";
            this.CustomerManagement.Size = new System.Drawing.Size(296, 31);
            this.CustomerManagement.TabIndex = 47;
            this.CustomerManagement.Text = "Customer Management";
            // 
            // txtAddress_Customer
            // 
            this.txtAddress_Customer.Location = new System.Drawing.Point(147, 221);
            this.txtAddress_Customer.Name = "txtAddress_Customer";
            this.txtAddress_Customer.Size = new System.Drawing.Size(195, 22);
            this.txtAddress_Customer.TabIndex = 73;
            // 
            // btnView_History_Customer
            // 
            this.btnView_History_Customer.Location = new System.Drawing.Point(534, 424);
            this.btnView_History_Customer.Name = "btnView_History_Customer";
            this.btnView_History_Customer.Size = new System.Drawing.Size(75, 40);
            this.btnView_History_Customer.TabIndex = 74;
            this.btnView_History_Customer.Text = "View History";
            this.btnView_History_Customer.UseVisualStyleBackColor = true;
            this.btnView_History_Customer.Click += new System.EventHandler(this.btnView_History_Customer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 75;
            // 
            // Phone
            // 
            this.Phone.AutoSize = true;
            this.Phone.Location = new System.Drawing.Point(37, 185);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(46, 16);
            this.Phone.TabIndex = 76;
            this.Phone.Text = "Phone";
            // 
            // txtPhone_Customer
            // 
            this.txtPhone_Customer.Location = new System.Drawing.Point(147, 182);
            this.txtPhone_Customer.Name = "txtPhone_Customer";
            this.txtPhone_Customer.Size = new System.Drawing.Size(195, 22);
            this.txtPhone_Customer.TabIndex = 77;
            // 
            // btnRefresh_Customer
            // 
            this.btnRefresh_Customer.Location = new System.Drawing.Point(407, 424);
            this.btnRefresh_Customer.Name = "btnRefresh_Customer";
            this.btnRefresh_Customer.Size = new System.Drawing.Size(67, 40);
            this.btnRefresh_Customer.TabIndex = 78;
            this.btnRefresh_Customer.Text = "Refresh";
            this.btnRefresh_Customer.UseVisualStyleBackColor = true;
            this.btnRefresh_Customer.Click += new System.EventHandler(this.btnRefresh_Customer_Click);
            // 
            // Customer_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(960, 531);
            this.Controls.Add(this.btnRefresh_Customer);
            this.Controls.Add(this.txtPhone_Customer);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnView_History_Customer);
            this.Controls.Add(this.txtAddress_Customer);
            this.Controls.Add(this.dgvCustomer);
            this.Controls.Add(this.btnSave_Customer);
            this.Controls.Add(this.btnDelete_Customer);
            this.Controls.Add(this.btnEdit_Customer);
            this.Controls.Add(this.txtReg_Date_Customer);
            this.Controls.Add(this.txtEmail_Customer);
            this.Controls.Add(this.txtName_Customer);
            this.Controls.Add(this.RegDate_Customer);
            this.Controls.Add(this.Email_Customer);
            this.Controls.Add(this.Address_Customer);
            this.Controls.Add(this.Name_Customer);
            this.Controls.Add(this.txtSeachCustomer);
            this.Controls.Add(this.Search_Customer);
            this.Controls.Add(this.CustomerManagement);
            this.Name = "Customer_Management";
            this.Text = "Customer_Management";
            this.Load += new System.EventHandler(this.Customer_Management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.Button btnSave_Customer;
        private System.Windows.Forms.Button btnDelete_Customer;
        private System.Windows.Forms.Button btnEdit_Customer;
        private System.Windows.Forms.TextBox txtReg_Date_Customer;
        private System.Windows.Forms.TextBox txtEmail_Customer;
        private System.Windows.Forms.TextBox txtName_Customer;
        private System.Windows.Forms.Label RegDate_Customer;
        private System.Windows.Forms.Label Email_Customer;
        private System.Windows.Forms.Label Address_Customer;
        private System.Windows.Forms.Label Name_Customer;
        private System.Windows.Forms.TextBox txtSeachCustomer;
        private System.Windows.Forms.Label Search_Customer;
        private System.Windows.Forms.Label CustomerManagement;
        private System.Windows.Forms.TextBox txtAddress_Customer;
        private System.Windows.Forms.Button btnView_History_Customer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Phone;
        private System.Windows.Forms.TextBox txtPhone_Customer;
        private System.Windows.Forms.Button btnRefresh_Customer;
    }
}
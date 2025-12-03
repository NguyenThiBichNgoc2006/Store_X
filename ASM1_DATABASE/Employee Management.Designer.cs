namespace ASM1_DATABASE
{
    partial class Employee_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee_Management));
            this.EmployeeManagement = new System.Windows.Forms.Label();
            this.txtSearchEmployee = new System.Windows.Forms.TextBox();
            this.Search_Employee = new System.Windows.Forms.Label();
            this.Name_Employee = new System.Windows.Forms.Label();
            this.Position = new System.Windows.Forms.Label();
            this.Authority = new System.Windows.Forms.Label();
            this.Username_Employee = new System.Windows.Forms.Label();
            this.Password_Employee = new System.Windows.Forms.Label();
            this.txtName_Employee = new System.Windows.Forms.TextBox();
            this.txtPassword_Employee = new System.Windows.Forms.TextBox();
            this.txtAuthority = new System.Windows.Forms.TextBox();
            this.txtUsername_Employee = new System.Windows.Forms.TextBox();
            this.cbPosition = new System.Windows.Forms.ComboBox();
            this.Phone_Employee = new System.Windows.Forms.Label();
            this.txtPhone_Employee = new System.Windows.Forms.TextBox();
            this.btnAdd_Employee = new System.Windows.Forms.Button();
            this.btnEdit_Employee = new System.Windows.Forms.Button();
            this.btnDelete_Employee = new System.Windows.Forms.Button();
            this.btnSave_Employee = new System.Windows.Forms.Button();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // EmployeeManagement
            // 
            this.EmployeeManagement.AutoSize = true;
            this.EmployeeManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeManagement.Location = new System.Drawing.Point(166, 14);
            this.EmployeeManagement.Name = "EmployeeManagement";
            this.EmployeeManagement.Size = new System.Drawing.Size(298, 31);
            this.EmployeeManagement.TabIndex = 2;
            this.EmployeeManagement.Text = "Employee Management";
            this.EmployeeManagement.Click += new System.EventHandler(this.EmployeeManagement_Click);
            // 
            // txtSearchEmployee
            // 
            this.txtSearchEmployee.Location = new System.Drawing.Point(114, 71);
            this.txtSearchEmployee.Name = "txtSearchEmployee";
            this.txtSearchEmployee.Size = new System.Drawing.Size(195, 22);
            this.txtSearchEmployee.TabIndex = 29;
            this.txtSearchEmployee.TextChanged += new System.EventHandler(this.txtSearchEmployee_TextChanged);
            // 
            // Search_Employee
            // 
            this.Search_Employee.AutoSize = true;
            this.Search_Employee.Location = new System.Drawing.Point(36, 77);
            this.Search_Employee.Name = "Search_Employee";
            this.Search_Employee.Size = new System.Drawing.Size(50, 16);
            this.Search_Employee.TabIndex = 28;
            this.Search_Employee.Text = "Search";
            this.Search_Employee.Click += new System.EventHandler(this.Search_Employee_Click);
            // 
            // Name_Employee
            // 
            this.Name_Employee.AutoSize = true;
            this.Name_Employee.Location = new System.Drawing.Point(36, 117);
            this.Name_Employee.Name = "Name_Employee";
            this.Name_Employee.Size = new System.Drawing.Size(44, 16);
            this.Name_Employee.TabIndex = 30;
            this.Name_Employee.Text = "Name";
            this.Name_Employee.Click += new System.EventHandler(this.Name_Employee_Click);
            // 
            // Position
            // 
            this.Position.AutoSize = true;
            this.Position.Location = new System.Drawing.Point(36, 151);
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(55, 16);
            this.Position.TabIndex = 31;
            this.Position.Text = "Position";
            this.Position.Click += new System.EventHandler(this.Position_Click);
            // 
            // Authority
            // 
            this.Authority.AutoSize = true;
            this.Authority.Location = new System.Drawing.Point(36, 191);
            this.Authority.Name = "Authority";
            this.Authority.Size = new System.Drawing.Size(58, 16);
            this.Authority.TabIndex = 32;
            this.Authority.Text = "Authority";
            // 
            // Username_Employee
            // 
            this.Username_Employee.AutoSize = true;
            this.Username_Employee.Location = new System.Drawing.Point(36, 227);
            this.Username_Employee.Name = "Username_Employee";
            this.Username_Employee.Size = new System.Drawing.Size(70, 16);
            this.Username_Employee.TabIndex = 33;
            this.Username_Employee.Text = "Username";
            // 
            // Password_Employee
            // 
            this.Password_Employee.AutoSize = true;
            this.Password_Employee.Location = new System.Drawing.Point(36, 259);
            this.Password_Employee.Name = "Password_Employee";
            this.Password_Employee.Size = new System.Drawing.Size(67, 16);
            this.Password_Employee.TabIndex = 34;
            this.Password_Employee.Text = "Password";
            // 
            // txtName_Employee
            // 
            this.txtName_Employee.Location = new System.Drawing.Point(114, 111);
            this.txtName_Employee.Name = "txtName_Employee";
            this.txtName_Employee.Size = new System.Drawing.Size(191, 22);
            this.txtName_Employee.TabIndex = 35;
            this.txtName_Employee.TextChanged += new System.EventHandler(this.txtName_Employee_TextChanged);
            // 
            // txtPassword_Employee
            // 
            this.txtPassword_Employee.Location = new System.Drawing.Point(114, 259);
            this.txtPassword_Employee.Name = "txtPassword_Employee";
            this.txtPassword_Employee.Size = new System.Drawing.Size(191, 22);
            this.txtPassword_Employee.TabIndex = 36;
            this.txtPassword_Employee.TextChanged += new System.EventHandler(this.txtPassword_Employee_TextChanged);
            // 
            // txtAuthority
            // 
            this.txtAuthority.Location = new System.Drawing.Point(114, 188);
            this.txtAuthority.Name = "txtAuthority";
            this.txtAuthority.Size = new System.Drawing.Size(191, 22);
            this.txtAuthority.TabIndex = 37;
            this.txtAuthority.TextChanged += new System.EventHandler(this.txtAuthority_TextChanged);
            // 
            // txtUsername_Employee
            // 
            this.txtUsername_Employee.Location = new System.Drawing.Point(114, 221);
            this.txtUsername_Employee.Name = "txtUsername_Employee";
            this.txtUsername_Employee.Size = new System.Drawing.Size(191, 22);
            this.txtUsername_Employee.TabIndex = 38;
            this.txtUsername_Employee.TextChanged += new System.EventHandler(this.txtUsername_Employee_TextChanged);
            // 
            // cbPosition
            // 
            this.cbPosition.FormattingEnabled = true;
            this.cbPosition.Items.AddRange(new object[] {
            "Management",
            "Sales Staff",
            "Warehouse Staff"});
            this.cbPosition.Location = new System.Drawing.Point(114, 148);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(191, 24);
            this.cbPosition.TabIndex = 39;
            this.cbPosition.SelectedIndexChanged += new System.EventHandler(this.cbPosition_SelectedIndexChanged);
            // 
            // Phone_Employee
            // 
            this.Phone_Employee.AutoSize = true;
            this.Phone_Employee.Location = new System.Drawing.Point(36, 296);
            this.Phone_Employee.Name = "Phone_Employee";
            this.Phone_Employee.Size = new System.Drawing.Size(46, 16);
            this.Phone_Employee.TabIndex = 40;
            this.Phone_Employee.Text = "Phone";
            // 
            // txtPhone_Employee
            // 
            this.txtPhone_Employee.Location = new System.Drawing.Point(114, 296);
            this.txtPhone_Employee.Name = "txtPhone_Employee";
            this.txtPhone_Employee.Size = new System.Drawing.Size(191, 22);
            this.txtPhone_Employee.TabIndex = 41;
            this.txtPhone_Employee.TextChanged += new System.EventHandler(this.txtPhone_Employee_TextChanged);
            // 
            // btnAdd_Employee
            // 
            this.btnAdd_Employee.Location = new System.Drawing.Point(135, 404);
            this.btnAdd_Employee.Name = "btnAdd_Employee";
            this.btnAdd_Employee.Size = new System.Drawing.Size(75, 40);
            this.btnAdd_Employee.TabIndex = 42;
            this.btnAdd_Employee.Text = "Add";
            this.btnAdd_Employee.UseVisualStyleBackColor = true;
            this.btnAdd_Employee.Click += new System.EventHandler(this.btnAdd_Employee_Click);
            // 
            // btnEdit_Employee
            // 
            this.btnEdit_Employee.Location = new System.Drawing.Point(240, 404);
            this.btnEdit_Employee.Name = "btnEdit_Employee";
            this.btnEdit_Employee.Size = new System.Drawing.Size(75, 40);
            this.btnEdit_Employee.TabIndex = 43;
            this.btnEdit_Employee.Text = "Edit";
            this.btnEdit_Employee.UseVisualStyleBackColor = true;
            this.btnEdit_Employee.Click += new System.EventHandler(this.btnEdit_Employee_Click);
            // 
            // btnDelete_Employee
            // 
            this.btnDelete_Employee.Location = new System.Drawing.Point(345, 404);
            this.btnDelete_Employee.Name = "btnDelete_Employee";
            this.btnDelete_Employee.Size = new System.Drawing.Size(75, 40);
            this.btnDelete_Employee.TabIndex = 44;
            this.btnDelete_Employee.Text = "Delete";
            this.btnDelete_Employee.UseVisualStyleBackColor = true;
            this.btnDelete_Employee.Click += new System.EventHandler(this.btnDelete_Employee_Click);
            // 
            // btnSave_Employee
            // 
            this.btnSave_Employee.Location = new System.Drawing.Point(451, 404);
            this.btnSave_Employee.Name = "btnSave_Employee";
            this.btnSave_Employee.Size = new System.Drawing.Size(75, 40);
            this.btnSave_Employee.TabIndex = 45;
            this.btnSave_Employee.Text = "Save";
            this.btnSave_Employee.UseVisualStyleBackColor = true;
            this.btnSave_Employee.Click += new System.EventHandler(this.btnSave_Employee_Click);
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Location = new System.Drawing.Point(340, 71);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowHeadersWidth = 51;
            this.dgvEmployee.RowTemplate.Height = 24;
            this.dgvEmployee.Size = new System.Drawing.Size(582, 263);
            this.dgvEmployee.TabIndex = 46;
            this.dgvEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellClick);
            // 
            // Employee_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(962, 478);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.btnSave_Employee);
            this.Controls.Add(this.btnDelete_Employee);
            this.Controls.Add(this.btnEdit_Employee);
            this.Controls.Add(this.btnAdd_Employee);
            this.Controls.Add(this.txtPhone_Employee);
            this.Controls.Add(this.Phone_Employee);
            this.Controls.Add(this.cbPosition);
            this.Controls.Add(this.txtUsername_Employee);
            this.Controls.Add(this.txtAuthority);
            this.Controls.Add(this.txtPassword_Employee);
            this.Controls.Add(this.txtName_Employee);
            this.Controls.Add(this.Password_Employee);
            this.Controls.Add(this.Username_Employee);
            this.Controls.Add(this.Authority);
            this.Controls.Add(this.Position);
            this.Controls.Add(this.Name_Employee);
            this.Controls.Add(this.txtSearchEmployee);
            this.Controls.Add(this.Search_Employee);
            this.Controls.Add(this.EmployeeManagement);
            this.Name = "Employee_Management";
            this.Text = "Employee_Management";
            this.Load += new System.EventHandler(this.Employee_Management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EmployeeManagement;
        private System.Windows.Forms.TextBox txtSearchEmployee;
        private System.Windows.Forms.Label Search_Employee;
        private System.Windows.Forms.Label Name_Employee;
        private System.Windows.Forms.Label Position;
        private System.Windows.Forms.Label Authority;
        private System.Windows.Forms.Label Username_Employee;
        private System.Windows.Forms.Label Password_Employee;
        private System.Windows.Forms.TextBox txtName_Employee;
        private System.Windows.Forms.TextBox txtPassword_Employee;
        private System.Windows.Forms.TextBox txtAuthority;
        private System.Windows.Forms.TextBox txtUsername_Employee;
        private System.Windows.Forms.ComboBox cbPosition;
        private System.Windows.Forms.Label Phone_Employee;
        private System.Windows.Forms.TextBox txtPhone_Employee;
        private System.Windows.Forms.Button btnAdd_Employee;
        private System.Windows.Forms.Button btnEdit_Employee;
        private System.Windows.Forms.Button btnDelete_Employee;
        private System.Windows.Forms.Button btnSave_Employee;
        private System.Windows.Forms.DataGridView dgvEmployee;
    }
}
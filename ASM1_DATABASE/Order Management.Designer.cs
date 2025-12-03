namespace ASM1_DATABASE
{
    partial class Order_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_Management));
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.btnSave_Order = new System.Windows.Forms.Button();
            this.btnPrintInvoice_Order = new System.Windows.Forms.Button();
            this.Items_Order = new System.Windows.Forms.Label();
            this.cbCustomer_Order = new System.Windows.Forms.ComboBox();
            this.txtTotal_Order = new System.Windows.Forms.TextBox();
            this.Password_Employee = new System.Windows.Forms.Label();
            this.Payment_Order = new System.Windows.Forms.Label();
            this.Product_Order = new System.Windows.Forms.Label();
            this.Customer_Order = new System.Windows.Forms.Label();
            this.OrderDate = new System.Windows.Forms.Label();
            this.txtSearch_Order = new System.Windows.Forms.TextBox();
            this.Search_Employee = new System.Windows.Forms.Label();
            this.OrderManagement = new System.Windows.Forms.Label();
            this.cbProduct_Order = new System.Windows.Forms.ComboBox();
            this.cbPayment_Order = new System.Windows.Forms.ComboBox();
            this.Price_Order = new System.Windows.Forms.Label();
            this.Quantity_Order = new System.Windows.Forms.Label();
            this.txtPrice_Order = new System.Windows.Forms.TextBox();
            this.txtQuantity_Order = new System.Windows.Forms.TextBox();
            this.btnDelete_Order = new System.Windows.Forms.Button();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.Employee_Order = new System.Windows.Forms.Label();
            this.cbImployeeID = new System.Windows.Forms.ComboBox();
            this.btnRefresh_Order = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(349, 117);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.RowHeadersWidth = 51;
            this.dgvOrderItems.RowTemplate.Height = 24;
            this.dgvOrderItems.Size = new System.Drawing.Size(597, 324);
            this.dgvOrderItems.TabIndex = 72;
            this.dgvOrderItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItems_CellClick);
            this.dgvOrderItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItems_CellClick);
            // 
            // btnSave_Order
            // 
            this.btnSave_Order.Location = new System.Drawing.Point(98, 471);
            this.btnSave_Order.Name = "btnSave_Order";
            this.btnSave_Order.Size = new System.Drawing.Size(80, 40);
            this.btnSave_Order.TabIndex = 71;
            this.btnSave_Order.Text = "Save";
            this.btnSave_Order.UseVisualStyleBackColor = true;
            this.btnSave_Order.Click += new System.EventHandler(this.btnSave_Order_Click);
            // 
            // btnPrintInvoice_Order
            // 
            this.btnPrintInvoice_Order.Location = new System.Drawing.Point(473, 471);
            this.btnPrintInvoice_Order.Name = "btnPrintInvoice_Order";
            this.btnPrintInvoice_Order.Size = new System.Drawing.Size(97, 40);
            this.btnPrintInvoice_Order.TabIndex = 70;
            this.btnPrintInvoice_Order.Text = "Print Invoice";
            this.btnPrintInvoice_Order.UseVisualStyleBackColor = true;
            this.btnPrintInvoice_Order.Click += new System.EventHandler(this.btnPrintInvoice_Order_Click);
            // 
            // Items_Order
            // 
            this.Items_Order.AutoSize = true;
            this.Items_Order.Location = new System.Drawing.Point(377, 85);
            this.Items_Order.Name = "Items_Order";
            this.Items_Order.Size = new System.Drawing.Size(39, 16);
            this.Items_Order.TabIndex = 66;
            this.Items_Order.Text = "Items";
            this.Items_Order.Click += new System.EventHandler(this.Items_Order_Click);
            // 
            // cbCustomer_Order
            // 
            this.cbCustomer_Order.FormattingEnabled = true;
            this.cbCustomer_Order.Items.AddRange(new object[] {
            "Customer1",
            "Customer2",
            "Customer3",
            "Customer4",
            "Customer5",
            "Customer6"});
            this.cbCustomer_Order.Location = new System.Drawing.Point(126, 196);
            this.cbCustomer_Order.Name = "cbCustomer_Order";
            this.cbCustomer_Order.Size = new System.Drawing.Size(195, 24);
            this.cbCustomer_Order.TabIndex = 65;
            this.cbCustomer_Order.SelectedIndexChanged += new System.EventHandler(this.cbCustomer_Order_SelectedIndexChanged);
            // 
            // txtTotal_Order
            // 
            this.txtTotal_Order.Location = new System.Drawing.Point(126, 369);
            this.txtTotal_Order.Name = "txtTotal_Order";
            this.txtTotal_Order.Size = new System.Drawing.Size(195, 22);
            this.txtTotal_Order.TabIndex = 62;
            this.txtTotal_Order.TextChanged += new System.EventHandler(this.txtTotal_Order_TextChanged);
            // 
            // Password_Employee
            // 
            this.Password_Employee.AutoSize = true;
            this.Password_Employee.Location = new System.Drawing.Point(39, 372);
            this.Password_Employee.Name = "Password_Employee";
            this.Password_Employee.Size = new System.Drawing.Size(38, 16);
            this.Password_Employee.TabIndex = 60;
            this.Password_Employee.Text = "Total";
            // 
            // Payment_Order
            // 
            this.Payment_Order.AutoSize = true;
            this.Payment_Order.Location = new System.Drawing.Point(39, 341);
            this.Payment_Order.Name = "Payment_Order";
            this.Payment_Order.Size = new System.Drawing.Size(60, 16);
            this.Payment_Order.TabIndex = 59;
            this.Payment_Order.Text = "Payment";
            // 
            // Product_Order
            // 
            this.Product_Order.AutoSize = true;
            this.Product_Order.Location = new System.Drawing.Point(39, 241);
            this.Product_Order.Name = "Product_Order";
            this.Product_Order.Size = new System.Drawing.Size(53, 16);
            this.Product_Order.TabIndex = 58;
            this.Product_Order.Text = "Product";
            this.Product_Order.Click += new System.EventHandler(this.Product_Order_Click);
            // 
            // Customer_Order
            // 
            this.Customer_Order.AutoSize = true;
            this.Customer_Order.Location = new System.Drawing.Point(39, 204);
            this.Customer_Order.Name = "Customer_Order";
            this.Customer_Order.Size = new System.Drawing.Size(64, 16);
            this.Customer_Order.TabIndex = 57;
            this.Customer_Order.Text = "Customer";
            this.Customer_Order.Click += new System.EventHandler(this.Position_Click);
            // 
            // OrderDate
            // 
            this.OrderDate.AutoSize = true;
            this.OrderDate.Location = new System.Drawing.Point(39, 128);
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.Size = new System.Drawing.Size(73, 16);
            this.OrderDate.TabIndex = 56;
            this.OrderDate.Text = "Order Date";
            this.OrderDate.Click += new System.EventHandler(this.OrderDate_Click);
            // 
            // txtSearch_Order
            // 
            this.txtSearch_Order.Location = new System.Drawing.Point(126, 88);
            this.txtSearch_Order.Name = "txtSearch_Order";
            this.txtSearch_Order.Size = new System.Drawing.Size(195, 22);
            this.txtSearch_Order.TabIndex = 55;
            this.txtSearch_Order.TextChanged += new System.EventHandler(this.txtSearch_Order_TextChanged);
            // 
            // Search_Employee
            // 
            this.Search_Employee.AutoSize = true;
            this.Search_Employee.Location = new System.Drawing.Point(39, 88);
            this.Search_Employee.Name = "Search_Employee";
            this.Search_Employee.Size = new System.Drawing.Size(50, 16);
            this.Search_Employee.TabIndex = 54;
            this.Search_Employee.Text = "Search";
            // 
            // OrderManagement
            // 
            this.OrderManagement.AutoSize = true;
            this.OrderManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderManagement.Location = new System.Drawing.Point(137, 19);
            this.OrderManagement.Name = "OrderManagement";
            this.OrderManagement.Size = new System.Drawing.Size(247, 31);
            this.OrderManagement.TabIndex = 47;
            this.OrderManagement.Text = "Order Management";
            // 
            // cbProduct_Order
            // 
            this.cbProduct_Order.FormattingEnabled = true;
            this.cbProduct_Order.Items.AddRange(new object[] {
            "iPhone 14",
            "Dell Laptop",
            "Sony Headphones",
            "Samsung Fridge",
            "Designer Shirt",
            "Harry Potter Book\'"});
            this.cbProduct_Order.Location = new System.Drawing.Point(126, 233);
            this.cbProduct_Order.Name = "cbProduct_Order";
            this.cbProduct_Order.Size = new System.Drawing.Size(195, 24);
            this.cbProduct_Order.TabIndex = 73;
            this.cbProduct_Order.SelectedIndexChanged += new System.EventHandler(this.cbProduct_Order_SelectedIndexChanged);
            // 
            // cbPayment_Order
            // 
            this.cbPayment_Order.FormattingEnabled = true;
            this.cbPayment_Order.Items.AddRange(new object[] {
            "Cash",
            "Credit Card",
            "Bank Transfer",
            "Debit Card",
            "Momo Wallet",
            "ZaloPay"});
            this.cbPayment_Order.Location = new System.Drawing.Point(126, 333);
            this.cbPayment_Order.Name = "cbPayment_Order";
            this.cbPayment_Order.Size = new System.Drawing.Size(195, 24);
            this.cbPayment_Order.TabIndex = 74;
            this.cbPayment_Order.SelectedIndexChanged += new System.EventHandler(this.cbPayment_Order_SelectedIndexChanged);
            // 
            // Price_Order
            // 
            this.Price_Order.AutoSize = true;
            this.Price_Order.Location = new System.Drawing.Point(39, 276);
            this.Price_Order.Name = "Price_Order";
            this.Price_Order.Size = new System.Drawing.Size(38, 16);
            this.Price_Order.TabIndex = 75;
            this.Price_Order.Text = "Price";
            // 
            // Quantity_Order
            // 
            this.Quantity_Order.AutoSize = true;
            this.Quantity_Order.Location = new System.Drawing.Point(39, 307);
            this.Quantity_Order.Name = "Quantity_Order";
            this.Quantity_Order.Size = new System.Drawing.Size(55, 16);
            this.Quantity_Order.TabIndex = 76;
            this.Quantity_Order.Text = "Quantity";
            // 
            // txtPrice_Order
            // 
            this.txtPrice_Order.Location = new System.Drawing.Point(126, 273);
            this.txtPrice_Order.Name = "txtPrice_Order";
            this.txtPrice_Order.Size = new System.Drawing.Size(195, 22);
            this.txtPrice_Order.TabIndex = 77;
            this.txtPrice_Order.TextChanged += new System.EventHandler(this.txtPrice_Order_TextChanged_1);
            // 
            // txtQuantity_Order
            // 
            this.txtQuantity_Order.Location = new System.Drawing.Point(126, 305);
            this.txtQuantity_Order.Name = "txtQuantity_Order";
            this.txtQuantity_Order.Size = new System.Drawing.Size(195, 22);
            this.txtQuantity_Order.TabIndex = 78;
            this.txtQuantity_Order.TextChanged += new System.EventHandler(this.txtQuantity_Order_TextChanged);
            this.txtQuantity_Order.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_Order_KeyDown);
            // 
            // btnDelete_Order
            // 
            this.btnDelete_Order.Location = new System.Drawing.Point(239, 471);
            this.btnDelete_Order.Name = "btnDelete_Order";
            this.btnDelete_Order.Size = new System.Drawing.Size(67, 40);
            this.btnDelete_Order.TabIndex = 80;
            this.btnDelete_Order.Text = "Delete";
            this.btnDelete_Order.UseVisualStyleBackColor = true;
            this.btnDelete_Order.Click += new System.EventHandler(this.btnDelete_Order_Click);
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Location = new System.Drawing.Point(126, 123);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(200, 22);
            this.dtpOrderDate.TabIndex = 81;
            // 
            // Employee_Order
            // 
            this.Employee_Order.AutoSize = true;
            this.Employee_Order.Location = new System.Drawing.Point(39, 159);
            this.Employee_Order.Name = "Employee_Order";
            this.Employee_Order.Size = new System.Drawing.Size(69, 16);
            this.Employee_Order.TabIndex = 82;
            this.Employee_Order.Text = "Employee";
            this.Employee_Order.Click += new System.EventHandler(this.Employee_Order_Click);
            // 
            // cbImployeeID
            // 
            this.cbImployeeID.FormattingEnabled = true;
            this.cbImployeeID.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cbImployeeID.Location = new System.Drawing.Point(126, 156);
            this.cbImployeeID.Name = "cbImployeeID";
            this.cbImployeeID.Size = new System.Drawing.Size(200, 24);
            this.cbImployeeID.TabIndex = 83;
            this.cbImployeeID.SelectedIndexChanged += new System.EventHandler(this.cbImployeeID_SelectedIndexChanged);
            // 
            // btnRefresh_Order
            // 
            this.btnRefresh_Order.Location = new System.Drawing.Point(361, 471);
            this.btnRefresh_Order.Name = "btnRefresh_Order";
            this.btnRefresh_Order.Size = new System.Drawing.Size(67, 40);
            this.btnRefresh_Order.TabIndex = 84;
            this.btnRefresh_Order.Text = "Refresh";
            this.btnRefresh_Order.UseVisualStyleBackColor = true;
            this.btnRefresh_Order.Click += new System.EventHandler(this.btnRefresh_Order_Click);
            // 
            // Order_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(967, 542);
            this.Controls.Add(this.btnRefresh_Order);
            this.Controls.Add(this.cbImployeeID);
            this.Controls.Add(this.Employee_Order);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.btnDelete_Order);
            this.Controls.Add(this.txtQuantity_Order);
            this.Controls.Add(this.txtPrice_Order);
            this.Controls.Add(this.Quantity_Order);
            this.Controls.Add(this.Price_Order);
            this.Controls.Add(this.cbPayment_Order);
            this.Controls.Add(this.cbProduct_Order);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.btnSave_Order);
            this.Controls.Add(this.btnPrintInvoice_Order);
            this.Controls.Add(this.Items_Order);
            this.Controls.Add(this.cbCustomer_Order);
            this.Controls.Add(this.txtTotal_Order);
            this.Controls.Add(this.Password_Employee);
            this.Controls.Add(this.Payment_Order);
            this.Controls.Add(this.Product_Order);
            this.Controls.Add(this.Customer_Order);
            this.Controls.Add(this.OrderDate);
            this.Controls.Add(this.txtSearch_Order);
            this.Controls.Add(this.Search_Employee);
            this.Controls.Add(this.OrderManagement);
            this.Name = "Order_Management";
            this.Text = "Order_Management";
            this.Load += new System.EventHandler(this.Order_Management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Button btnSave_Order;
        private System.Windows.Forms.Button btnPrintInvoice_Order;
        private System.Windows.Forms.Label Items_Order;
        private System.Windows.Forms.ComboBox cbCustomer_Order;
        private System.Windows.Forms.TextBox txtTotal_Order;
        private System.Windows.Forms.Label Password_Employee;
        private System.Windows.Forms.Label Payment_Order;
        private System.Windows.Forms.Label Product_Order;
        private System.Windows.Forms.Label Customer_Order;
        private System.Windows.Forms.Label OrderDate;
        private System.Windows.Forms.TextBox txtSearch_Order;
        private System.Windows.Forms.Label Search_Employee;
        private System.Windows.Forms.Label OrderManagement;
        private System.Windows.Forms.ComboBox cbProduct_Order;
        private System.Windows.Forms.ComboBox cbPayment_Order;
        private System.Windows.Forms.Label Price_Order;
        private System.Windows.Forms.Label Quantity_Order;
        private System.Windows.Forms.TextBox txtPrice_Order;
        private System.Windows.Forms.TextBox txtQuantity_Order;
        private System.Windows.Forms.Button btnDelete_Order;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label Employee_Order;
        private System.Windows.Forms.ComboBox cbImployeeID;
        private System.Windows.Forms.Button btnRefresh_Order;
    }
}
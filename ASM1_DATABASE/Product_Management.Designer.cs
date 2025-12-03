namespace ASM1_DATABASE
{
    partial class Product_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Product_Management));
            this.ProductManagement = new System.Windows.Forms.Label();
            this.Product_Name = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.Quantity = new System.Windows.Forms.Label();
            this.Category = new System.Windows.Forms.Label();
            this.Search_Product = new System.Windows.Forms.Label();
            this.Supplier = new System.Windows.Forms.Label();
            this.btnAdd_Product = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtName_Product_Management = new System.Windows.Forms.TextBox();
            this.txtPrice_Product = new System.Windows.Forms.TextBox();
            this.txtQuantity_Product = new System.Windows.Forms.TextBox();
            this.cbCategory_Product = new System.Windows.Forms.ComboBox();
            this.cbSupplier_Product = new System.Windows.Forms.ComboBox();
            this.VND = new System.Windows.Forms.Label();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.btnSave_Product = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductManagement
            // 
            this.ProductManagement.AutoSize = true;
            this.ProductManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductManagement.Location = new System.Drawing.Point(125, 9);
            this.ProductManagement.Name = "ProductManagement";
            this.ProductManagement.Size = new System.Drawing.Size(272, 31);
            this.ProductManagement.TabIndex = 1;
            this.ProductManagement.Text = "Product Management";
            // 
            // Product_Name
            // 
            this.Product_Name.AutoSize = true;
            this.Product_Name.Location = new System.Drawing.Point(36, 154);
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.Size = new System.Drawing.Size(93, 16);
            this.Product_Name.TabIndex = 14;
            this.Product_Name.Text = "Product Name";
            this.Product_Name.Click += new System.EventHandler(this.Product_Name_Click);
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(36, 191);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(38, 16);
            this.Price.TabIndex = 15;
            this.Price.Text = "Price";
            // 
            // Quantity
            // 
            this.Quantity.AutoSize = true;
            this.Quantity.Location = new System.Drawing.Point(36, 219);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(55, 16);
            this.Quantity.TabIndex = 16;
            this.Quantity.Text = "Quantity";
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Location = new System.Drawing.Point(36, 255);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(62, 16);
            this.Category.TabIndex = 17;
            this.Category.Text = "Category";
            // 
            // Search_Product
            // 
            this.Search_Product.AutoSize = true;
            this.Search_Product.Location = new System.Drawing.Point(36, 115);
            this.Search_Product.Name = "Search_Product";
            this.Search_Product.Size = new System.Drawing.Size(50, 16);
            this.Search_Product.TabIndex = 18;
            this.Search_Product.Text = "Search";
            this.Search_Product.Click += new System.EventHandler(this.Search_Product_Click);
            // 
            // Supplier
            // 
            this.Supplier.AutoSize = true;
            this.Supplier.Location = new System.Drawing.Point(36, 289);
            this.Supplier.Name = "Supplier";
            this.Supplier.Size = new System.Drawing.Size(57, 16);
            this.Supplier.TabIndex = 19;
            this.Supplier.Text = "Supplier";
            // 
            // btnAdd_Product
            // 
            this.btnAdd_Product.Location = new System.Drawing.Point(115, 471);
            this.btnAdd_Product.Name = "btnAdd_Product";
            this.btnAdd_Product.Size = new System.Drawing.Size(67, 40);
            this.btnAdd_Product.TabIndex = 21;
            this.btnAdd_Product.Text = "Add";
            this.btnAdd_Product.UseVisualStyleBackColor = true;
            this.btnAdd_Product.Click += new System.EventHandler(this.btnAdd_Product_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(212, 471);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(67, 40);
            this.btnEdit.TabIndex = 22;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(321, 471);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 40);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(425, 471);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(67, 40);
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(113, 115);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(195, 22);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // txtName_Product_Management
            // 
            this.txtName_Product_Management.Location = new System.Drawing.Point(144, 154);
            this.txtName_Product_Management.Name = "txtName_Product_Management";
            this.txtName_Product_Management.Size = new System.Drawing.Size(177, 22);
            this.txtName_Product_Management.TabIndex = 28;
            this.txtName_Product_Management.TextChanged += new System.EventHandler(this.txtName_Product_Management_TextChanged);
            // 
            // txtPrice_Product
            // 
            this.txtPrice_Product.Location = new System.Drawing.Point(113, 185);
            this.txtPrice_Product.Name = "txtPrice_Product";
            this.txtPrice_Product.Size = new System.Drawing.Size(164, 22);
            this.txtPrice_Product.TabIndex = 29;
            this.txtPrice_Product.TextChanged += new System.EventHandler(this.txtPrice_Product_TextChanged);
            // 
            // txtQuantity_Product
            // 
            this.txtQuantity_Product.Location = new System.Drawing.Point(113, 216);
            this.txtQuantity_Product.Name = "txtQuantity_Product";
            this.txtQuantity_Product.Size = new System.Drawing.Size(160, 22);
            this.txtQuantity_Product.TabIndex = 30;
            this.txtQuantity_Product.TextChanged += new System.EventHandler(this.txtQuantity_Product_TextChanged);
            // 
            // cbCategory_Product
            // 
            this.cbCategory_Product.FormattingEnabled = true;
            this.cbCategory_Product.Items.AddRange(new object[] {
            "Smartphone",
            "Laptop",
            "Accessories",
            "Home Appliances",
            "Fashion",
            "Books"});
            this.cbCategory_Product.Location = new System.Drawing.Point(115, 252);
            this.cbCategory_Product.Name = "cbCategory_Product";
            this.cbCategory_Product.Size = new System.Drawing.Size(162, 24);
            this.cbCategory_Product.TabIndex = 31;
            this.cbCategory_Product.SelectedIndexChanged += new System.EventHandler(this.cbCategory_Product_SelectedIndexChanged);
            // 
            // cbSupplier_Product
            // 
            this.cbSupplier_Product.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cbSupplier_Product.FormattingEnabled = true;
            this.cbSupplier_Product.Items.AddRange(new object[] {
            "Supplier Tech1",
            "Supplier Electro2",
            "Supplier Gadget3",
            "Supplier Home4",
            "Supplier Fashion5",
            "Supplier Book6\'"});
            this.cbSupplier_Product.Location = new System.Drawing.Point(113, 286);
            this.cbSupplier_Product.Name = "cbSupplier_Product";
            this.cbSupplier_Product.Size = new System.Drawing.Size(164, 24);
            this.cbSupplier_Product.TabIndex = 32;
            this.cbSupplier_Product.SelectedIndexChanged += new System.EventHandler(this.cbSupplier_Product_SelectedIndexChanged);
            // 
            // VND
            // 
            this.VND.AutoSize = true;
            this.VND.Location = new System.Drawing.Point(285, 191);
            this.VND.Name = "VND";
            this.VND.Size = new System.Drawing.Size(36, 16);
            this.VND.TabIndex = 34;
            this.VND.Text = "VND";
            // 
            // dgvProduct
            // 
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Location = new System.Drawing.Point(391, 75);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.RowHeadersWidth = 51;
            this.dgvProduct.RowTemplate.Height = 24;
            this.dgvProduct.Size = new System.Drawing.Size(517, 293);
            this.dgvProduct.TabIndex = 35;
            this.dgvProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellClick);
            this.dgvProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellClick);
            // 
            // btnSave_Product
            // 
            this.btnSave_Product.Location = new System.Drawing.Point(524, 472);
            this.btnSave_Product.Name = "btnSave_Product";
            this.btnSave_Product.Size = new System.Drawing.Size(75, 39);
            this.btnSave_Product.TabIndex = 38;
            this.btnSave_Product.Text = "Save";
            this.btnSave_Product.UseVisualStyleBackColor = true;
            this.btnSave_Product.Click += new System.EventHandler(this.btnSave_Product_Click);
            // 
            // Product_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(934, 542);
            this.Controls.Add(this.btnSave_Product);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.VND);
            this.Controls.Add(this.cbSupplier_Product);
            this.Controls.Add(this.cbCategory_Product);
            this.Controls.Add(this.txtQuantity_Product);
            this.Controls.Add(this.txtPrice_Product);
            this.Controls.Add(this.txtName_Product_Management);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd_Product);
            this.Controls.Add(this.Supplier);
            this.Controls.Add(this.Search_Product);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Product_Name);
            this.Controls.Add(this.ProductManagement);
            this.Name = "Product_Management";
            this.Text = "Product_Management";
            this.Load += new System.EventHandler(this.Product_Management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProductManagement;
        private System.Windows.Forms.Label Product_Name;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label Quantity;
        private System.Windows.Forms.Label Category;
        private System.Windows.Forms.Label Search_Product;
        private System.Windows.Forms.Label Supplier;
        private System.Windows.Forms.Button btnAdd_Product;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtName_Product_Management;
        private System.Windows.Forms.TextBox txtPrice_Product;
        private System.Windows.Forms.TextBox txtQuantity_Product;
        private System.Windows.Forms.ComboBox cbCategory_Product;
        private System.Windows.Forms.ComboBox cbSupplier_Product;
        private System.Windows.Forms.Label VND;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button btnSave_Product;
    }
}
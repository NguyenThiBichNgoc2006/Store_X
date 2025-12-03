namespace ASM1_DATABASE
{
    partial class Inventory_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory_Management));
            this.btnLow_Stock_Alert = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.btnExport_Report = new System.Windows.Forms.Button();
            this.txtUpdate_Qty = new System.Windows.Forms.TextBox();
            this.Log_Inventory = new System.Windows.Forms.Label();
            this.Supplier_Inventory = new System.Windows.Forms.Label();
            this.UpdateQty_Inventory = new System.Windows.Forms.Label();
            this.Filter_Inventory = new System.Windows.Forms.Label();
            this.InventoryManagement = new System.Windows.Forms.Label();
            this.cb_Filter_Invertory = new System.Windows.Forms.ComboBox();
            this.cbSupplier_Inventory = new System.Windows.Forms.ComboBox();
            this.dgvLog_Inventory = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog_Inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLow_Stock_Alert
            // 
            this.btnLow_Stock_Alert.Location = new System.Drawing.Point(273, 401);
            this.btnLow_Stock_Alert.Name = "btnLow_Stock_Alert";
            this.btnLow_Stock_Alert.Size = new System.Drawing.Size(117, 40);
            this.btnLow_Stock_Alert.TabIndex = 97;
            this.btnLow_Stock_Alert.Text = "Low Stock Alert";
            this.btnLow_Stock_Alert.UseVisualStyleBackColor = true;
            this.btnLow_Stock_Alert.Click += new System.EventHandler(this.btnLow_Stock_Alert_Click);
            // 
            // dgvInventory
            // 
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(374, 64);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowHeadersWidth = 51;
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.Size = new System.Drawing.Size(396, 281);
            this.dgvInventory.TabIndex = 95;
            this.dgvInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellClick);
            this.dgvInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellClick);
            // 
            // btnExport_Report
            // 
            this.btnExport_Report.Location = new System.Drawing.Point(57, 401);
            this.btnExport_Report.Name = "btnExport_Report";
            this.btnExport_Report.Size = new System.Drawing.Size(109, 40);
            this.btnExport_Report.TabIndex = 91;
            this.btnExport_Report.Text = "Export Report";
            this.btnExport_Report.UseVisualStyleBackColor = true;
            this.btnExport_Report.Click += new System.EventHandler(this.btnExport_Report_Click);
            // 
            // txtUpdate_Qty
            // 
            this.txtUpdate_Qty.Location = new System.Drawing.Point(138, 138);
            this.txtUpdate_Qty.Name = "txtUpdate_Qty";
            this.txtUpdate_Qty.Size = new System.Drawing.Size(154, 22);
            this.txtUpdate_Qty.TabIndex = 88;
            this.txtUpdate_Qty.TextChanged += new System.EventHandler(this.txtUpdate_Qty_TextChanged);
            // 
            // Log_Inventory
            // 
            this.Log_Inventory.AutoSize = true;
            this.Log_Inventory.Location = new System.Drawing.Point(45, 221);
            this.Log_Inventory.Name = "Log_Inventory";
            this.Log_Inventory.Size = new System.Drawing.Size(30, 16);
            this.Log_Inventory.TabIndex = 87;
            this.Log_Inventory.Text = "Log";
            this.Log_Inventory.Click += new System.EventHandler(this.Log_Inventory_Click);
            // 
            // Supplier_Inventory
            // 
            this.Supplier_Inventory.AutoSize = true;
            this.Supplier_Inventory.Location = new System.Drawing.Point(45, 180);
            this.Supplier_Inventory.Name = "Supplier_Inventory";
            this.Supplier_Inventory.Size = new System.Drawing.Size(57, 16);
            this.Supplier_Inventory.TabIndex = 85;
            this.Supplier_Inventory.Text = "Supplier";
            // 
            // UpdateQty_Inventory
            // 
            this.UpdateQty_Inventory.AutoSize = true;
            this.UpdateQty_Inventory.Location = new System.Drawing.Point(45, 138);
            this.UpdateQty_Inventory.Name = "UpdateQty_Inventory";
            this.UpdateQty_Inventory.Size = new System.Drawing.Size(75, 16);
            this.UpdateQty_Inventory.TabIndex = 84;
            this.UpdateQty_Inventory.Text = "Update Qty";
            // 
            // Filter_Inventory
            // 
            this.Filter_Inventory.AutoSize = true;
            this.Filter_Inventory.Location = new System.Drawing.Point(45, 96);
            this.Filter_Inventory.Name = "Filter_Inventory";
            this.Filter_Inventory.Size = new System.Drawing.Size(36, 16);
            this.Filter_Inventory.TabIndex = 82;
            this.Filter_Inventory.Text = "Filter";
            // 
            // InventoryManagement
            // 
            this.InventoryManagement.AutoSize = true;
            this.InventoryManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryManagement.Location = new System.Drawing.Point(132, 18);
            this.InventoryManagement.Name = "InventoryManagement";
            this.InventoryManagement.Size = new System.Drawing.Size(291, 31);
            this.InventoryManagement.TabIndex = 75;
            this.InventoryManagement.Text = "Inventory Management";
            // 
            // cb_Filter_Invertory
            // 
            this.cb_Filter_Invertory.FormattingEnabled = true;
            this.cb_Filter_Invertory.Items.AddRange(new object[] {
            "Smartphone",
            "Laptop",
            "Accessories",
            "Home Appliances",
            "Fashion",
            "Books"});
            this.cb_Filter_Invertory.Location = new System.Drawing.Point(138, 96);
            this.cb_Filter_Invertory.Name = "cb_Filter_Invertory";
            this.cb_Filter_Invertory.Size = new System.Drawing.Size(154, 24);
            this.cb_Filter_Invertory.TabIndex = 98;
            this.cb_Filter_Invertory.SelectedIndexChanged += new System.EventHandler(this.cbFilter_Invertory_SelectedIndexChanged);
            // 
            // cbSupplier_Inventory
            // 
            this.cbSupplier_Inventory.FormattingEnabled = true;
            this.cbSupplier_Inventory.Items.AddRange(new object[] {
            "Supplier Tech1",
            "Supplier Electro2",
            "Supplier Gadget3",
            "Supplier Home4",
            "Supplier Fashion5",
            "Supplier Book6"});
            this.cbSupplier_Inventory.Location = new System.Drawing.Point(138, 172);
            this.cbSupplier_Inventory.Name = "cbSupplier_Inventory";
            this.cbSupplier_Inventory.Size = new System.Drawing.Size(154, 24);
            this.cbSupplier_Inventory.TabIndex = 99;
            this.cbSupplier_Inventory.SelectedIndexChanged += new System.EventHandler(this.cbSupplier_Inventory_SelectedIndexChanged);
            // 
            // dgvLog_Inventory
            // 
            this.dgvLog_Inventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog_Inventory.Location = new System.Drawing.Point(100, 221);
            this.dgvLog_Inventory.Name = "dgvLog_Inventory";
            this.dgvLog_Inventory.RowHeadersWidth = 51;
            this.dgvLog_Inventory.RowTemplate.Height = 24;
            this.dgvLog_Inventory.Size = new System.Drawing.Size(254, 162);
            this.dgvLog_Inventory.TabIndex = 100;
            this.dgvLog_Inventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLog_Inventory_CellContentClick);
            // 
            // Inventory_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(789, 452);
            this.Controls.Add(this.dgvLog_Inventory);
            this.Controls.Add(this.cbSupplier_Inventory);
            this.Controls.Add(this.cb_Filter_Invertory);
            this.Controls.Add(this.btnLow_Stock_Alert);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.btnExport_Report);
            this.Controls.Add(this.txtUpdate_Qty);
            this.Controls.Add(this.Log_Inventory);
            this.Controls.Add(this.Supplier_Inventory);
            this.Controls.Add(this.UpdateQty_Inventory);
            this.Controls.Add(this.Filter_Inventory);
            this.Controls.Add(this.InventoryManagement);
            this.Name = "Inventory_Management";
            this.Text = "Inventory_Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog_Inventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLow_Stock_Alert;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Button btnExport_Report;
        private System.Windows.Forms.TextBox txtUpdate_Qty;
        private System.Windows.Forms.Label Log_Inventory;
        private System.Windows.Forms.Label Supplier_Inventory;
        private System.Windows.Forms.Label UpdateQty_Inventory;
        private System.Windows.Forms.Label Filter_Inventory;
        private System.Windows.Forms.Label InventoryManagement;
        private System.Windows.Forms.ComboBox cb_Filter_Invertory;
        private System.Windows.Forms.ComboBox cbSupplier_Inventory;
        private System.Windows.Forms.DataGridView dgvLog_Inventory;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
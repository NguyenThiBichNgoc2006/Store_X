namespace ASM1_DATABASE
{
    partial class Statistics_Report_Screen
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics_Report_Screen));
            this.btnRefresh_Statistics = new System.Windows.Forms.Button();
            this.btnExport_Excel_Statiscs = new System.Windows.Forms.Button();
            this.TopEmployee = new System.Windows.Forms.Label();
            this.lbllWeekInfo = new System.Windows.Forms.Label();
            this.StatisticsManagement = new System.Windows.Forms.Label();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listTop_Employee_Statistics = new System.Windows.Forms.ListView();
            this.btnPrev_Week = new System.Windows.Forms.Button();
            this.btnThis_week = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh_Statistics
            // 
            this.btnRefresh_Statistics.Location = new System.Drawing.Point(616, 466);
            this.btnRefresh_Statistics.Name = "btnRefresh_Statistics";
            this.btnRefresh_Statistics.Size = new System.Drawing.Size(75, 40);
            this.btnRefresh_Statistics.TabIndex = 92;
            this.btnRefresh_Statistics.Text = "Refresh";
            this.btnRefresh_Statistics.UseVisualStyleBackColor = true;
            this.btnRefresh_Statistics.Click += new System.EventHandler(this.btnRefresh_Statistics_Click);
            // 
            // btnExport_Excel_Statiscs
            // 
            this.btnExport_Excel_Statiscs.Location = new System.Drawing.Point(440, 466);
            this.btnExport_Excel_Statiscs.Name = "btnExport_Excel_Statiscs";
            this.btnExport_Excel_Statiscs.Size = new System.Drawing.Size(109, 40);
            this.btnExport_Excel_Statiscs.TabIndex = 91;
            this.btnExport_Excel_Statiscs.Text = "Export Excel";
            this.btnExport_Excel_Statiscs.UseVisualStyleBackColor = true;
            this.btnExport_Excel_Statiscs.Click += new System.EventHandler(this.btnExport_Excel_Statiscs_Click);
            // 
            // TopEmployee
            // 
            this.TopEmployee.AutoSize = true;
            this.TopEmployee.Location = new System.Drawing.Point(55, 87);
            this.TopEmployee.Name = "TopEmployee";
            this.TopEmployee.Size = new System.Drawing.Size(194, 16);
            this.TopEmployee.TabIndex = 86;
            this.TopEmployee.Text = "The best employee of the week";
            // 
            // lbllWeekInfo
            // 
            this.lbllWeekInfo.AutoSize = true;
            this.lbllWeekInfo.Location = new System.Drawing.Point(496, 54);
            this.lbllWeekInfo.Name = "lbllWeekInfo";
            this.lbllWeekInfo.Size = new System.Drawing.Size(145, 16);
            this.lbllWeekInfo.TabIndex = 85;
            this.lbllWeekInfo.Text = "Weekly Revenue Chart";
            this.lbllWeekInfo.Click += new System.EventHandler(this.lblWeekInfo_Click);
            // 
            // StatisticsManagement
            // 
            this.StatisticsManagement.AutoSize = true;
            this.StatisticsManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatisticsManagement.Location = new System.Drawing.Point(125, 20);
            this.StatisticsManagement.Name = "StatisticsManagement";
            this.StatisticsManagement.Size = new System.Drawing.Size(289, 31);
            this.StatisticsManagement.TabIndex = 75;
            this.StatisticsManagement.Text = "Statistics Management";
            // 
            // chartRevenue
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend1);
            this.chartRevenue.Location = new System.Drawing.Point(481, 87);
            this.chartRevenue.Name = "chartRevenue";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartRevenue.Series.Add(series1);
            this.chartRevenue.Size = new System.Drawing.Size(386, 351);
            this.chartRevenue.TabIndex = 96;
            this.chartRevenue.Text = "chartRevenue";
            this.chartRevenue.Click += new System.EventHandler(this.chartRevenue_Click);
            // 
            // listTop_Employee_Statistics
            // 
            this.listTop_Employee_Statistics.HideSelection = false;
            this.listTop_Employee_Statistics.Location = new System.Drawing.Point(40, 120);
            this.listTop_Employee_Statistics.Name = "listTop_Employee_Statistics";
            this.listTop_Employee_Statistics.Size = new System.Drawing.Size(410, 255);
            this.listTop_Employee_Statistics.TabIndex = 97;
            this.listTop_Employee_Statistics.UseCompatibleStateImageBehavior = false;
            this.listTop_Employee_Statistics.SelectedIndexChanged += new System.EventHandler(this.listTop_Employee_Statistics_SelectedIndexChanged);
            // 
            // btnPrev_Week
            // 
            this.btnPrev_Week.Location = new System.Drawing.Point(215, 466);
            this.btnPrev_Week.Name = "btnPrev_Week";
            this.btnPrev_Week.Size = new System.Drawing.Size(110, 40);
            this.btnPrev_Week.TabIndex = 98;
            this.btnPrev_Week.Text = "Prev Week";
            this.btnPrev_Week.UseVisualStyleBackColor = true;
            this.btnPrev_Week.Click += new System.EventHandler(this.btnPrev_Week_Click);
            // 
            // btnThis_week
            // 
            this.btnThis_week.Location = new System.Drawing.Point(58, 466);
            this.btnThis_week.Name = "btnThis_week";
            this.btnThis_week.Size = new System.Drawing.Size(110, 40);
            this.btnThis_week.TabIndex = 99;
            this.btnThis_week.Text = "This week";
            this.btnThis_week.UseVisualStyleBackColor = true;
            this.btnThis_week.Click += new System.EventHandler(this.btnThis_week_Click);
            // 
            // Statistics_Report_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(879, 541);
            this.Controls.Add(this.btnThis_week);
            this.Controls.Add(this.btnPrev_Week);
            this.Controls.Add(this.listTop_Employee_Statistics);
            this.Controls.Add(this.chartRevenue);
            this.Controls.Add(this.btnRefresh_Statistics);
            this.Controls.Add(this.btnExport_Excel_Statiscs);
            this.Controls.Add(this.TopEmployee);
            this.Controls.Add(this.lbllWeekInfo);
            this.Controls.Add(this.StatisticsManagement);
            this.Name = "Statistics_Report_Screen";
            this.Text = "Statistics_Report_Screen";
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRefresh_Statistics;
        private System.Windows.Forms.Button btnExport_Excel_Statiscs;
        private System.Windows.Forms.Label TopEmployee;
        private System.Windows.Forms.Label lbllWeekInfo;
        private System.Windows.Forms.Label StatisticsManagement;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.ListView listTop_Employee_Statistics;
        private System.Windows.Forms.Button btnPrev_Week;
        private System.Windows.Forms.Button btnThis_week;
    }
}
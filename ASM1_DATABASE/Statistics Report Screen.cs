using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ASM1_DATABASE
{
    public partial class Statistics_Report_Screen : Form
    {
        private string connectionString =
           "server=LAPTOP-5BLS6617\\SQLEXPRESS; database=StoreX_SalesDB; Integrated Security=True";
        SqlConnection conn;
        // current week
        private DateTime currentWeek = DateTime.Now;
        // Add this field declaration to your Statistics_Report_Screen class
        private Label lblWeekInfo;
        public Statistics_Report_Screen()
        {
            InitializeComponent();
            lblWeekInfo = new Label();
        }
        private void Statistics_Report_Screen_Load(object sender, EventArgs e)
        {
            LoadWeeklyStatistics();  // When form opens -> automatically load this week
        }
        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = date.DayOfWeek - DayOfWeek.Monday;
            if (diff < 0) diff += 7;
            return date.AddDays(-diff).Date;
        }
        private DateTime GetEndOfWeek(DateTime date)
        {
            return GetStartOfWeek(date).AddDays(6);
        }
        private DataTable GetWeeklyRevenue(DateTime weekDate)
        {
            DateTime from = GetStartOfWeek(weekDate);
            DateTime to = GetEndOfWeek(weekDate);
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql =
                    @"SELECT 
                          CAST(OrderDate AS DATE) AS OrderDate,
                          SUM(TotalAmount) AS Revenue
                      FROM [Order]
                      WHERE OrderDate BETWEEN @from AND @to
                      GROUP BY CAST(OrderDate AS DATE)
                      ORDER BY OrderDate ASC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@from", from);
                da.SelectCommand.Parameters.AddWithValue("@to", to);
                da.Fill(dt);
            }
            return dt;
        }
        private void LoadTopEmployees(DateTime weekDate)
        {
            DateTime from = GetStartOfWeek(weekDate);
            DateTime to = GetEndOfWeek(weekDate);
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql =
                    @"SELECT TOP 5 E.EmployeeName, SUM(O.TotalAmount) AS TotalRevenue
                      FROM [Order] O
                      JOIN Employee E ON O.EmployeeID = E.EmployeeID
                      WHERE O.OrderDate BETWEEN @from AND @to
                      GROUP BY E.EmployeeName
                      ORDER BY TotalRevenue DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@from", from);
                da.SelectCommand.Parameters.AddWithValue("@to", to);
                DataTable dt = new DataTable();
                da.Fill(dt);
                listTop_Employee_Statistics.Items.Clear();
                foreach (DataRow row in dt.Rows)
                    listTop_Employee_Statistics.Items.Add(
                        $"{row["EmployeeName"]} " +
                        $"— {Convert.ToDecimal(row["TotalRevenue"]).ToString("N0")} VND"
                    );
            }
        }
        private void DrawWeeklyChart(DateTime weekDate)
        {
           // Fetch revenue data from DB (only days with orders)
           // dtRevenue only contains days with revenue > 0
           DataTable dtRevenue = GetWeeklyRevenue(weekDate);
            // Prepare Series
            chartRevenue.Series.Clear();
            Series s = new Series("Revenue");
            s.ChartType = SeriesChartType.Column;
            s.XValueType = ChartValueType.Date;
            s.IsValueShownAsLabel = true;
            s.Color = Color.SteelBlue; // (Optional color)
            // Set column width (helps columns look better when there are 7)
            s.SetCustomProperty("PointWidth", "1.5");
            // Create 7 data points for the 7 days of the week (Monday -> Sunday)
            DateTime startDate = GetStartOfWeek(weekDate);
            double total = 0;
            for (int i = 0; i < 7; i++)
            {
                DateTime currentDay = startDate.AddDays(i).Date;
                double dailyRevenue = 0;
                // Find revenue for this date in the queried DataTable
                // Use yyyy-MM-dd format to match date values in the DataTable exactly
                DataRow[] foundRows = dtRevenue.Select($"OrderDate = '{currentDay.ToString("yyyy-MM-dd")}'");
                if (foundRows.Length > 0)
                {
                    dailyRevenue = Convert.ToDouble(foundRows[0]["Revenue"]);
                }
                // Add data point for that day. If not found, dailyRevenue is 0.
                s.Points.AddXY(currentDay, dailyRevenue);
                total += dailyRevenue;
            }
            // Format chart
            chartRevenue.Series.Add(s);
            // REQUIRED to avoid column overlap issue:
            // Force X axis to show a label for each day
            chartRevenue.ChartAreas[0].AxisX.LabelStyle.Format = "ddd dd/MM";
            // Force chart interval to 1 day
            chartRevenue.ChartAreas[0].AxisX.Interval = 1;
            chartRevenue.ChartAreas[0].AxisX.IntervalType
                = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            // Optional: ensure Y axis starts at 0
            chartRevenue.ChartAreas[0].AxisY.Minimum = 0;
            // Update week info
            // This line requires lblWeekInfo to be initialized and added to the Form
            lblWeekInfo.Text =
                $"Week: {GetStartOfWeek(weekDate):dd/MM} → " +
                $"{GetEndOfWeek(weekDate):dd/MM}   |   Total revenue: {total:N0} VND";
        }
        private void LoadWeeklyStatistics()
        {
            DrawWeeklyChart(currentWeek);
            LoadTopEmployees(currentWeek);
        }
        private void btnRefresh_Statistics_Click(object sender, EventArgs e)
        {
            // lblWeekInfo already initialized in constructor
                LoadWeeklyStatistics();
        }
        private void chartRevenue_Click(object sender, EventArgs e) { }
        private void listTop_Employee_Statistics_SelectedIndexChanged(object sender, EventArgs e) { }
        private void RevenueChart_Click(object sender, EventArgs e) { }
        private void btnExport_Excel_Statiscs_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel File (*.xlsx)|*.xlsx";
                sfd.Title = "Export All Orders";
                if (sfd.ShowDialog() != DialogResult.OK)
                    return;
                using (ExcelPackage pkg = new ExcelPackage())
                {   
                    //  SHEET 1: ALL ORDERS
                    DataTable dtOrders = new DataTable();
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string sql = @"
                    SELECT 
                        O.OrderID,
                        O.OrderDate,
                        C.CustomerName,
                        E.EmployeeName,
                        PM.MethodName AS PaymentMethod,
                        O.TotalAmount
                    FROM [Order] O
                    JOIN Customer C ON O.CustomerID = C.CustomerID
                    JOIN Employee E ON O.EmployeeID = E.EmployeeID
                    JOIN PaymentMethod PM ON O.PaymentMethodID = PM.PaymentMethodID
                    ORDER BY O.OrderID ASC";

                        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                        da.Fill(dtOrders);
                    }
                    ExcelWorksheet ws1 = pkg.Workbook.Worksheets.Add("All Orders");
                    ws1.Cells["A1"].LoadFromDataTable(dtOrders, true);
                    ws1.Cells[ws1.Dimension.Address].AutoFitColumns();
                    //  SHEET 2: ALL ORDER DETAILS + EMPLOYEE NAME/
                    DataTable dtDetails = new DataTable();
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string sql = @"
                    SELECT 
                        OD.OrderDetailID,
                        OD.OrderID,
                        P.ProductName,
                        OD.Quantity,
                        OD.UnitPrice,
                        (OD.UnitPrice * OD.Quantity) AS LineTotal,
                        E.EmployeeName
                    FROM Order_Details OD
                    JOIN Product P ON OD.ProductID = P.ProductID
                    JOIN [Order] O ON OD.OrderID = O.OrderID
                    JOIN Employee E ON O.EmployeeID = E.EmployeeID
                    ORDER BY OD.OrderDetailID ASC";

                        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                        da.Fill(dtDetails);
                    }

                    ExcelWorksheet ws2 = pkg.Workbook.Worksheets.Add("Order Details");
                    ws2.Cells["A1"].LoadFromDataTable(dtDetails, true);
                    ws2.Cells[ws2.Dimension.Address].AutoFitColumns();
                    //  SAVE FILE
                    pkg.SaveAs(new FileInfo(sfd.FileName));
                }
                MessageBox.Show("Excel exported successfully!", "SUCCESS", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting Excel: " + ex.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThis_week_Click(object sender, EventArgs e)
        {
            currentWeek = DateTime.Now;
            LoadWeeklyStatistics();
        }
        private void btnPrev_Week_Click(object sender, EventArgs e)
        {
            currentWeek = currentWeek.AddDays(-7);
            LoadWeeklyStatistics();
        }
        private void lblWeekInfo_Click(object sender, EventArgs e) {}
    }
}


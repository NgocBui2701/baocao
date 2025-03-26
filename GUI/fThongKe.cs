using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using baocao.BLL;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fThongKe : DarkModeForm
    {
        private DonHangBLL donHangBLL;
        private ComboBox cboQuy, cboNam;
        private Chart chartQuy;
        private Chart chartDot;

        public fThongKe()
        {
            InitializeComponent();
            splitContainerBody.SplitterDistance = this.Width / 2;
            donHangBLL = new DonHangBLL();
            LoadYears();
            this.Load += fThongKe_Load;
            ApplyDarkMode(DarkModeManager.IsDarkMode);
        }

        private void fThongKe_Load(object sender, EventArgs e)
        {
            if (cboNam.Items.Count > 0 && cboQuy.Items.Count > 0)
            {
                LoadChartData(int.Parse(cboQuy.SelectedItem.ToString()), int.Parse(cboNam.SelectedItem.ToString()));
            }
            if (cboNam2.Items.Count > 0 && cboDot.Items.Count > 0)
            {
                LoadChartDataByDot(int.Parse(cboDot.SelectedItem.ToString()), int.Parse(cboNam2.SelectedItem.ToString()));
            }
        }
        private void LoadYears()
        {
            DataTable dtYears = donHangBLL.GetYears();
            foreach (DataRow row in dtYears.Rows)
            {
                cboNam.Items.Add(row["Year"]);
                cboNam2.Items.Add(row["Year"]);
            }
            if (cboNam.Items.Count > 0)
            {
                cboQuy.SelectedIndex = 0;
                cboNam.SelectedIndex = 0;
            }
            if (cboNam2.Items.Count > 0)
            {
                cboDot.SelectedIndex = 0;
                cboNam2.SelectedIndex = 0;
            }
        }

        private void CboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNam.SelectedItem != null && cboQuy.SelectedItem != null)
            {
                int selectedQuy = int.Parse(cboQuy.SelectedItem.ToString());
                int selectedNam = int.Parse(cboNam.SelectedItem.ToString());
                LoadChartData(selectedQuy, selectedNam);
            }
            if (cboNam2.SelectedItem != null && cboDot.SelectedItem != null)
            {
                int selectedDot = int.Parse(cboDot.SelectedItem.ToString());
                int selectedNam2 = int.Parse(cboNam2.SelectedItem.ToString());
                LoadChartDataByDot(selectedDot, selectedNam2);
            }
        }


        private void LoadChartData(int quy, int nam)
        {
            if (chartQuy != null)
            {
                chartQuy.Series.Clear();
                chartQuy.ChartAreas.Clear();
                chartQuy.Legends.Clear();
            }
            chartQuy.Titles[0].ForeColor = this.ForeColor;
            ChartArea chartArea = new ChartArea()
            {
                BackColor = Color.Transparent
            };
            chartQuy.ChartAreas.Add(chartArea);
            Legend legend = new Legend()
            {
                Docking = Docking.Right,
                Alignment = StringAlignment.Center,
                BackColor = Color.Transparent,
                ForeColor = this.ForeColor
            };
            chartQuy.Legends.Add(legend);
            Series series = new Series()
            {
                ChartType = SeriesChartType.Pie,
                Name = "OrderStatus"
            };
            chartQuy.Series.Add(series);

            DataTable dt = donHangBLL.GetOrderStatusCounts(quy, nam);
            int totalOrders = dt.AsEnumerable().Sum(row => row.Field<int>("SoLuong"));
            foreach (DataRow row in dt.Rows)
            {
                string status = row["trang_thai"].ToString();
                int count = Convert.ToInt32(row["SoLuong"]);
                int pointIndex = series.Points.AddY(count);
                series.Points[pointIndex].Label = $"{(double)count / totalOrders * 100: 0.0}%";
                series.Points[pointIndex].Font = new Font("Segoe UI", 14, FontStyle.Bold);
                series.Points[pointIndex].LabelForeColor = this.ForeColor;
                series.Points[pointIndex].LegendText = status + " - " + count;

                switch (status)
                {
                    case "Đang xử lý":
                        series.Points[pointIndex].Color = Color.FromArgb(244, 192, 30);
                        break;
                    case "Hoàn thành":
                        series.Points[pointIndex].Color = Color.FromArgb(7, 198, 56);
                        break;
                    case "Quá hạn":
                        series.Points[pointIndex].Color = Color.FromArgb(232, 1, 7);
                        break;
                }
            }
        }
        private void LoadChartDataByDot(int dot, int nam)
        {
            if (chartDot != null)
            {
                chartDot.Series.Clear();
                chartDot.ChartAreas.Clear();
                chartDot.Legends.Clear();
            }
            chartDot.Titles[0].ForeColor = this.ForeColor;
            ChartArea chartArea = new ChartArea()
            {
                BackColor = Color.Transparent
            };
            chartDot.ChartAreas.Add(chartArea);
            Legend legend = new Legend()
            {
                Docking = Docking.Right,
                Alignment = StringAlignment.Center,
                BackColor = Color.Transparent,
                ForeColor = this.ForeColor
            };
            chartDot.Legends.Add(legend);
            Series series = new Series()
            {
                ChartType = SeriesChartType.Pie,
                Name = "OrderStatus"
            };
            chartDot.Series.Add(series);
            DataTable dt = donHangBLL.GetOrderStatucCountsByDot(dot, nam);
            int totalOrders = dt.AsEnumerable().Sum(row => row.Field<int>("SoLuong"));
            foreach (DataRow row in dt.Rows)
            {
                string status = row["trang_thai"].ToString();
                int count = Convert.ToInt32(row["SoLuong"]);
                int pointIndex = series.Points.AddY(count);
                series.Points[pointIndex].Label = $"{(double)count / totalOrders * 100: 0.0}%";
                series.Points[pointIndex].Font = new Font("Segoe UI", 14, FontStyle.Bold);
                series.Points[pointIndex].LabelForeColor = this.ForeColor;
                series.Points[pointIndex].LegendText = status + " - " + count;
                switch (status)
                {
                    case "Đang xử lý":
                        series.Points[pointIndex].Color = Color.FromArgb(244, 192, 30);
                        break;
                    case "Hoàn thành":
                        series.Points[pointIndex].Color = Color.FromArgb(7, 198, 56);
                        break;
                    case "Quá hạn":
                        series.Points[pointIndex].Color = Color.FromArgb(232, 1, 7);
                        break;
                }
            }
        }
        protected override void ApplyDarkMode(bool darkMode)
        {
            base.ApplyDarkMode(darkMode);
            if (chartQuy != null && chartDot != null)
            {
                chartQuy.BackColor = this.BackColor;
                chartDot.BackColor = this.BackColor;
                chartQuy.ForeColor = this.ForeColor;
                chartDot.ForeColor = this.ForeColor;
            }
        }
        private void ChartQuy_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = chartQuy.HitTest(e.X, e.Y);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int pointIndex = result.PointIndex;
                string status = chartQuy.Series["OrderStatus"].Points[pointIndex].LegendText.Split('-')[0].Trim();

                int selectedQuy = int.Parse(cboQuy.SelectedItem.ToString());
                int selectedNam = int.Parse(cboNam.SelectedItem.ToString());

                ShowOrderDetails(status, selectedQuy, selectedNam, true);
            }
        }
        private void ChartDot_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = chartDot.HitTest(e.X, e.Y);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int pointIndex = result.PointIndex;
                string status = chartDot.Series["OrderStatus"].Points[pointIndex].LegendText.Split('-')[0].Trim();

                int selectedDot = int.Parse(cboDot.SelectedItem.ToString());
                int selectedNam = int.Parse(cboNam2.SelectedItem.ToString());

                ShowOrderDetails(status, selectedDot, selectedNam, false);
            }
        }
        private void ShowOrderDetails(string status, int timeValue, int year, bool isQuy)
        {
            DataTable dt;

            if (isQuy)
                dt = donHangBLL.GetOrderListByStatusAndQuy(status, timeValue, year);
            else
                dt = donHangBLL.GetOrderListByStatusAndDot(status, timeValue, year);

            if (dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Danh sách đơn hàng có trạng thái '{status}':\n");
                foreach (DataRow row in dt.Rows)
                {
                    sb.AppendLine($"Mã đơn hàng: {row["ma_don_hang"]}");
                }
                MessageBox.Show(sb.ToString(), "Chi tiết đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có đơn hàng nào ở trạng thái này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fThongKe_ForeColorChanged(object sender, EventArgs e)
        {
            LoadChartData(int.Parse(cboQuy.SelectedItem.ToString()), int.Parse(cboNam.SelectedItem.ToString()));
            LoadChartDataByDot(int.Parse(cboDot.SelectedItem.ToString()), int.Parse(cboNam2.SelectedItem.ToString()));
        }

        private void splitContainerBody_SizeChanged(object sender, EventArgs e)
        {
            splitContainerBody.SplitterDistance = this.Width / 2;
        }
    }
}

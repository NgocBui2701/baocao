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
        private LanguageManager langManager = LanguageManager.Instance;
        private DonHangBLL donHangBLL;
        private ComboBox cboQuy, cboNam;
        private Chart chartQuy; 

        public fThongKe()
        {
            InitializeComponent();
            donHangBLL = new DonHangBLL();
            LoadYears();
            this.Load += fThongKe_Load;
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            langManager.LanguageChanged += LangManager_LanguageChanged;
            UpdateLanguageTexts();
        } //4/5/2025
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            langManager.LanguageChanged -= LangManager_LanguageChanged;
        }
        private void LangManager_LanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }
        private void UpdateLanguageTexts()
        {
            this.Text = langManager.Translate("statistics_form_title");
            chartQuy.Titles[0].Text = langManager.Translate("quarterly_order_status_chart");
            if (cboNam.SelectedItem != null && cboQuy.SelectedItem != null)
            {
                int selectedYear, selectedQuarter;
                if (int.TryParse(cboNam.SelectedItem.ToString(), out selectedYear) && int.TryParse(cboQuy.SelectedItem.ToString(), out selectedQuarter))
                {
                    LoadChartData(selectedQuarter, selectedYear);
                }
            }
        }
        private void fThongKe_Load(object sender, EventArgs e)
        {
            if (cboNam.Items.Count > 0 && cboQuy.Items.Count > 0)
            {
                LoadChartData(int.Parse(cboQuy.SelectedItem.ToString()), int.Parse(cboNam.SelectedItem.ToString()));
            }
        }
        private void LoadYears()
        {
            DataTable dtYears = donHangBLL.GetYears();
            foreach (DataRow row in dtYears.Rows)
            {
                cboNam.Items.Add(row["Year"]);
            }
            if (cboNam.Items.Count > 0)
            {
                cboQuy.SelectedIndex = 0;
                cboNam.SelectedIndex = 0;
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
            Dictionary<string, string> statusTranslations = new Dictionary<string, string>
            {
                { "Đang xử lý", langManager.Translate("in_progress") },
                { "Hoàn thành", langManager.Translate("completed") },
                { "Quá hạn", langManager.Translate("overdue") }
            };
            foreach (DataRow row in dt.Rows)
            {
                string statusVietnamese = row["trang_thai"].ToString();
                string statusEnglish = statusTranslations.ContainsKey(statusVietnamese) ? statusTranslations[statusVietnamese] : statusVietnamese;
                int count = Convert.ToInt32(row["SoLuong"]);
                int pointIndex = series.Points.AddY(count);
                series.Points[pointIndex].Tag = statusVietnamese;

                series.Points[pointIndex].Label = $"{(double)count / totalOrders * 100:0.0}%";
                series.Points[pointIndex].Font = new Font("Segoe UI", 14, FontStyle.Bold);
                series.Points[pointIndex].LabelForeColor = this.ForeColor;
                series.Points[pointIndex].LegendText = $"{statusEnglish} - {count}";

                switch (statusVietnamese)
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
            if (chartQuy != null)
            {
                chartQuy.BackColor = this.BackColor;
                chartQuy.ForeColor = this.ForeColor;
            }
        }
        private void ChartQuy_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = chartQuy.HitTest(e.X, e.Y);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int pointIndex = result.PointIndex;
                //string status = chartQuy.Series["OrderStatus"].Points[pointIndex].LegendText.Split('-')[0].Trim();
                string status = chartQuy.Series["OrderStatus"].Points[pointIndex].Tag.ToString(); //4/5/2025
                int selectedQuy = int.Parse(cboQuy.SelectedItem.ToString());
                int selectedNam = int.Parse(cboNam.SelectedItem.ToString());

                ShowOrderDetails(status, selectedQuy, selectedNam, true);
            }
        }
        private void ShowOrderDetails(string status, int timeValue, int year, bool isQuy)
        {
            DataTable dt;

            dt = donHangBLL.GetOrderListByStatusAndQuy(status, timeValue, year);
            //4/5/2025
            Dictionary<string, string> statusTranslations = new Dictionary<string, string>
            {
                { "Đang xử lý", langManager.Translate("in_progress") },
                { "Hoàn thành", langManager.Translate("completed") },
                { "Quá hạn", langManager.Translate("overdue") }
            };
            string statusEnglish = statusTranslations.ContainsKey(status) ? statusTranslations[status] : status; //
            //if (dt.Rows.Count > 0)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine($"Danh sách đơn hàng có trạng thái '{status}':\n");
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        sb.AppendLine($"Mã đơn hàng: {row["ma_don_hang"]}");
            //    }
            //    MessageBox.Show(sb.ToString(), "Chi tiết đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Không có đơn hàng nào ở trạng thái này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            if (dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format(LanguageManager.Instance.Translate("order_list_status"), statusEnglish));

                foreach (DataRow row in dt.Rows)
                {
                    sb.AppendLine(string.Format(LanguageManager.Instance.Translate("order_id"), row["ma_don_hang"]));
                }

                MessageBox.Show(
                    sb.ToString(),
                    LanguageManager.Instance.Translate("order_details"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    LanguageManager.Instance.Translate("no_orders_in_status"),
                    LanguageManager.Instance.Translate("notification"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void fThongKe_ForeColorChanged(object sender, EventArgs e)
        {
            LoadChartData(int.Parse(cboQuy.SelectedItem.ToString()), int.Parse(cboNam.SelectedItem.ToString()));
        }
    }
}

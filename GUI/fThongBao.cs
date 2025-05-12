using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fThongBao : DarkModeForm
    {
        private List<ThongBao> notifications = new List<ThongBao>();
        // Lưu trạng thái đã đọc vĩnh viễn: dùng user setting để lưu danh sách mã đơn hàng đã đọc
        public static Dictionary<string, bool> readStatus = new Dictionary<string, bool>();

        public fThongBao()
        {
            InitializeComponent();
            // Load trạng thái đã đọc từ user settings
            LoadReadStatusFromSettings();
            // Giả sử trên form có một Panel tên panelNotifications
            LoadNotifications();
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            panelNotifications.BackColor = DarkModeManager.GetBackgroundColor();
            panelNotifications.ForeColor = DarkModeManager.GetForeColor();
        }

        private void LoadNotifications()
        {
            notifications.Clear();
            List<DonHang> orders = DonHangBLL.Instance.LoadData();
            DateTime now = DateTime.Now;

            foreach (var order in orders)
            {
                // Yêu cầu: nếu đơn hàng đã hoàn thành thì không tạo thông báo nào.
                if (order.Trangthai == "Hoàn thành")
                    continue;

                // Nếu ngày trả kết quả dự kiến là hôm nay và đơn hàng chưa hoàn thành
                if (order.NgayKQ.Date == now.Date)
                {
                    ThongBao notif = new ThongBao
                    {
                        OrderId = order.MaDH,
                        Message = $"Đơn hàng {order.MaDH} đến hạn trả kết quả hôm nay (ngày {order.NgayKQ:dd/MM/yyyy})",
                        IsRead = false
                    };
                    notifications.Add(notif);
                }
                // Nếu ngày trả kết quả dự kiến ở tương lai
                else if (now < order.NgayKQ)
                {
                    double daysDiff = (order.NgayKQ - now).TotalDays;
                    int intDays = (int)Math.Ceiling(daysDiff);
                    // Chỉ thông báo sắp đến hạn nếu số ngày còn lại là 4 hoặc 2 (và nằm trong khoảng 1 đến 4 ngày)
                    if (daysDiff >= 1 && daysDiff <= 4 && (intDays == 4 || intDays == 2))
                    {
                        ThongBao notif = new ThongBao
                        {
                            OrderId = order.MaDH,
                            Message = $"Đơn hàng {order.MaDH} sắp đến hạn trả kết quả ({order.NgayKQ:dd/MM/yyyy}): còn {intDays} ngày",
                            IsRead = false
                        };
                        notifications.Add(notif);
                    }
                }
                // Nếu ngày trả kết quả dự kiến ở quá khứ
                else if (now > order.NgayKQ)
                {
                    double overdueDays = (now - order.NgayKQ).TotalDays;
                    int intOverdue = (int)Math.Ceiling(overdueDays);
                    // Chỉ thông báo quá hạn nếu quá 1 đến 3 ngày
                    if (overdueDays >= 1 && overdueDays <= 3)
                    {
                        ThongBao notif = new ThongBao
                        {
                            OrderId = order.MaDH,
                            Message = $"Đơn hàng {order.MaDH} đã quá hạn: {intOverdue} ngày so với ngày trả kết quả dự kiến ({order.NgayKQ:dd/MM/yyyy})",
                            IsRead = false
                        };
                        notifications.Add(notif);
                    }
                }
            }

            // Cập nhật trạng thái đã đọc từ dictionary
            foreach (var notif in notifications)
            {
                if (readStatus.TryGetValue(notif.OrderId, out bool wasRead) && wasRead)
                {
                    notif.IsRead = true;
                }
            }

            // Xóa tất cả các label cũ trong panel
            panelNotifications.Controls.Clear();

            // Nếu không có thông báo nào, hiển thị 1 label thông báo
            if (notifications.Count == 0)
            {
                Label lblNoNotif = new Label();
                lblNoNotif.Text = "Không có thông báo nào.";
                lblNoNotif.ForeColor = Color.Gray;
                lblNoNotif.AutoSize = true;
                panelNotifications.Controls.Add(lblNoNotif);
            }
            else
            {
                int topPos = 10;
                foreach (var notif in notifications)
                {
                    Label lbl = new Label();
                    lbl.Text = notif.Message;
                    lbl.AutoSize = false;
                    lbl.Width = panelNotifications.Width - 20;
                    lbl.Height = 30;
                    lbl.Top = topPos;
                    lbl.Left = 10;
                    lbl.Tag = notif;
                    if (notif.IsRead)
                    {
                        lbl.Font = new Font(this.Font, FontStyle.Regular);
                        lbl.ForeColor = Color.Gray;
                    }
                    else
                    {
                        lbl.Font = new Font(this.Font, FontStyle.Bold);
                        lbl.ForeColor = Color.Black;
                    }
                    lbl.Click += lbl_Click;

                    panelNotifications.Controls.Add(lbl);
                    topPos += lbl.Height + 5;
                }
            }
        }
        private void fThongBao_Clickoutside(object sender, EventArgs e)
        {
            // Đóng form khi click ra ngoài
            this.Hide();
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null && lbl.Tag is ThongBao notif)
            {
                // Đánh dấu thông báo đã đọc và lưu trạng thái
                notif.IsRead = true;
                readStatus[notif.OrderId] = true;
                lbl.Font = new Font(lbl.Font, FontStyle.Regular);
                lbl.ForeColor = Color.Gray;
                // Lưu trạng thái vào cài đặt người dùng
                SaveReadStatusToSettings();

                // Mở form fMain và gọi phương thức mở đơn hàng tương ứng
                fMain main = Application.OpenForms.OfType<fMain>().FirstOrDefault();
                if (main != null && main.IsHandleCreated)
                {
                    main.OpenDonHangWithNotification(notif.OrderId);
                }
                this.Hide();
            }
        }

        private void SaveReadStatusToSettings()
        {
            // Lưu danh sách các OrderId đã đọc dưới dạng chuỗi phân cách bằng dấu phẩy
            var readIds = readStatus.Where(kv => kv.Value).Select(kv => kv.Key);
            Properties.Settings.Default.ReadNotificationIDs = string.Join(",", readIds);
            Properties.Settings.Default.Save();
        }

        private void LoadReadStatusFromSettings()
        {
            readStatus.Clear();
            string saved = Properties.Settings.Default.ReadNotificationIDs;
            if (!string.IsNullOrEmpty(saved))
            {
                string[] ids = saved.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var id in ids)
                {
                    if (!readStatus.ContainsKey(id))
                    {
                        readStatus[id] = true;
                    }
                }
            }
        }
    }
}

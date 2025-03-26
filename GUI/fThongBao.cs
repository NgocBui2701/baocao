using baocao.BLL;
using baocao.DTO;

namespace baocao.GUI
{
    public partial class fThongBao : Form
    {
        private List<ThongBao> notifications = new List<ThongBao>();
        public static Dictionary<string, bool> readStatus = new Dictionary<string, bool>(); // Lưu trạng thái đã đọc vĩnh viễn

        public fThongBao()
        {
            InitializeComponent();
            listViewNotifications.ItemActivate += listViewNotifications_ItemActivate;
            LoadNotifications();
        }

        private void LoadNotifications()
        {
            notifications.Clear();
            List<DonHang> orders = DonHangBLL.Instance.LoadData();
            DateTime now = DateTime.Now;

            foreach (var order in orders)
            {
                DateTime expectedDate = order.NgayKQ;
                double daysDiff = (expectedDate - now).TotalDays;

                // Thông báo đơn hàng sắp đến hạn
                if (daysDiff >= 1 && daysDiff <= 4)
                {
                    int intDays = (int)Math.Ceiling(daysDiff);
                    if (intDays == 4 || intDays == 2) // Chỉ thông báo khi còn 4 hoặc 2 ngày
                    {
                        ThongBao notif = new ThongBao
                        {
                            OrderId = order.MaDH,
                            Message = $"Đơn hàng {order.MaDH} sắp đến hạn: còn lại {intDays} ngày",
                            IsRead = false
                        };
                        notifications.Add(notif);
                    }
                }
                // Thông báo đơn hàng đã quá hạn
                else if (now > expectedDate)
                {
                    int overdueDays = (int)(now - expectedDate).TotalDays;
                    if (overdueDays >= 1 && overdueDays <= 3) // Chỉ thông báo trong 3 ngày quá hạn
                    {
                        ThongBao notif = new ThongBao
                        {
                            OrderId = order.MaDH,
                            Message = $"Đơn hàng {order.MaDH} đã quá hạn: {overdueDays} ngày",
                            IsRead = false
                        };
                        notifications.Add(notif);
                    }
                }
            }

            // Cập nhật trạng thái đã đọc từ dictionary tĩnh
            foreach (var notif in notifications)
            {
                if (readStatus.TryGetValue(notif.OrderId, out bool wasRead) && wasRead)
                {
                    notif.IsRead = true;
                }
            }

            // Thiết lập giao diện ListView
            listViewNotifications.Items.Clear();
            listViewNotifications.View = View.Details;
            listViewNotifications.HeaderStyle = ColumnHeaderStyle.None;
            listViewNotifications.Columns.Clear();
            listViewNotifications.Columns.Add("", 1000); // Độ rộng cột
            listViewNotifications.FullRowSelect = true;

            // Hiển thị thông báo
            if (notifications.Count == 0)
            {
                ListViewItem item = new ListViewItem("Không có thông báo nào.");
                item.ForeColor = Color.Gray;
                listViewNotifications.Items.Add(item);
            }
            else
            {
                foreach (var notif in notifications)
                {
                    ListViewItem item = new ListViewItem(notif.Message)
                    {
                        Tag = notif,
                        Font = notif.IsRead ? new Font(listViewNotifications.Font, FontStyle.Regular) : new Font(listViewNotifications.Font, FontStyle.Bold),
                        ForeColor = notif.IsRead ? Color.Gray : Color.Black
                    };
                    listViewNotifications.Items.Add(item);
                }
            }

            listViewNotifications.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void listViewNotifications_ItemActivate(object sender, EventArgs e)
        {
            if (listViewNotifications.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewNotifications.SelectedItems[0];
                ThongBao notif = item.Tag as ThongBao;
                if (notif != null)
                {
                    notif.IsRead = true;
                    readStatus[notif.OrderId] = true; // Lưu trạng thái đã đọc vĩnh viễn
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    item.ForeColor = Color.Gray;

                    // Mở form đơn hàng tương ứng

                    fMain main = Application.OpenForms.OfType<fMain>().FirstOrDefault();
                    if (main != null && main.IsHandleCreated)
                    {
                        main.OpenDonHangWithNotification(notif.OrderId);
                    }
                    this.Hide();
                }
            }
        }
    }
}

using System.Data;
using baocao.BLL;
using baocao.DTO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using baocao.GUI.Managers;
using baocao.GUI.BaseForm;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace baocao.GUI
{
    public partial class fThongSoMoiTruong : DarkModeForm
    {
        private LanguageManager langManager = LanguageManager.Instance; /////////////////////////////////////////////
        private DonHang _donHang;
        public string loaiViTri;
        private Dictionary<string, bool> _isEditingTabs = new Dictionary<string, bool>();
        private int _lastTabIndex = -1;
        private Dictionary<string, List<ThongSo>> _originalData = new Dictionary<string, List<ThongSo>>();
        public fThongSoMoiTruong(DonHang donHang, string loaiViTri)
        {
            InitializeComponent();
            //UpdateLanguage();
            //LanguageManager.LanguageChanged += OnLanguageChanged;
            this._donHang = donHang;
            this.loaiViTri = loaiViTri;
           
            this.Load += fThongSoMoiTruong_Load; ////////////
            btnExport.Visible = (_donHang.Trangthai == "Hoàn thành" && PermissionManager.HasPermission(PermissionManager.Permissions.ManageReports));
            btnAddVT.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManageTSMT);
            btnDelVT.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManageTSMT);
            btnInsertTS.Visible = false;
            btnDelTS.Visible = false;
            btnEdit.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManageTSMT) || PermissionManager.HasPermission(PermissionManager.Permissions.ManageResults_HT) || PermissionManager.HasPermission(PermissionManager.Permissions.ManageResults_PTN);

            List<ViTriLayMau> danhSachViTriHD = ViTriBLL.Instance.GetViTriByMaHD(_donHang.MaHD);
            List<ViTriLayMau> danhSachViTriDH = ViTriBLL.Instance.GetViTriByMaDH(_donHang.MaDH);
            tabctrlTSMT.SelectedIndexChanged += tabctrlTSMT_SelectedIndexChanged;
            tabctrlTSMT.DrawItem += new DrawItemEventHandler(TabControl_DrawItem);
            bool found = false;

            if (danhSachViTriDH.Count > 0)
            {
                foreach (var viTri in danhSachViTriDH)
                {
                    if (viTri.LoaiViTri == loaiViTri)
                    {
                        AddTabForExistingViTri(viTri, _donHang.MaDH);
                        found = true;
                    }
                }
            }
            if (!found && danhSachViTriHD.Count > 0)
            {
                foreach (var viTri in danhSachViTriHD)
                {
                    if (viTri.LoaiViTri == loaiViTri)
                    {
                        AddTabForExistingViTri(viTri);
                    }
                }
            }
            EnsureAllTabsHaveDataGridView();
            if (tabctrlTSMT.SelectedTab != null)
            {
                labelTenVT.Text = tabctrlTSMT.SelectedTab.Tag.ToString();
            }
            langManager.LanguageChanged += LangManager_LanguageChanged; /////////////////////////////////////////
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            //Back Color
            panelTitle.BackColor = DarkModeManager.GetForeColor();
            labelTenVT.BackColor = panelTitle.BackColor;
            btnAddVT.BackColor = panelTitle.BackColor;
            btnDelVT.BackColor = panelTitle.BackColor;
            btnEdit.BackColor = panelTitle.BackColor;
            btnExport.BackColor = panelTitle.BackColor;
            //Fore Color
            labelTenVT.ForeColor = DarkModeManager.GetBackgroundColor();
            //Icon Color
            btnAddVT.IconColor = DarkModeManager.GetBackgroundColor();
            btnDelVT.IconColor = DarkModeManager.GetBackgroundColor();
            btnEdit.IconColor = DarkModeManager.GetBackgroundColor();
            btnExport.IconColor = DarkModeManager.GetBackgroundColor();

        }

        private void fThongSoMoiTruong_Load(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }

        private void LangManager_LanguageChanged(object sender, EventArgs e) /////////////////////////////////
        {
            UpdateLanguageTexts();
        }

        private void UpdateLanguageTexts()
        {
            btnDelTS.Text = LanguageManager.Instance.Translate("DelTS");
            btnInsertTS.Text = LanguageManager.Instance.Translate("InsertTS");

            this.Text = LanguageManager.Instance.Translate("thong_so_title");


            // Cập nhật tiêu đề cột cho tất cả các DataGridView trong các TabPage
            foreach (TabPage tab in tabctrlTSMT.TabPages)
            {
                foreach (Control ctrl in tab.Controls)
                {
                    if (ctrl is Guna.UI2.WinForms.Guna2DataGridView dgv)
                    {
                        if (dgv.Columns.Contains("STT"))
                            dgv.Columns["STT"].HeaderText = LanguageManager.Instance.Translate("serial_number");
                        if (dgv.Columns.Contains("MaTS"))
                            dgv.Columns["MaTS"].HeaderText = LanguageManager.Instance.Translate("parameter_code");
                        if (dgv.Columns.Contains("TenTS"))
                            dgv.Columns["TenTS"].HeaderText = LanguageManager.Instance.Translate("parameter_name");
                        if (dgv.Columns.Contains("DonVi"))
                            dgv.Columns["DonVi"].HeaderText = LanguageManager.Instance.Translate("unit");
                        if (dgv.Columns.Contains("KetQua"))
                            dgv.Columns["KetQua"].HeaderText = LanguageManager.Instance.Translate("result");
                        if (dgv.Columns.Contains("KetQuaTruoc"))
                            dgv.Columns["KetQuaTruoc"].HeaderText = LanguageManager.Instance.Translate("previous_result");
                        if (dgv.Columns.Contains("AnLanQuanTrac"))
                            dgv.Columns["AnLanQuanTrac"].HeaderText = LanguageManager.Instance.Translate("hide_inspection");
                        if (dgv.Columns.Contains("Loai"))
                            dgv.Columns["Loai"].HeaderText = LanguageManager.Instance.Translate("type");
                        if (dgv.Columns.Contains("NguoiPhanTich"))
                            dgv.Columns["NguoiPhanTich"].HeaderText = LanguageManager.Instance.Translate("analyst");
                        if (dgv.Columns.Contains("GiaTriQuyChuanTCVN"))
                            dgv.Columns["GiaTriQuyChuanTCVN"].HeaderText = LanguageManager.Instance.Translate("standard_value");
                        if (dgv.Columns.Contains("KetLuan"))
                            dgv.Columns["KetLuan"].HeaderText = LanguageManager.Instance.Translate("conclusion");

                        dgv.Refresh();
                    }
                }
            }
        }

        protected virtual void OnLanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)//////////////////////////////
        {
            base.OnFormClosing(e);
            langManager.LanguageChanged -= LangManager_LanguageChanged;
        }
        #region Method
        private List<string> SplitTextIntoLines(string text, XFont font, XGraphics gfx, double maxWidth)
        {
            var words = text.Split(' ');
            var lines = new List<string>();
            string currentLine = "";

            foreach (var word in words)
            {
                string testLine = currentLine + (currentLine.Length > 0 ? " " : "") + word;
                if (gfx.MeasureString(testLine, font).Width <= maxWidth)
                    currentLine = testLine;
                else
                {
                    if (currentLine.Length > 0)
                        lines.Add(currentLine);
                    currentLine = word;
                }
            }
            if (currentLine.Length > 0)
                lines.Add(currentLine);

            return lines;
        }
        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = sender as TabControl;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = tab.GetTabRect(e.Index);
            bool isSelected = (e.Index == tab.SelectedIndex);
            

            Font font = new Font("Segoe UI", 10, FontStyle.Bold);
            Color backColor = isSelected ? DarkModeManager.GetForeColor() : DarkModeManager.GetBackgroundColor();
            Color textColor = isSelected ? DarkModeManager.GetForeColor() : DarkModeManager.GetForeColor();
            TextRenderer.DrawText(g, tab.TabPages[e.Index].Text, font, rect, textColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void AddNewTabPage()
        {
            int maxIndex = 0;
            string prefix = GetPrefix(loaiViTri);
            foreach (TabPage tab in tabctrlTSMT.TabPages)
            {
                if (tab.Text.StartsWith(prefix))
                {
                    string numberPart = tab.Text.Substring(prefix.Length);
                    if (int.TryParse(numberPart, out int num))
                    {
                        maxIndex = Math.Max(maxIndex, num);
                    }
                }
            }

            string tabTitle = prefix + (maxIndex + 1);
            bool success = ViTriBLL.Instance.AddViTri(tabTitle, _donHang.MaHD, _donHang.MaDH, tabTitle, loaiViTri);
            if (!success)
            {
                MessageBox.Show("Thêm vị trí thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TabPage newTab = new TabPage()
            {
                Text = tabTitle,
                Tag = tabTitle,
                BackColor = DarkModeManager.GetForeColor(),
                ForeColor = DarkModeManager.GetBackgroundColor()
            };
            Guna.UI2.WinForms.Guna2DataGridView dgv = CreateDataGridView();
            newTab.Controls.Add(dgv);
            tabctrlTSMT.TabPages.Add(newTab);
            tabctrlTSMT.SelectedTab = newTab;
            labelTenVT.Text = tabTitle;
            LoadDataForTab(dgv, tabTitle);
            UpdateLanguageTexts(); /////
        }
        private string GetPrefix(string loaiViTri)
        {
            return loaiViTri switch
            {
                "Đất" => "Đ",
                "Nước" => "N",
                "Không khí" => "KK",
                "Khí thải" => "KT",
                _ => "VT"
            };
        }
        private void AddTabForExistingViTri(ViTriLayMau viTri, string maDH = null)
        {
            TabPage newTab = new TabPage(viTri.MaViTri) { Tag = viTri.TenViTri };
            Guna.UI2.WinForms.Guna2DataGridView dgv = CreateDataGridView();
            newTab.Controls.Add(dgv);
            tabctrlTSMT.TabPages.Add(newTab);

            if (maDH != null)
            {
                LoadDataForTab(dgv, viTri.MaViTri, maDH);
            }
            else
            {
                if (!ViTriBLL.Instance.CheckViTriExists(viTri.MaViTri, _donHang.MaHD, _donHang.MaDH))
                {
                    bool success = ViTriBLL.Instance.AddViTri(viTri.MaViTri, _donHang.MaHD, _donHang.MaDH, viTri.TenViTri, loaiViTri);
                    if (!success)
                    {
                        MessageBox.Show("Thêm vị trí thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                LoadDataForTab(dgv, viTri.MaViTri);
            }
        }
        private void EnsureAllTabsHaveDataGridView()
        {
            foreach (TabPage tab in tabctrlTSMT.TabPages)
            {
                if (tab.Controls.Count == 0 || !(tab.Controls[0] is Guna.UI2.WinForms.Guna2DataGridView))
                {
                    Guna.UI2.WinForms.Guna2DataGridView dgv = CreateDataGridView();
                    tab.Controls.Add(dgv);
                    LoadDataForTab(dgv, tab.Tag.ToString());
                }
            }
        }
        private Guna.UI2.WinForms.Guna2DataGridView CreateDataGridView()
        {
            Guna.UI2.WinForms.Guna2DataGridView dgv = new Guna.UI2.WinForms.Guna2DataGridView
            {
                Dock = DockStyle.Fill,
                ThemeStyle = { BackColor = Color.White },
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                AllowUserToAddRows = false
            };
            dgv.ColumnHeadersDefaultCellStyle.BackColor = DarkModeManager.GetDark();
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = DarkModeManager.GetLight();
            return dgv;
        }
        private async void LoadDataForTab(Guna.UI2.WinForms.Guna2DataGridView dgv, string maVT, string maDH = null)
        {
            UpdateLanguageTexts(); //////////
            List<ThongSo> data;
            if (string.IsNullOrEmpty(maDH))
            {
                maDH = _donHang.MaDH;
                List<ThongSo> danhSachThongSo = ThongSoBLL.Instance.GetThongSoByLoaiViTri(loaiViTri);
                foreach (var thongSo in danhSachThongSo)
                {
                    KetQua ketQua = new KetQua
                    {
                        MaHopDong = _donHang.MaHD,
                        MaDonHang = maDH,
                        MaViTri = maVT,
                        MaThongSo = thongSo.MaTS,
                        KetQuaGiaTri = null,
                        AnLanQuanTrac = false,
                        Loai = null,
                        NguoiPhanTich = null,
                        KetLuan = null
                    };
                    ThongSoBLL.Instance.InsertKetQua(ketQua);
                }
            }
            int currentQuy = _donHang.Quy;
            data = await Task.Run(() => ThongSoBLL.Instance.GetCombinedThongSoByDieuKien(maVT, _donHang.MaHD, maDH, loaiViTri, currentQuy));
            if (dgv.InvokeRequired)
            {
                dgv.Invoke((MethodInvoker)(() => ApplyDataGridViewSettings(dgv, data)));
            }
            else
            {
                ApplyDataGridViewSettings(dgv, data);
            }
            UpdateLanguageTexts(); ////
        } 
        private void DelTabPage()
        {
            if (tabctrlTSMT.SelectedTab == null)
            {
                MessageBox.Show("Không có vị trí nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string maViTri = tabctrlTSMT.SelectedTab.Text;

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa vị trí '{maViTri}' không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = ViTriBLL.Instance.DeleteViTri(maViTri, _donHang.MaHD, _donHang.MaDH);

                    if (success)
                    {
                        tabctrlTSMT.TabPages.Remove(tabctrlTSMT.SelectedTab);
                        MessageBox.Show("Xóa vị trí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa vị trí thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ApplyDataGridViewSettings(Guna.UI2.WinForms.Guna2DataGridView dgv, List<ThongSo> data)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("MaTS", typeof(string));
            dt.Columns.Add("TenTS", typeof(string));
            dt.Columns.Add("DonVi", typeof(string));
            dt.Columns.Add("KetQua", typeof(string));
            dt.Columns.Add("KetQuaTruoc", typeof(string));
            dt.Columns.Add("AnLanQuanTrac", typeof(bool));
            dt.Columns.Add("Loai", typeof(string));
            dt.Columns.Add("NguoiPhanTich", typeof(string));
            dt.Columns.Add("GiaTriQuyChuanTCVN", typeof(string));
            dt.Columns.Add("KetLuan", typeof(string));
            foreach (var item in data)
            {
                dt.Rows.Add(null, item.MaTS, item.TenTS, item.DonVi, item.KetQua, item.KetQuaTruoc, item.AnLanQuanTrac, item.Loai, item.NguoiPhanTich, item.GiaTriQuyChuanTCVN, item.KetLuan);
            }
            dgv.DataSource = dt;
            dgv.ReadOnly = true;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
            if (dgv.Columns["MaTS"] != null) dgv.Columns["MaTS"].Visible = false;
            if (dgv.Columns["TenTS"] != null) dgv.Columns["TenTS"].HeaderText = "Tên Thông Số";
            if (dgv.Columns["DonVi"] != null) dgv.Columns["DonVi"].HeaderText = "Đơn Vị";
            if (dgv.Columns["KetQua"] != null)
            {
                dgv.Columns["KetQua"].HeaderText = "Kết Quả";
                dgv.Columns["KetQua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgv.Columns["KetQuaTruoc"] != null)
            {
                dgv.Columns["KetQuaTruoc"].HeaderText = "Kết Quả Quý Trước";
                dgv.Columns["KetQuaTruoc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgv.Columns["AnLanQuanTrac"] != null) dgv.Columns["AnLanQuanTrac"].HeaderText = "Ẩn lần quan trắc";
            if (dgv.Columns["Loai"] != null) dgv.Columns["Loai"].HeaderText = "Loại";
            if (dgv.Columns["NguoiPhanTich"] != null) dgv.Columns["NguoiPhanTich"].HeaderText = "Người Phân Tích";
            if (dgv.Columns["GiaTriQuyChuanTCVN"] != null)
            {
                dgv.Columns["GiaTriQuyChuanTCVN"].HeaderText = "Giá Trị Quy Chuẩn TCVN";
                dgv.Columns["GiaTriQuyChuanTCVN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgv.Columns["KetLuan"] != null)
            {
                dgv.Columns["KetLuan"].HeaderText = "Kết Luận";
                dgv.Columns["KetLuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dgv.Resize += (s, e) => AdjustKetLuanColumn(dgv);

            if (dgv.Columns["STT"] == null)
            {
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                {
                    Name = "STT",
                    HeaderText = "STT",
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dgv.Columns.Insert(0, sttColumn);
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["STT"] != null)
                {
                    row.Cells["STT"].Value = row.Index + 1;
                }
            }
            AdjustKetLuanColumn(dgv);
            dgv.CellFormatting += Dgv_CellFormatting;
        }
        void AdjustKetLuanColumn(Guna.UI2.WinForms.Guna2DataGridView dgv)
        {
            if (dgv.Columns["KetLuan"] != null)
            {
                int totalColumnWidth = 0;
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    totalColumnWidth += col.Width;
                }

                int remainingWidth = dgv.Width - totalColumnWidth - dgv.RowHeadersWidth;

                if (remainingWidth > 0)
                {
                    dgv.Columns["KetLuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    dgv.Columns["KetLuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
        private void Dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Guna.UI2.WinForms.Guna2DataGridView dgv = sender as Guna.UI2.WinForms.Guna2DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name == "Loai" && e.Value != null)
            {
                string loaiValue = e.Value.ToString();
                if (loaiValue == "HT")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (loaiValue == "p.TN")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
            }
        }
        private void UpdateViTri(string newName, string oldName)
        {
            if (string.IsNullOrWhiteSpace(newName) || newName == oldName)
                return;
            string maHD = _donHang.MaHD;
            string maDH = _donHang.MaDH;
            string maVT = tabctrlTSMT.SelectedTab.Text;

            bool success = ViTriBLL.Instance.UpdateTenViTri(maHD, maDH, maVT, newName);
            if (success)
            {
                labelTenVT.Text = newName;
                tabctrlTSMT.SelectedTab.Tag = newName;
            }
            else
            {
                MessageBox.Show("Cập nhật tên vị trí thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelTenVT.Text = oldName;
            }
        }
        private void ConvertColumnsToComboBox(Guna.UI2.WinForms.Guna2DataGridView dgv)
        {
            Dictionary<int, string> loaiValues = new Dictionary<int, string>();
            Dictionary<int, string> nguoiPhanTichValues = new Dictionary<int, string>();
            int loaiIndex = -1;
            int nguoiPhanTichIndex = -1;
            if (dgv.Columns["Loai"] != null)
                loaiIndex = dgv.Columns["Loai"].Index;
            if (dgv.Columns["NguoiPhanTich"] != null)
                nguoiPhanTichIndex = dgv.Columns["NguoiPhanTich"].Index;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Loai"].Value != null)
                    loaiValues[row.Index] = row.Cells["Loai"].Value.ToString();
                if (row.Cells["NguoiPhanTich"].Value != null)
                    nguoiPhanTichValues[row.Index] = row.Cells["NguoiPhanTich"].Value.ToString();
            }
            if (dgv.Columns["Loai"] != null)
                dgv.Columns.Remove("Loai");
            if (dgv.Columns["NguoiPhanTich"] != null)
                dgv.Columns.Remove("NguoiPhanTich");
            MessageBox.Show("Loai: "+loaiIndex+"Nguoiphantich: "+nguoiPhanTichIndex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataGridViewComboBoxColumn loaiColumn = new DataGridViewComboBoxColumn
            {
                Name = "Loai",
                HeaderText = "Loại",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            loaiColumn.Items.AddRange("HT", "p.TN");
            dgv.Columns.Insert(loaiIndex, loaiColumn);
            DataGridViewComboBoxColumn nguoiPhanTichColumn = new DataGridViewComboBoxColumn
            {
                Name = "NguoiPhanTich",
                HeaderText = "Người Phân Tích",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgv.Columns.Insert(nguoiPhanTichIndex, nguoiPhanTichColumn);
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (loaiValues.ContainsKey(row.Index) && loaiColumn.Items.Contains(loaiValues[row.Index]))
                {
                    row.Cells["Loai"].Value = loaiValues[row.Index];
                    UpdateNguoiPhanTichComboBox(row, loaiValues[row.Index]);
                }
                if (nguoiPhanTichValues.ContainsKey(row.Index) && nguoiPhanTichColumn.Items.Contains(nguoiPhanTichValues[row.Index]))
                    row.Cells["NguoiPhanTich"].Value = nguoiPhanTichValues[row.Index];
            }
            dgv.CellValueChanged += Dgv_CellValueChanged;
            dgv.CellFormatting -= Dgv_CellFormatting;
            dgv.CellFormatting += Dgv_CellFormatting;
        }
        private void RestoreColumnsToText(Guna.UI2.WinForms.Guna2DataGridView dgv)
        {
            dgv.CellValueChanged -= Dgv_CellValueChanged;
            Dictionary<int, string> loaiValues = new Dictionary<int, string>();
            Dictionary<int, string> nguoiPhanTichValues = new Dictionary<int, string>();
            int loaiIndex = -1;
            int nguoiPhanTichIndex = -1;

            if (dgv.Columns["Loai"] != null)
                loaiIndex = dgv.Columns["Loai"].Index;
            if (dgv.Columns["NguoiPhanTich"] != null)
                nguoiPhanTichIndex = dgv.Columns["NguoiPhanTich"].Index;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Loai"].Value != null)
                    loaiValues[row.Index] = row.Cells["Loai"].Value.ToString();
                if (row.Cells["NguoiPhanTich"].Value != null)
                    nguoiPhanTichValues[row.Index] = row.Cells["NguoiPhanTich"].Value.ToString();
            }
            if (dgv.Columns["Loai"] != null)
                dgv.Columns.Remove("Loai");
            if (dgv.Columns["NguoiPhanTich"] != null)
                dgv.Columns.Remove("NguoiPhanTich");
            DataGridViewTextBoxColumn loaiColumn = new DataGridViewTextBoxColumn
            {
                Name = "Loai",
                HeaderText = "Loại",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgv.Columns.Insert(loaiIndex, loaiColumn);

            DataGridViewTextBoxColumn nguoiPhanTichColumn = new DataGridViewTextBoxColumn
            {
                Name = "NguoiPhanTich",
                HeaderText = "Người Phân Tích",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgv.Columns.Insert(nguoiPhanTichIndex, nguoiPhanTichColumn);
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (loaiValues.ContainsKey(row.Index))
                    row.Cells["Loai"].Value = loaiValues[row.Index];
                if (nguoiPhanTichValues.ContainsKey(row.Index))
                    row.Cells["NguoiPhanTich"].Value = nguoiPhanTichValues[row.Index];
            }
            DataTable dt = (DataTable)dgv.DataSource;
            foreach (DataRow dataRow in dt.Rows)
            {
                int rowIndex = dt.Rows.IndexOf(dataRow);
                if (loaiValues.ContainsKey(rowIndex))
                    dataRow["Loai"] = loaiValues[rowIndex];
                if (nguoiPhanTichValues.ContainsKey(rowIndex))
                    dataRow["NguoiPhanTich"] = nguoiPhanTichValues[rowIndex];
            }
            dgv.CellFormatting -= Dgv_CellFormatting;
            dgv.CellFormatting += Dgv_CellFormatting;
        }
        private void UpdateNguoiPhanTichComboBox(DataGridViewRow row, string loaiValue)
        {
            DataGridViewComboBoxCell nguoiPhanTichCell = (DataGridViewComboBoxCell)row.Cells["NguoiPhanTich"];
            nguoiPhanTichCell.Items.Clear();
            string vaiTro = loaiValue == "HT" ? "Phòng quan trắc" : "Phòng phân tích";
            DataTable dtNguoiDung = ThongSoBLL.Instance.GetNguoiDungByVaiTro(vaiTro);
            foreach (DataRow dr in dtNguoiDung.Rows)
            {
                nguoiPhanTichCell.Items.Add(dr[0].ToString());

            }
        }
        private void SaveCurrentTabData()
        {
            if (tabctrlTSMT.SelectedTab == null) return;
            string tabName = tabctrlTSMT.SelectedTab.Text;
            string maViTri = tabctrlTSMT.SelectedTab.Text;
            if (tabctrlTSMT.SelectedTab.Controls.Count == 0 ||
                !(tabctrlTSMT.SelectedTab.Controls[0] is Guna.UI2.WinForms.Guna2DataGridView dgv))
            {
                return;
            }
            DataTable dt = (DataTable)dgv.DataSource;
            List<ThongSo> currentData = new List<ThongSo>();
            foreach (DataRow row in dt.Rows)
            {
                ThongSo thongSo = new ThongSo
                {
                    MaTS = row["MaTS"]?.ToString(),
                    TenTS = row["TenTS"]?.ToString(),
                    DonVi = row["DonVi"]?.ToString(),
                    KetQua = row["KetQua"]?.ToString(),
                    KetQuaTruoc = row["KetQuaTruoc"]?.ToString(),
                    AnLanQuanTrac = row["AnLanQuanTrac"] != DBNull.Value && Convert.ToBoolean(row["AnLanQuanTrac"]),
                    Loai = row["Loai"]?.ToString(),
                    NguoiPhanTich = row["NguoiPhanTich"]?.ToString(),
                    GiaTriQuyChuanTCVN = row["GiaTriQuyChuanTCVN"]?.ToString(),
                    KetLuan = row["KetLuan"]?.ToString()
                };
                currentData.Add(thongSo);
            }
            if (!_originalData.ContainsKey(tabName)) return;
            List<ThongSo> originalData = _originalData[tabName];
            foreach (var original in originalData)
            {
                if (!string.IsNullOrEmpty(original.MaTS) && !currentData.Any(c => c.MaTS == original.MaTS))
                {
                    bool success = ThongSoBLL.Instance.DeleteKetQua(
                        _donHang.MaHD,
                        _donHang.MaDH,
                        maViTri,
                        original.MaTS
                    );
                    if (!success)
                    {
                        MessageBox.Show($"Xóa kết quả cho thông số {original.MaTS} thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            foreach (var current in currentData)
            {
                var original = originalData.FirstOrDefault(o => o.MaTS == current.MaTS);
                if (original == null || string.IsNullOrEmpty(current.MaTS))
                {
                    KetQua ketQua = new KetQua
                    {
                        MaHopDong = _donHang.MaHD,
                        MaDonHang = _donHang.MaDH,
                        MaViTri = maViTri,
                        MaThongSo = current.MaTS,
                        KetQuaGiaTri = current.KetQua,
                        AnLanQuanTrac = current.AnLanQuanTrac,
                        Loai = current.Loai,
                        NguoiPhanTich = current.NguoiPhanTich,
                        KetLuan = current.KetLuan
                    };
                    bool success = ThongSoBLL.Instance.InsertOrUpdateKetQua(
                        ketQua,
                        loaiViTri,
                        current.TenTS,
                        current.DonVi,
                        current.GiaTriQuyChuanTCVN,
                        null
                    );
                    if (!success)
                    {
                        MessageBox.Show($"Thêm kết quả cho thông số {current.MaTS} thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (original.KetQua != current.KetQua ||
                        original.AnLanQuanTrac != current.AnLanQuanTrac ||
                        original.Loai != current.Loai ||
                        original.NguoiPhanTich != current.NguoiPhanTich ||
                        original.KetLuan != current.KetLuan)
                    {
                        KetQua ketQua = new KetQua
                        {
                            MaHopDong = _donHang.MaHD,
                            MaDonHang = _donHang.MaDH,
                            MaViTri = maViTri,
                            MaThongSo = current.MaTS,
                            KetQuaGiaTri = current.KetQua,
                            AnLanQuanTrac = current.AnLanQuanTrac,
                            Loai = current.Loai,
                            NguoiPhanTich = current.NguoiPhanTich,
                            KetLuan = current.KetLuan
                        };
                        bool success = ThongSoBLL.Instance.InsertOrUpdateKetQua(
                            ketQua,
                            loaiViTri,
                            current.TenTS,
                            current.DonVi,
                            current.GiaTriQuyChuanTCVN,
                            original.MaTS
                        );
                        if (!success)
                        {
                            MessageBox.Show($"Cập nhật kết quả cho thông số {current.MaTS} thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            _originalData[tabName] = currentData;
            LoadDataForTab(dgv, maViTri, _donHang.MaDH);
        }
        #endregion
        #region Event
        private void tabctrlTSMT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lastTabIndex != -1 && _lastTabIndex < tabctrlTSMT.TabPages.Count)
            {
                string lastTabName = tabctrlTSMT.TabPages[_lastTabIndex].Text;
                if (_isEditingTabs.ContainsKey(lastTabName) && _isEditingTabs[lastTabName])
                {
                    DialogResult result = MessageBox.Show(
                        $"Tab '{lastTabName}' chưa được lưu. Bạn có muốn lưu trước khi chuyển tab?",
                        "Cảnh báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        SaveCurrentTabData();
                        _isEditingTabs[lastTabName] = false;
                        btnSave.Visible = false;
                        btnEdit.Visible = true;
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        tabctrlTSMT.SelectedIndex = _lastTabIndex;
                        return;
                    }
                }
            }
            if (tabctrlTSMT.SelectedTab != null)
            {
                labelTenVT.Text = tabctrlTSMT.SelectedTab.Tag.ToString();
                if (tabctrlTSMT.SelectedTab.Controls.Count > 0 && tabctrlTSMT.SelectedTab.Controls[0] is Guna.UI2.WinForms.Guna2DataGridView dgv)
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells["STT"] != null)
                        {
                            row.Cells["STT"].Value = row.Index + 1;
                        }
                    }
                }
            }
            _lastTabIndex = tabctrlTSMT.SelectedIndex;
        }
        private void btnAddVT_Click(object sender, EventArgs e)
        {
            if (_isEditingTabs.Any(x => x.Value == true))
            {
                MessageBox.Show("Vui lòng lưu thay đổi trước khi thêm vị trí mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AddNewTabPage();
        }
        private void labelTenVT_DoubleClick(object sender, EventArgs e)
        {
            if (!PermissionManager.HasPermission(PermissionManager.Permissions.ManageTSMT))
            {
                return;
            }
            string oldName = labelTenVT.Text;
            System.Windows.Forms.TextBox txtEdit = new System.Windows.Forms.TextBox
            {
                Text = labelTenVT.Text,
                Location = labelTenVT.Location,
                Parent = labelTenVT.Parent,
                Width = Math.Max(labelTenVT.Width + 20, 100)
            };
            txtEdit.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    labelTenVT.Text = txtEdit.Text;
                    txtEdit.Dispose();
                    labelTenVT.Visible = true;
                }
            };
            txtEdit.Leave += (s, ev) =>
            {
                UpdateViTri(txtEdit.Text, oldName);
                labelTenVT.Text = txtEdit.Text;
                txtEdit.Dispose();
                labelTenVT.Visible = true;
            };
            labelTenVT.Visible = false;
            txtEdit.Focus();
        }
        private void btnDelVT_Click(object sender, EventArgs e)
        {
            if (_isEditingTabs.Any(x => x.Value == true))
            {
                MessageBox.Show("Vui lòng lưu thay đổi trước khi xóa vị trí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DelTabPage();
        }
        private void Dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Guna.UI2.WinForms.Guna2DataGridView dgv = sender as Guna.UI2.WinForms.Guna2DataGridView;
            if (e.ColumnIndex == dgv.Columns["Loai"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                string loaiValue = row.Cells["Loai"].Value?.ToString();
                DataGridViewComboBoxCell nguoiPhanTichCell = (DataGridViewComboBoxCell)row.Cells["NguoiPhanTich"];
                nguoiPhanTichCell.Value = null;
                if (!string.IsNullOrEmpty(loaiValue))
                {
                    UpdateNguoiPhanTichComboBox(row, loaiValue);
                }
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_isEditingTabs.Any(x => x.Value == true)) 
            {
                MessageBox.Show("Vui lòng lưu thay đổi trước khi xuất PDF!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF file|*.pdf",
                Title = "Chọn nơi lưu file PDF"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                #region header
                string companyName = "CÔNG TY CỔ PHẦN KIỂM NGHIỆM MÔI TRƯỜNG ECOTEST VIỆT NAM";
                string address = "Địa chỉ: Số 123, Đường Nguyễn Văn Cừ, Phường 4, Quận 5, TP. Hồ Chí Minh";
                string contact = "SĐT: 0901 234 567 | Email: contact@ecotest.vn";
                string title = "KẾT QUẢ PHÂN TÍCH";

                List<string> kiHieuMau = [];
                List<string> thongSo = [];
                List<ViTriLayMau> danhSachViTriDH = ViTriBLL.Instance.GetViTriByMaDH(_donHang.MaDH);
                foreach (var viTri in danhSachViTriDH)
                {
                    if (viTri.LoaiViTri == loaiViTri)
                    {
                        kiHieuMau.Add(viTri.MaViTri);
                    }
                }
                string[,] infoDH =
                    {
                        { "Tên khách hàng", _donHang.TenCT },
                        { "Địa chỉ", CongTyBLL.Instance.GetCongTyByTenCongTy(_donHang.TenCT).DiaChi },
                        { "Địa điểm quan trắc", CongTyBLL.Instance.GetCongTyByTenCongTy(_donHang.TenCT).DiaChi },
                        { "Tên mẫu", loaiViTri },
                        { "Số mẫu", kiHieuMau.Count.ToString() },
                        { "Ngày lấy mẫu", _donHang.NgayLM.ToString("dd/MM/yyyy") },
                        { "Thời gian hoàn thành", _donHang.NgayKQ.ToString("dd/MM/yyyy") },
                        { "Ký hiệu", string.Join(", ", kiHieuMau) }
                    };

                string filePath = saveFileDialog.FileName;
                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = title;
                pdf.Options.FlateEncodeMode = PdfFlateEncodeMode.BestCompression;

                // Create fonts with UTF-8 encoding
                XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode);
                XFont titleFont = new XFont("Arial Unicode MS", 20, XFontStyle.Bold, options);
                XFont infoFont = new XFont("Arial Unicode MS", 10, XFontStyle.Regular, options);
                XFont headerBold = new XFont("Arial Unicode MS", 12, XFontStyle.Bold, options);
                XFont tableFont = new XFont("Arial Unicode MS", 10, XFontStyle.Regular, options);
                XFont headerFont = new XFont("Arial Unicode MS", 10, XFontStyle.Bold, options);

                MemoryStream ms = new MemoryStream();
                MemoryStream ms1 = new MemoryStream();
                PdfPage page = pdf.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Định nghĩa các thông số cơ bản
                int topPadding = 100;    
                int bottomPadding = 100;  
                int margin = 50;          
                int rowHeight = 25;
                int yPosition = topPadding-20;

                // Hàm kiểm tra và tạo trang mới
                void CreateNewPageIfNeeded(int requiredHeight = 0)
                {
                    int heightNeeded = requiredHeight == 0 ? rowHeight : requiredHeight;
                    if (yPosition + heightNeeded > page.Height - bottomPadding)
                    {
                        page = pdf.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        yPosition = topPadding;
                    }
                }
                Properties.Resources.logo40Opa.Save(ms1, ImageFormat.Png);
                Properties.Resources.logo.Save(ms, ImageFormat.Png);
                XImage logo = XImage.FromStream(ms);
                XImage logo40Opa = XImage.FromStream(ms1);
                double logoWidth = 120;
                double logoHeight = 140;
                double logo40OpaWidth = 400;
                double logo40OpaHeight = 500;
                gfx.DrawImage(logo, margin, yPosition-65, logoWidth, logoHeight);
                gfx.DrawImage(logo40Opa, (page.Width - logo40OpaWidth)/2, (page.Height - logo40OpaHeight)/2, logo40OpaWidth, logo40OpaHeight);

                int textX = margin + (int)logoWidth;
                double availableWidth = page.Width - textX - margin;

                double companyNameWidth = gfx.MeasureString(companyName, headerBold).Width;
                gfx.DrawString(companyName, headerBold, XBrushes.Black,
                    new XPoint(textX + (availableWidth - companyNameWidth) / 2, yPosition));
                yPosition += 20;

                double addressWidth = gfx.MeasureString(address, infoFont).Width;
                gfx.DrawString(address, infoFont, XBrushes.Black,
                    new XPoint(textX + (availableWidth - addressWidth) / 2, yPosition));
                yPosition += 20;

                double contactWidth = gfx.MeasureString(contact, infoFont).Width;
                gfx.DrawString(contact, infoFont, XBrushes.Black,
                    new XPoint(textX + (availableWidth - contactWidth) / 2, yPosition));
                yPosition += 20;

                gfx.DrawLine(XPens.Black, margin, yPosition, page.Width - margin, yPosition);
                yPosition += 40;

                double centerX = page.Width / 2;
                double titleWidth = gfx.MeasureString(title, titleFont).Width;
                gfx.DrawString(title, titleFont, XBrushes.Black,
                    new XPoint(centerX - titleWidth / 2, yPosition));
                yPosition += 30;

                int labelX = margin;
                int valueX = margin + 150;
                int rowSpacing = 20;

                for (int i = 0; i < infoDH.GetLength(0); i++)
                {
                    gfx.DrawString(infoDH[i, 0] + " :", infoFont, XBrushes.Black, new XPoint(labelX, yPosition));
                    gfx.DrawString(infoDH[i, 1], infoFont, XBrushes.Black, new XPoint(valueX, yPosition));
                    yPosition += rowSpacing;
                }
                #endregion
                #region table
                #region headerTable
                List<ThongSo> ketQuaList = new List<ThongSo>();
                foreach (var viTri in danhSachViTriDH)
                {
                    if (viTri.LoaiViTri == loaiViTri)
                    {
                        var ketQuas = ThongSoBLL.Instance.GetKetQuaList(_donHang.MaDH, viTri.MaViTri);
                        foreach (var kq in ketQuas)
                        {
                            kq.MaViTri = viTri.MaViTri;
                        }
                        ketQuaList.AddRange(ketQuas);
                    }
                }

                var data = ketQuaList
                    .GroupBy(ts => new { ts.MaTS, ts.TenTS, ts.DonVi, ts.GiaTriQuyChuanTCVN })
                    .Select((group, index) =>
                    {
                        var ketQuaByViTri = new Dictionary<string, string>();
                        foreach (var viTri in kiHieuMau)
                        {
                            var ketQua = ketQuaList.FirstOrDefault(ts =>
                                ts.MaViTri == viTri && 
                                ts.MaTS == group.Key.MaTS);
                            ketQuaByViTri[viTri] = ketQua?.KetQua ?? "-";
                        }

                        return new
                        {
                            STT = index + 1,
                            TenTS = group.Key.TenTS,
                            DonVi = group.Key.DonVi,
                            KetQua = ketQuaByViTri,
                            QCVN = group.Key.GiaTriQuyChuanTCVN
                        };
                    })
                    .ToList();

                int pageWidth = (int)page.Width - 2 * margin;

                // Cố định kích thước cột bên trái và phải
                int colSTT = 40, colThongSo = 130, colDonVi = 60, colQCVN = 70;

                // Phần còn lại cho cột kết quả phân tích
                int availableTableWidth = pageWidth - (colSTT + colThongSo + colDonVi + colQCVN);
                int numColumns = kiHieuMau.Count;
                int colWidth = availableTableWidth / numColumns;

                // Vẽ tiêu đề bảng
                gfx.DrawRectangle(XPens.Black, margin, yPosition, pageWidth, rowHeight * 2);

                // STT
                double sttWidth = gfx.MeasureString("STT", headerFont).Width;
                gfx.DrawString("STT", headerFont, XBrushes.Black,
                    new XPoint(margin + (colSTT - sttWidth) / 2, yPosition + rowHeight / 2 + 15));
                gfx.DrawLine(XPens.Black, margin, yPosition, margin, yPosition + rowHeight * 2);

                // Thông số
                double thongSoWidth = gfx.MeasureString("Thông số", headerFont).Width;
                gfx.DrawString("Thông số", headerFont, XBrushes.Black,
                    new XPoint(margin + colSTT + (colThongSo - thongSoWidth) / 2, yPosition + rowHeight / 2 + 15));
                gfx.DrawLine(XPens.Black, margin + colSTT, yPosition, margin + colSTT, yPosition + rowHeight * 2);

                // Đơn vị
                double donViWidth = gfx.MeasureString("Đơn vị", headerFont).Width;
                gfx.DrawString("Đơn vị", headerFont, XBrushes.Black,
                    new XPoint(margin + colSTT + colThongSo + (colDonVi - donViWidth) / 2, yPosition + rowHeight / 2 + 15));
                gfx.DrawLine(XPens.Black, margin + colSTT + colThongSo, yPosition, margin + colSTT + colThongSo, yPosition + rowHeight * 2);
                gfx.DrawLine(XPens.Black, margin + colSTT + colThongSo + colDonVi, yPosition, margin + colSTT + colThongSo + colDonVi, yPosition + rowHeight * 2);

                // Kết quả phân tích
                int ketQuaX = margin + colSTT + colThongSo + colDonVi;
                double ketQuaPhanTichWidth = gfx.MeasureString("Kết quả phân tích", headerFont).Width;
                gfx.DrawString("Kết quả phân tích", headerFont, XBrushes.Black,
                    new XPoint(ketQuaX + (availableTableWidth - ketQuaPhanTichWidth) / 2, yPosition + rowHeight / 2 + 6));
                int endKetQuaX = ketQuaX + availableTableWidth;
                gfx.DrawLine(XPens.Black, endKetQuaX, yPosition, endKetQuaX, yPosition + rowHeight * 2);

                // Vẽ đường ngang phân chia
                gfx.DrawLine(XPens.Black, ketQuaX, yPosition + rowHeight, ketQuaX + availableTableWidth, yPosition + rowHeight);

                // Mã vị trí
                int colPosition = ketQuaX;
                int lastIndex = kiHieuMau.Count - 1;
                for (int i = 0; i < kiHieuMau.Count; i++)
                {
                    var kiHieu = kiHieuMau[i];
                    double kiHieuWidth = gfx.MeasureString(kiHieu, headerFont).Width;
                    gfx.DrawString(kiHieu, headerFont, XBrushes.Black,
                        new XPoint(colPosition + (colWidth - kiHieuWidth) / 2, yPosition + rowHeight + 15));
                    colPosition += colWidth;
                    if (i < lastIndex) 
                    {
                        gfx.DrawLine(XPens.Black, colPosition, yPosition + rowHeight, colPosition, yPosition + rowHeight * 2);
                    }
                }

                // QCVN
                double qcvnWidth = gfx.MeasureString("QCVN", headerFont).Width;
                gfx.DrawString("QCVN", headerFont, XBrushes.Black,
                    new XPoint(colPosition + (colQCVN - qcvnWidth) / 2, yPosition + rowHeight / 2 + 15));

                yPosition += rowHeight * 2;
                #endregion
                #region contentTable
                // Vẽ nội dung bảng
                foreach (var item in data)
                {
                    if (yPosition + rowHeight > page.Height - margin)
                    {
                        page = pdf.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        yPosition = margin;
                    }

                    // Tính toán chiều cao hàng dựa trên nội dung
                    int currentRowHeight = rowHeight;
                    string tenTS = item.TenTS;
                    double textWidth = gfx.MeasureString(tenTS, tableFont).Width;
                    if (textWidth > colThongSo - 10)
                    {
                        currentRowHeight = 40;
                    }

                    // Vẽ khung hàng
                    gfx.DrawRectangle(XPens.Black, margin, yPosition, pageWidth, currentRowHeight);
                    // Tính toán vị trí căn giữa theo chiều dọc cho tất cả các ô
                    double verticalCenter = yPosition + (currentRowHeight / 2);
                    double textHeight = tableFont.Height;
                    double baselineY = verticalCenter + (textHeight / 2);

                    // STT - căn giữa hoàn toàn
                    string sttValue = item.STT.ToString();
                    double sttValueWidth = gfx.MeasureString(sttValue, tableFont).Width;
                    double sttX = margin + (colSTT - sttValueWidth) / 2;
                    gfx.DrawString(sttValue, tableFont, XBrushes.Black, new XPoint(sttX, baselineY));

                    // Thông số - căn giữa theo chiều dọc, căn trái với padding
                    if (textWidth > colThongSo - 10)
                    {
                        var lines = SplitTextIntoLines(tenTS, tableFont, gfx, colThongSo - 10);
                        double totalHeight = lines.Count * textHeight;
                        double startY = verticalCenter - (totalHeight / 2) + (textHeight / 2);
                        
                        foreach (var line in lines)
                        {
                            gfx.DrawString(line, tableFont, XBrushes.Black,
                                new XPoint(margin + colSTT + 5, startY));
                            startY += textHeight;
                        }
                    }
                    else
                    {
                        gfx.DrawString(tenTS, tableFont, XBrushes.Black,
                            new XPoint(margin + colSTT + 5, baselineY));
                    }

                    // Đơn vị - căn giữa hoàn toàn
                    donViWidth = gfx.MeasureString(item.DonVi, tableFont).Width;
                    double donViX = margin + colSTT + colThongSo + (colDonVi - donViWidth) / 2;
                    gfx.DrawString(item.DonVi, tableFont, XBrushes.Black, new XPoint(donViX, baselineY));

                    // Kết quả phân tích - căn giữa hoàn toàn
                    colPosition = margin + colSTT + colThongSo + colDonVi;
                    foreach (var kiHieu in kiHieuMau)
                    {
                        string ketQuaValue = item.KetQua[kiHieu];
                        double ketQuaWidth = gfx.MeasureString(ketQuaValue, tableFont).Width;
                        ketQuaX = (int) (colPosition + (colWidth - ketQuaWidth) / 2);
                        gfx.DrawString(ketQuaValue, tableFont, XBrushes.Black,
                            new XPoint(ketQuaX, baselineY));
                        
                        if (kiHieu != kiHieuMau.Last())
                            gfx.DrawLine(XPens.Black, colPosition + colWidth, yPosition, colPosition + colWidth, yPosition + currentRowHeight);
                        
                        colPosition += colWidth;
                    }

                    // QCVN - căn giữa hoàn toàn
                    string qcvnValue = item.QCVN ?? "-";
                    double qcvnValueWidth = gfx.MeasureString(qcvnValue, tableFont).Width;
                    double qcvnX = colPosition + (colQCVN - qcvnValueWidth) / 2;
                    gfx.DrawString(qcvnValue, tableFont, XBrushes.Black, new XPoint(qcvnX, baselineY));
                    // Vẽ đường kẻ dọc chính
                    gfx.DrawLine(XPens.Black, margin, yPosition, margin, yPosition + currentRowHeight);
                    gfx.DrawLine(XPens.Black, margin + colSTT, yPosition, margin + colSTT, yPosition + currentRowHeight);
                    gfx.DrawLine(XPens.Black, margin + colSTT + colThongSo, yPosition, margin + colSTT + colThongSo, yPosition + currentRowHeight);
                    gfx.DrawLine(XPens.Black, margin + colSTT + colThongSo + colDonVi, yPosition, margin + colSTT + colThongSo + colDonVi, yPosition + currentRowHeight);
                    gfx.DrawLine(XPens.Black, endKetQuaX, yPosition, endKetQuaX, yPosition + currentRowHeight);
                    gfx.DrawLine(XPens.Black, endKetQuaX + colQCVN, yPosition, endKetQuaX + colQCVN, yPosition + currentRowHeight);

                    yPosition += currentRowHeight;
                }
                #endregion
                #endregion
                #region footer
                yPosition += 20;
                XFont noteFont = new XFont("Arial", 10, XFontStyle.Italic);
                XFont noteBoldFont = new XFont("Arial", 10, XFontStyle.BoldItalic);
                XFont signatureFont = new XFont("Arial", 11, XFontStyle.Bold);

                gfx.DrawString("Chú thích:", headerFont, XBrushes.Black, new XPoint(margin, yPosition));
                yPosition += 25;
                gfx.DrawString("- Vị trí lấy mẫu:", headerFont, XBrushes.Black, new XPoint(margin + 10, yPosition));
                yPosition += 25;

                for (int i = 0; i < kiHieuMau.Count; i++)
                {
                    string maViTri = kiHieuMau[i];
                    var viTri = danhSachViTriDH.FirstOrDefault(x => x.MaViTri == maViTri && x.LoaiViTri == loaiViTri);
                    string tenViTri = viTri != null ? viTri.TenViTri : "";
                    string boldText = $"{maViTri}:";
                    string normalText = " " + tenViTri;
                    if (yPosition + 20 > page.Height - margin)
                    {
                        page = pdf.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        yPosition = margin;
                    }
                    gfx.DrawString(boldText, noteBoldFont, XBrushes.Black, new XPoint(margin + 20, yPosition));
                    double boldTextWidth = gfx.MeasureString(boldText, noteBoldFont).Width;
                    gfx.DrawString(normalText, noteFont, XBrushes.Black, new XPoint(margin + 20 + boldTextWidth, yPosition));
                    yPosition += 20;
                }
                double pageCenter = page.Width / 2;

                string date = $"Tp.HCM, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";
                double dateWidth = gfx.MeasureString(date, noteFont).Width;
                gfx.DrawString(date, noteFont, XBrushes.Black,
                    new XPoint(pageCenter + 50, yPosition));
                yPosition += 25;

                gfx.DrawString("Người phân tích", signatureFont, XBrushes.Black,
                    new XPoint(margin + 50, yPosition));
                gfx.DrawString("(Ký, ghi rõ họ tên)", noteFont, XBrushes.Black,
                    new XPoint(margin + 50, yPosition + 25));

                gfx.DrawString("Trưởng phòng", signatureFont, XBrushes.Black,
                    new XPoint(pageCenter + 90, yPosition));
                gfx.DrawString("(Ký, ghi rõ họ tên)", noteFont, XBrushes.Black,
                    new XPoint(pageCenter + 90, yPosition + 25));
                #endregion
                pdf.Save(filePath);
                MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tabctrlTSMT.SelectedTab != null)
            {
                string tabName = tabctrlTSMT.SelectedTab.Text;
                if (!_isEditingTabs.ContainsKey(tabName))
                    _isEditingTabs[tabName] = false;
                if (!_isEditingTabs[tabName])
                {
                    if (tabctrlTSMT.SelectedTab.Controls.Count > 0 &&
                        tabctrlTSMT.SelectedTab.Controls[0] is Guna.UI2.WinForms.Guna2DataGridView dgv)
                    {
                        DataTable dt = (DataTable)dgv.DataSource;
                        List<ThongSo> originalList = new List<ThongSo>();
                        foreach (DataRow row in dt.Rows)
                        {
                            ThongSo thongSo = new ThongSo
                            {
                                MaTS = row["MaTS"]?.ToString(),
                                TenTS = row["TenTS"]?.ToString(),
                                DonVi = row["DonVi"]?.ToString(),
                                KetQua = row["KetQua"]?.ToString(),
                                AnLanQuanTrac = row["AnLanQuanTrac"] != DBNull.Value && Convert.ToBoolean(row["AnLanQuanTrac"]),
                                Loai = row["Loai"]?.ToString(),
                                NguoiPhanTich = row["NguoiPhanTich"]?.ToString(),
                                GiaTriQuyChuanTCVN = row["GiaTriQuyChuanTCVN"]?.ToString(),
                                KetLuan = row["KetLuan"]?.ToString()
                            };
                            originalList.Add(thongSo);
                        }
                        _originalData[tabName] = originalList;
                        dgv.ReadOnly = false;
                        if (dgv.Columns.Contains("STT"))
                        {
                            dgv.Columns["STT"].ReadOnly = true;
                        }
                        if (dgv.Columns.Contains("KetQuaTruoc"))
                        {
                            dgv.Columns["KetQuaTruoc"].ReadOnly = true;
                        }
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                cell.ReadOnly = true;
                            }
                            string loai = row.Cells["Loai"].Value?.ToString();
                            if (dgv.Columns.Contains("KetQua"))
                            {
                                var ketQuaCell = row.Cells["KetQua"];
                                ketQuaCell.ReadOnly = false;
                            }
                            if (PermissionManager.HasPermission(PermissionManager.Permissions.ManageTSMT))
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.OwningColumn.Name != "KetQua")
                                    {
                                        cell.ReadOnly = false;
                                    }
                                }
                            }
                        }
                        btnEdit.Visible = false;
                        btnInsertTS.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManageTSMT);
                        if (PermissionManager.HasPermission(PermissionManager.Permissions.ManageTSMT)) ConvertColumnsToComboBox(dgv);
                        btnDelTS.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManageTSMT); 
                        btnSave.Visible = true;
                        _isEditingTabs[tabName] = true;
                    }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tabctrlTSMT.SelectedTab != null)
            {
                string tabName = tabctrlTSMT.SelectedTab.Text;
                if (_isEditingTabs.ContainsKey(tabName) && _isEditingTabs[tabName])
                {
                    if (tabctrlTSMT.SelectedTab.Controls.Count > 0 &&
                        tabctrlTSMT.SelectedTab.Controls[0] is Guna.UI2.WinForms.Guna2DataGridView dgv)
                    {
                        if (PermissionManager.HasPermission(PermissionManager.Permissions.ManageTSMT)) RestoreColumnsToText(dgv);
                        SaveCurrentTabData();
                        dgv.ReadOnly = true;
                        btnEdit.Visible = true;
                        btnInsertTS.Visible = false;
                        btnDelTS.Visible = false;
                        btnSave.Visible = false;
                        _isEditingTabs[tabName] = false;
                    }
                }
            }
        }
        private void btnInsertTS_Click(object sender, EventArgs e)
        {
            if (tabctrlTSMT.SelectedTab == null) return;
            if (tabctrlTSMT.SelectedTab.Controls.Count == 0 ||
                !(tabctrlTSMT.SelectedTab.Controls[0] is Guna.UI2.WinForms.Guna2DataGridView dgv))
            {
                return;
            }
            DataTable dt = (DataTable)dgv.DataSource;
            DataRow newRow = dt.NewRow();
            newRow["MaTS"] = "";
            newRow["TenTS"] = "";
            newRow["DonVi"] = "";
            newRow["KetQua"] = "";
            newRow["KetQuaTruoc"] = "N/A";
            newRow["AnLanQuanTrac"] = false;
            newRow["Loai"] = "HT";
            newRow["NguoiPhanTich"] = null;
            newRow["GiaTriQuyChuanTCVN"] = "";
            newRow["KetLuan"] = null;
            dt.Rows.Add(newRow);
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["STT"].Value = row.Index + 1;
            }
        }
        private void btnDelTS_Click(object sender, EventArgs e)
        {
            if (tabctrlTSMT.SelectedTab == null) return;
            if (tabctrlTSMT.SelectedTab.Controls.Count == 0 ||
                !(tabctrlTSMT.SelectedTab.Controls[0] is Guna.UI2.WinForms.Guna2DataGridView dgv))
            {
                return;
            }
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }
            DataTable dt = (DataTable)dgv.DataSource;
            DataGridViewRow selectedRow = dgv.SelectedRows[0];
            dt.Rows.RemoveAt(selectedRow.Index);
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["STT"].Value = row.Index + 1;
            }
        }
        private void fThongSoMoiTruong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tabctrlTSMT.SelectedTab != null)
            {
                string currentTabName = tabctrlTSMT.SelectedTab.Text;
                if (_isEditingTabs.ContainsKey(currentTabName) && _isEditingTabs[currentTabName])
                {
                    DialogResult result = MessageBox.Show(
                        $"Tab '{currentTabName}' chưa được lưu. Bạn có muốn lưu trước khi thoát?",
                        "Cảnh báo",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        SaveCurrentTabData();
                        if (tabctrlTSMT.SelectedTab.Controls.Count > 0 && tabctrlTSMT.SelectedTab.Controls[0] is Guna.UI2.WinForms.Guna2DataGridView dgv)
                        {
                            RestoreColumnsToText(dgv);
                            dgv.ReadOnly = true;
                        }
                        btnEdit.Visible = true;
                        btnInsertTS.Visible = false;
                        btnDelTS.Visible = false;
                        btnSave.Visible = false;
                        _isEditingTabs[currentTabName] = false;
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
        #endregion
    }
}
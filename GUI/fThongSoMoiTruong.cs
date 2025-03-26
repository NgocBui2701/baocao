using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Controls;
using System.Windows.Forms;
using baocao.DAO;
using baocao.DTO;

namespace baocao.GUI
{
    public partial class fThongSoMoiTruong : Form
    {

        private List<string> maViTriList = new List<string>();
        private int nextIndex = 0; // Chỉ số dòng tiếp theo để đặt tên tab
        int num = 0;


        public fThongSoMoiTruong(int num)
        {
            InitializeComponent();
            LoadMaViTri();
            LoadData();
            UpdateTabPageName();
            this.num = num;
        }

        private void fThongSoMoiTruong_Load(object sender, EventArgs e)
        {
            dgvTab.ReadOnly = true;
            dgvTab.AllowUserToAddRows = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

        }

        private void LoadData()
        {
            List<ThongSo> listThongSo = ThongSoDAO.Instance.GetAllThongSo();
            dgvTab.DataSource = listThongSo;


            if (dgvTab.Columns.Contains("MaVT"))
            {
                dgvTab.Columns["MaVT"].Visible = false;
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            //ThongSo newThongSo = new ThongSo();
            //fThongSoMoiTruongEdit fEdit = new fThongSoMoiTruongEdit(newThongSo);
            //fEdit.Text = "Thêm Thông Số";
            //if (fEdit.ShowDialog() == DialogResult.OK)
            //{
            //    if (ThongSoDAO.Instance.InsertThongSo(newThongSo))
            //    {
            //        MessageBox.Show("Thêm thành công!");
            //        LoadData();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Thêm thất bại!");
            //    }
            //}
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            //if (dgvTab.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow row = dgvTab.SelectedRows[0];
            //    ThongSo ts = row.DataBoundItem as ThongSo;
            //    if (ts != null)
            //    {
            //        fThongSoMoiTruongEdit fEdit = new fThongSoMoiTruongEdit(ts);
            //        fEdit.Text = "Sửa Thông Số";
            //        if (fEdit.ShowDialog() == DialogResult.OK)
            //        {
            //            if (ThongSoDAO.Instance.UpdateThongSo(ts))
            //            {
            //                MessageBox.Show("Cập nhật thành công!");
            //                LoadData();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Cập nhật thất bại!");
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn dòng cần sửa!");
            //}
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTab.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTab.SelectedRows[0];
                ThongSo ts = row.DataBoundItem as ThongSo;
                if (ts != null)
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa thông số này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (ThongSoDAO.Instance.DeleteThongSo(ts.MaTS))
                        {
                            MessageBox.Show("Xóa thành công!");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
            }
        }
        private void btnAddTab_Click(object sender, EventArgs e)
        {

            if (tabControl1.TabPages.Count >= 3)
            {
                MessageBox.Show("Bạn chỉ được thêm tối đa 3 tab!");
                return;
            }


            if (nextIndex >= maViTriList.Count)
            {
                MessageBox.Show("Không còn ma_vi_tri để đặt tên cho tab mới!");
                return;
            }


            string tabName = maViTriList[nextIndex];
            nextIndex++;


            TabPage newTab = new TabPage(tabName);
            newTab.AutoScroll = true;


            DataGridView dgvTabNew = new DataGridView();
            dgvTabNew.Dock = DockStyle.Fill;


            newTab.Controls.Add(dgvTabNew);


            tabControl1.TabPages.Add(newTab);


            foreach (DataGridViewColumn col in dgvTab.Columns)
            {
                DataGridViewColumn newCol = (DataGridViewColumn)col.Clone();
                dgvTabNew.Columns.Add(newCol);
            }


            foreach (DataGridViewRow row in dgvTab.Rows)
            {
                if (!row.IsNewRow)
                {
                    int newIndexRow = dgvTabNew.Rows.Add();
                    DataGridViewRow newRow = dgvTabNew.Rows[newIndexRow];

                    newRow.Cells["TenTS"].Value = row.Cells["TenTS"].Value;
                    newRow.Cells["DonVi"].Value = row.Cells["DonVi"].Value;
                    newRow.Cells["GiaTriQuyChuanTCVN"].Value = row.Cells["GiaTriQuyChuanTCVN"].Value;
                }
            }
        }




        private void dgvTab_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }
        private void UpdateTabPageName()
        {

            string query = "SELECT TOP 1 ma_vi_tri FROM ThongSoMoiTruong";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                string newName = dt.Rows[0]["ma_vi_tri"].ToString();

                tabControl1.TabPages[0].Text = newName;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu vị trí!");
            }
        }
        private void LoadMaViTri()
        {

            string query = "SELECT ma_vi_tri FROM ThongSoMoiTruong"; // Ghi chú: Do trong db chỉ mới thêm Đất 1 nên thêm tab mới có ra được Đất 1 thôi
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);


            maViTriList.Clear();

            foreach (DataRow row in dt.Rows)
            {
                maViTriList.Add(row["ma_vi_tri"].ToString());
            }


        }

    }
}


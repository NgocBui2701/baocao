using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace baocao.GUI
{
    public partial class fQuanLyPhanQuyen : PagedForm<Account>
    {
        protected override string id => "MaNguoiDung";
        public fQuanLyPhanQuyen()
        {
            InitializeComponent();
            InitializePagedForm(dgvQuanLyPhanQuyen, txtSearch, labelPage, btnFirstPage, btnPrevPage, btnNextPage, btnLastPage, txtPage, btnInsert, btnEdit, btnDel);
            LoadData();
        }
        protected override List<Account> LoadFullData()
        {
            return AccountBLL.Instance.LoadData() ?? new List<Account>();
        }
        protected override List<Account> SearchData(string keyword)
        {
            return AccountBLL.Instance.SearchAccount(keyword) ?? new List<Account>();
        }
        protected override void ConfigureDataGridViewColumns()
        {
            if (dgvMain.Columns.Contains("MatKhau"))
            {
                dgvMain.Columns.Remove("MatKhau");
            }
            if (dgvMain.Columns.Contains("MaNguoiDung"))
                dgvMain.Columns["MaNguoiDung"].HeaderText = "Mã nhân viên";
            if (dgvMain.Columns.Contains("Ten"))
            {
                dgvMain.Columns["Ten"].HeaderText = "Họ tên";
                dgvMain.Columns["Ten"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvMain.Columns.Contains("VaiTro"))
            {
                dgvMain.Columns["VaiTro"].HeaderText = "Vai trò";
                dgvMain.Columns["VaiTro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvMain.Columns.Contains("TenDangNhap"))
            {
                dgvMain.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
                dgvMain.Columns["TenDangNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvMain.Columns.Contains("Email"))
            {
                dgvMain.Columns["Email"].HeaderText = "Email";
                dgvMain.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvMain.Columns.Contains("Sdt"))
            {
                dgvMain.Columns["Sdt"].HeaderText = "Số điện thoại";
            }
        }
        protected override void SetColumnHeaders()
        {
            dgvMain.Columns.Add("MaNguoiDung", "Mã nhân viên");
            dgvMain.Columns.Add("Ten", "Họ tên");
            dgvMain.Columns.Add("VaiTro", "Vai trò");
            dgvMain.Columns.Add("TenDangNhap", "Tên đăng nhập");
            dgvMain.Columns.Add("Email", "Email");
            dgvMain.Columns.Add("Sdt", "Số điện thoại");
        }
        protected override bool DeleteItem(string id)
        {
            return AccountBLL.Instance.DeleteAccount(id);
        }
        protected override Form CreateEditForm(Account item)
        {
            return new fNguoiDungEdit(item);
        }
        private void fQuanLyPhanQuyen_Load(object sender, EventArgs e)
        {
            btnDel.Visible = false;
            btnEdit.Visible = false;
            if (dgvMain.Columns.Contains("MatKhau"))
            {
                dgvMain.Columns.Remove("MatKhau");
            }
        }
    }
}

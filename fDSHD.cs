using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baocao.DAO;
using baocao.DTO;
using Microsoft.Data.SqlClient;

namespace baocao
{
    public partial class fDSHD : Form
    {
        public fDSHD()
        {
            InitializeComponent();
            loadData();
        }
        #region Methods
        private void loadData()
        {
            lvDSHD.Items.Clear();
            List<Dshd> list = DshdDAO.Instance.loadData();
            foreach (Dshd item in list)
            {
                ListViewItem lvi = new ListViewItem(item.MaCT);
                lvi.SubItems.Add(item.TenCT);
                lvi.SubItems.Add(item.KyHieuCT);
                lvi.SubItems.Add(item.NgayHD.ToString());
                lvi.SubItems.Add(item.TenDaiDien);
                lvi.SubItems.Add(item.Sdt);
                lvi.SubItems.Add(item.DiaChi);
                lvDSHD.Items.Add(lvi);
            }
        }
        #endregion
        #region Events
        #endregion

        private void lvDSHD_ItemActivate(object sender, EventArgs e)
        {

        }
    }
}

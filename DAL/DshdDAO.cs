using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baocao.DTO;

namespace baocao.DAO
{
    public class DshdDAO
    {
        private static DshdDAO instance;
        public static DshdDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DshdDAO();
                return DshdDAO.instance;
            }
            private set
            {
                DshdDAO.instance = value;
            }
        }
        public static int DshdWidth = 100;
        public static int DshdHeight = 100;
        private DshdDAO() { }
        public List<Dshd> loadData()
        {
            List<Dshd> list = new List<Dshd>();
            string query = "USP_GetDshdList @TopN";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { 10 });
            foreach (DataRow item in data.Rows)
            {
                Dshd dshd = new Dshd(item);
                list.Add(dshd);
            }
            return list;
        }
    }
}

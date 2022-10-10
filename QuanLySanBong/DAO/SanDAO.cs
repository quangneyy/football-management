using QuanLySanBong.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DAO
{
    public class SanDAO
    {
        private static SanDAO instance;
        public static SanDAO Instancce
        {
            get { if (instance == null) instance = new SanDAO(); return SanDAO.instance; }
            private set { SanDAO.instance = value; }

        }
        public static int widthSan = 90;
        public static int heightSan = 90;
        private SanDAO() { }
        public List<Table> loadSanList()
        {
            List<Table> list = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("usp_getSan");
            foreach (DataRow dr in data.Rows)
            {
                Table table = new Table(dr);
                list.Add(table);
            }
            return list;
        }
    }
}

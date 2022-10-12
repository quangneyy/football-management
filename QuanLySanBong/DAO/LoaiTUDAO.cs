using QuanLySanBong.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DAO
{
    public class LoaiTUDAO
    {
        private static LoaiTUDAO instance;
        public static LoaiTUDAO Instance
        {
            get { if (instance == null) instance = new LoaiTUDAO(); return LoaiTUDAO.instance; }

            private set { instance = value; }
        }
        private LoaiTUDAO() { }
        public List<LoaiTU> GetLoaiTUs()
        {
            List<LoaiTU> loaiTUs = new List<LoaiTU>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select *from LoaiThucUong");
            foreach (DataRow row in data.Rows)
            {
                LoaiTU loais = new LoaiTU(row);
                loaiTUs.Add(loais);
            }
            return loaiTUs;
        }
    }
}

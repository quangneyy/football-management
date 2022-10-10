using QuanLySanBong.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DAO
{
    public class HoaDonInfoDAO
    {
        private static HoaDonInfoDAO instance;
        public static HoaDonInfoDAO Instanse
        {
            get { if (instance == null) instance = new HoaDonInfoDAO(); return HoaDonInfoDAO.instance; }
            private set { instance = value; }
        }
        private HoaDonInfoDAO() { }
        public List<HoaDonInfo> getHoaDonInfo(int id)
        {
            List<HoaDonInfo> list = new List<HoaDonInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select *from dbo.ThongTinHoaDon where idHoaDon "+ id);
            foreach (DataRow row in data.Rows)
            {
                HoaDonInfo hd = new HoaDonInfo(row);
                list.Add(hd);
            }
            return list;
        }
    }
}

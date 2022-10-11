using QuanLySanBong.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;
        public static HoaDonDAO Instanse
        {
            get { if (instance == null) instance = new HoaDonDAO(); return HoaDonDAO.instance; }
            private set { instance = value; }
        }
        private HoaDonDAO() { }
        public int getHoaDOn(int id)
        {
            DataTable datas = DataProvider.Instance.ExecuteQuery("select * from dbo.HoaDon where id = "+id+" and status = 0");
            if(datas.Rows.Count > 0)
            {
                HoaDon hd = new HoaDon(datas.Rows[0]);
                return hd.Id;
            }
            return 1;
        }
    }
}

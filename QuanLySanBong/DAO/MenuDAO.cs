using QuanLySanBong.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = QuanLySanBong.DTO.Menu;

namespace QuanLySanBong.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { instance = value; }
        }
        private MenuDAO() { }
        public List<Menu> getlistMenu(int id)
        {
            List<Menu> list = new List<Menu>();
            DataTable dt = DataProvider.Instance.ExecuteQuery("select td.TenThucUong, tt.count  , td.price, td.price*tt.count as thanhtien from dbo.ThongTinHoaDon as tt, dbo.HoaDon as hd, dbo.ThucUong as td\r\nwhere tt.idHoaDon = hd.id and tt.idThucUong = td.id and hd.idSan = "+id);
            foreach (DataRow dr in dt.Rows)
            {
                Menu menu = new Menu(dr);
                list.Add(menu);
              
            }
            return list;
        }
    }
}

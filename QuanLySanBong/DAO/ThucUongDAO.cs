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
    public class ThucUongDAO
    {
        private static ThucUongDAO instance;
        public static ThucUongDAO Instance
        {
            get { if (instance == null) instance = new ThucUongDAO(); return instance; }
            private set { instance = value; }
        }
        private ThucUongDAO() { }
        public List<ThucUong> getListThucUong(int id)
        {
            List<ThucUong> list = new List<ThucUong>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select *from ThucUong where idLoai = "+ id);
            foreach (DataRow dr in data.Rows)
            {
                ThucUong thuc = new ThucUong(dr);
                list.Add(thuc);
            }
            return list;
        }
    }
}

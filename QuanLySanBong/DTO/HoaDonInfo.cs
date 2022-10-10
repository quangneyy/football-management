using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DTO
{
    public class HoaDonInfo
    {
        public HoaDonInfo(int id, int idHoaDon, int idThucUong, int count)
        {
            this.Id = id;
            this.IdHoaDon = idHoaDon;
            this.IdThucUong = idThucUong;
            this.Count = count;
        }
        public HoaDonInfo(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdHoaDon = (int)row["idHoaDOn"];
            this.IdThucUong = (int)row["idThucUong"];
            this.Count = (int)row["count"];
        }
        private int id;
        private int idHoaDon;
        private int idThucUong;
        private int count;
        public int Id
        {
            get { return id; }
            set { id = value; } 
        }
        public int IdHoaDon
        {
            get { return idHoaDon; }
                set { idHoaDon = value; }

        }
        public int IdThucUong
        {
            get { return idThucUong; }
            set { idThucUong = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

    }
}

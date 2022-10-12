using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DTO
{
    public class ThucUong
    {
        public ThucUong(int id, string tenThucUong, int idLoai, float price)
        {
            this.Id = id;
            this.TenThucUong = tenThucUong;
            this.IdLoai = idLoai;
            this.Price = price;
        }
        public ThucUong(DataRow row)
        {
            this.Id = (int)row["id"];
            this.TenThucUong = row["tenThucUong"].ToString();
            this.IdLoai = (int)row["idLoai"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }
        private int id;
        private string tenThucUong;
        private int idLoai;
        private float price;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string TenThucUong
        {
            get { return tenThucUong; }
            set { tenThucUong = value; }
        }
        public int IdLoai
        {
            get { return idLoai; }
            set { idLoai = value; }
        }
        public float Price
        {
            get { return price; }
            set { price = value; }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DTO
{
    public class Menu
    {
        public Menu(string tenThucUong, string tenLoai, int count, float price, float thanhtien = 0)
        {
            this.TenThucUong = tenThucUong;
            this.TenLoai = tenLoai;
            this.Count = count;
            this.Price = price;
            this.ThanhTien = thanhtien;
        }
        public Menu(DataRow row)
        {
            this.TenThucUong = row["tenThucUong"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.ThanhTien = (float)Convert.ToDouble(row["thanhtien"].ToString());
        }
        private string tenThucUong;
        private string tenLoai;
        private int count;
        private float price;
        private float thanhtien;

        public string TenThucUong
        {
            get { return tenThucUong; }
            set { tenThucUong = value; }
        }
        public string TenLoai
        {
            get { return tenLoai; }
            set { tenLoai = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public float Price
        {
            get { return price; }
            set
            {
                price = value;
            }
        }
        public float ThanhTien
        {
            get { return thanhtien; }
            set
            {
                thanhtien = value;
            }
        }
    }

}
       


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DTO
{
    public class Table
    {
        public Table(int id, string tensan, string trangthai, string loaisan, double giasan)
        {
            this.Id = id;
            this.Tensan = tensan;
            this.Trangthai = trangthai;
            this.Loaisan = loaisan;
            this.Giasan = giasan;

        }
        public Table(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Tensan = row["tensan"].ToString();
            this.Trangthai = row["trangthai"].ToString();
            this.Loaisan = row["loaisan"].ToString();
            this.Giasan = (double)row["giasan"];

        }
        private int id;
        private string tensan;
        private string trangthai;
        private string loaisan;
        private double giasan;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Tensan
        {
            get { return tensan; }
            set { tensan = value; }
        }
        public string Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        public string Loaisan
        {
            get { return loaisan; }
            set { loaisan = value; }
        }
        public double Giasan
        {
            get { return giasan; }
            set { giasan = value; }
        }

    }
}

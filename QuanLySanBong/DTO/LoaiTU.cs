using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLySanBong.DTO
{
    public class LoaiTU
    {
        public LoaiTU(int id, string tenLoai)
        {
            this.Id = id;
            this.TenLoai = tenLoai;
        }
        public LoaiTU(DataRow row)
        {
            this.Id = (int)row["id"];
            this.TenLoai = row["tenloai"].ToString();
        }
        private int id;
        private string tenLoai;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string TenLoai
        {
            get { return tenLoai;}
            set { tenLoai = value; }
        }
    }
}

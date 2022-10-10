using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DTO
{
    public class HoaDon
    {
        public HoaDon(int id, DateTime? ngayVao, DateTime? ngayRa, int idSan, int status)
        {
            this.Id = id;
            this.NgayVao = ngayVao;
            this.NgayRa = ngayRa;
            this.IdSan = idSan;
            this.Status = status;
        }
        public HoaDon(DataRow row)
        {
            this.Id = (int)row["id"];
            this.NgayVao = (DateTime?)row["ngayVao"];
            this.NgayRa = (DateTime?)row["ngayRa"];
            this.IdSan = (int)row["idSan"];
            this.Status = (int)row["status"];
        }
        private int id;
        private DateTime? ngayVao;
        private DateTime? ngayRa;
        private int idSan;
        private int status;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime? NgayVao
        {
            get { return ngayVao; }
            set { ngayVao = value; }
        }
        public DateTime? NgayRa
        {
            get { return ngayRa; }
            set { ngayRa = value; }
        }
        public int IdSan
        {
            get { return idSan; }
            set { idSan = value; }

        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}

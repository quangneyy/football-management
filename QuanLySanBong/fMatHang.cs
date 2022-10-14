using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySanBong.DB;

namespace QuanLySanBong
{
    public partial class fMatHang : Form
    {
        public fMatHang()
        {
            InitializeComponent();
        }

        private dbSanContentDataContext db;

        private void fMatHang_Load(object sender, EventArgs e)
        {
            db = new dbSanContentDataContext(); // khoitao doi tuong db
            ShowData(); // hien thi danh sach mat hang
        }

        private void ShowData()
        {
            var rs = from h in db.MatHangs
                     select new
                     {
                         h.ID,
                         h.TenMatHang,
                         h.DonGiaBan,
                     };
            dgvMatHang.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
        }
    }
}

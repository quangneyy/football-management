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
    public partial class fBanHang : Form
    {
        public fBanHang()
        {
            InitializeComponent();
        }

        private dbSanContentDataContext db;
        private void fBanHang_Load(object sender, EventArgs e)
        {
            db = new dbSanContentDataContext();
            var dsLoaiSan = db.LoaiSans; // lấy danh sách loại sân
            foreach (var l in dsLoaiSan) // duyệt danh sách loại sân
            {
                TabPage tp = new TabPage(l.TenLoaiSan);
                tp.Name = l.ID.ToString(); // set tên băng tên loại sân
                tbcContent.Controls.Add(tp); // add tab vừa khai báo

                ListView lv = new ListView(); // khai báo 1 listview
                lv.Dock = DockStyle.Fill;

                ImageList img1 = new ImageList();
                img1.ImageSize = new Size(200, 128);
                img1.Images.Add(Properties.Resources.free_san); // index = 0
                img1.Images.Add(Properties.Resources.inuse_san); // index = 1
                lv.LargeImageList = img1;

                var dsSan = db.Sans.Where(x => x.IDLoaiSan == l.ID);
                foreach (var p in dsSan)
                {
                    // add item lên listview
                    if (p.TrangThai == 1)
                    {
                        lv.Items.Add(new ListViewItem { ImageIndex = 1, Text = p.TenSan });
                    } else
                    {
                        lv.Items.Add(new ListViewItem { ImageIndex = 0, Text = p.TenSan });
                    }
                }
                // add listview lên tabpage
                tp.Controls.Add(lv);
            }

            ShowMatHang();
            dgvDanhSachMatHang.Columns["mahang"].Visible = false; // ẩn cột mã hàng
            dgvDanhSachMatHang.Columns["tenhang"].HeaderText = "Mặt hàng";
            dgvDanhSachMatHang.Columns["dg"].HeaderText = "Gía";
            dgvDanhSachMatHang.Columns["tonkho"].HeaderText = "Tồn kho";

        }

        private void ShowMatHang()
        {
            // hiển thị danh sách mặt hàng
            var nhap = from p in db.ChiTietHoaDonNhaps.GroupBy(x => x.IDMatHang)
                       select new
                       {
                           mahang = p.First().IDMatHang,
                           tongnhap = p.Sum(x => x.SoLuong),
                       };

            var xuat = from p in db.ChiTietHoaDonBans.GroupBy(x => x.IDMatHang)
                       select new
                       {
                           mahang = p.First().IDMatHang,
                           tongxuat = p.Sum(x => x.IDMatHang),
                       };

            var khadung = from p in nhap
                          join q in xuat on p.mahang equals q.mahang into t
                          join h in db.MatHangs on p.mahang equals h.ID
                          from s in t.DefaultIfEmpty()
                          select new
                          {
                              mahang = p.mahang,
                              tenhang = h.TenMatHang,
                              dg = h.DonGiaBan,
                              tonkho = s.mahang == null ? p.tongnhap : p.tongnhap - s.tongxuat
                          };

            dgvDanhSachMatHang.DataSource = khadung.OrderBy(x => x.tenhang); 
        }

        private void timerDongHo_Tick(object sender, EventArgs e)
        {
            mtbBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
    }
}

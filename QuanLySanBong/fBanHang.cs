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
        private ListView lv;
        private void fBanHang_Load(object sender, EventArgs e)
        {
            db = new dbSanContentDataContext();
            var dsLoaiSan = db.LoaiSans; // lấy danh sách cho loại sân
            foreach(var l in dsLoaiSan)
            {
                TabPage tp = new TabPage(l.TenLoaiSan);
                tp.Name = l.ID.ToString();
                tbcContent.Controls.Add(tp);
            }
            var minIDLoaiPhong = db.LoaiSans.Min(x => x.ID);
            // mặc định sẽ load tabpage đầu tiên có tabIndex = 0
            LoadSan(minIDLoaiPhong, 0);

            ShowMatHang();
            dgvDanhSachMatHang.Columns["mahang"].Visible = false; // ẩn cột mã hàng
            dgvDanhSachMatHang.Columns["tenhang"].HeaderText = "Mặt hàng";
            dgvDanhSachMatHang.Columns["dg"].HeaderText = "Giá";
            dgvDanhSachMatHang.Columns["tonkho"].HeaderText = "Tồn";
            
            dgvDanhSachMatHang.Columns["dg"].Width = 70;
            dgvDanhSachMatHang.Columns["tonkho"].Width = 70;
            dgvDanhSachMatHang.Columns["tenhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvDanhSachMatHang.Columns["dg"].DefaultCellStyle.Format = "N0";
            dgvDanhSachMatHang.Columns["tonkho"].DefaultCellStyle.Format = "N0";
        }

        private void LoadSan(int loaisan, int tabIndex)
        {
            
                lv = new ListView(); // khai báo 1 listview
                lv.Dock = DockStyle.Fill;
                lv.SelectedIndexChanged += lv_SelectedIndexChanged;
                ImageList img1 = new ImageList();
                img1.ImageSize = new Size(150, 120);
                img1.Images.Add(Properties.Resources.free_san); // index = 0
                img1.Images.Add(Properties.Resources.inuse_san); // index = 1
                lv.LargeImageList = img1;

                var dsSan = db.Sans.Where(x => x.IDLoaiSan == loaisan);
                foreach (var p in dsSan)
                {
                    // add item lên listview
                    if (p.TrangThai == 1)
                    {
                        lv.Items.Add(new ListViewItem { ImageIndex = 1, Text = p.TenSan, Name = p.ID.ToString(), Tag = true }); // tag -true dùng để đánh dấu sân đang có khách
                    }
                    else
                    {
                        lv.Items.Add(new ListViewItem { ImageIndex = 0, Text = p.TenSan, Name = p.ID.ToString(), Tag = false }); // tag -false dùng để đánh dấu sân đang trống
                    }
                }
            // add listview lên tabpage
            tbcContent.TabPages[tabIndex].Controls.Add(lv);
        }
        int idPhong = 0;
        private string tensan;
        private long idHoaDon = 0;
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = lv.SelectedIndices;
            if (idx.Count > 0)
            {
                var idSan = int.Parse(lv.SelectedItems[0].Name);
                tensan = lv.SelectedItems[0].Text.ToUpper();
                lblSanDangChon.Text = tensan;
                if ((bool)lv.SelectedItems[0].Tag) // nếu sân đang có khách
                {
                    btnBatDau.Enabled = false;
                    btnKetThuc.Enabled = true;
                    // khi click vào item trên listview <=> click vào sân đang có khách
                    // lấy thông tin hóa đơn bán hàng dựa vào id sân
                    // lấy hóa đơn có id lớn nhất có mã sân đang được chọn
                    var hd = db.HoaDonBanHangs.FirstOrDefault(x=>x.IDHoaDon == db.HoaDonBanHangs.Where(y => y.IDSan == idSan).Max(z=>z.IDSan));
                    idHoaDon = hd.IDHoaDon;
                    // khi sân đang có khách -> thời gian bắt đầu được tính trong hóa đơn
                    timerDongHo.Enabled = false;
                    mtbBatDau.Text = ((DateTime)hd.ThoiGianBDau).ToString("dd/MM/yyyy HH:mm");

                    // lấy chi tiết hóa đơn bán hàng liên quan tới hóa đơn được lấy ở trên
                    // vì trong chitiethoadonban chỉ lưu mã hàng
                    // trong khi chúng ta cần lấy thông tin tường mình là tên mặt hàng
                    // nên cần join 2 bảng chitiethoadon va mathang dựa vào idmathang
                    var rs = from ct in db.ChiTietHoaDonBans.Where(x => x.IDHoaDon == hd.IDHoaDon)
                             join h in db.MatHangs on ct.IDMatHang equals h.ID
                             select new
                             {
                                 mahang = h.ID,
                                 tenhang = h.TenMatHang,
                                 sl = ct.SoLuong,
                                 dg = ct.DonGia,
                                 thanhtien = ct.SoLuong * ct.DonGia
                             };
                    dgvChiTietBanHang.DataSource = rs;
                    dgvChiTietBanHang.Columns["mahang"].Visible = false;
                    dgvChiTietBanHang.Columns["tenhang"].HeaderText = "Mặt hàng";
                    dgvChiTietBanHang.Columns["sl"].HeaderText = "SL";
                    dgvChiTietBanHang.Columns["dg"].HeaderText = "Đơn giá";
                    dgvChiTietBanHang.Columns["thanhtien"].HeaderText = "Thành tiền";

                    dgvChiTietBanHang.Columns["sl"].Width = 20;
                    dgvChiTietBanHang.Columns["dg"].Width = 30;
                    dgvChiTietBanHang.Columns["thanhtien"].Width = 60;
                    dgvChiTietBanHang.Columns["tenhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dgvChiTietBanHang.Columns["dg"].DefaultCellStyle.Format = "N0";
                    dgvChiTietBanHang.Columns["thanhtien"].DefaultCellStyle.Format = "N0";
                }
                else
                {
                    // nếu sân chưa có khách thì cho timer chạy để lấy giờ hiện tại làm giờ bắt đầu sử dụng sân
                    timerDongHo.Enabled = true;
                    dgvChiTietBanHang.DataSource = null;
                    btnBatDau.Enabled = true;
                    btnKetThuc.Enabled = false;
                }
            }
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

        private void dgvDanhSachMatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDanhSachMatHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (idPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn sân để tiếp tục", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e.RowIndex < 0)
            {
                return;
            }
            var r = dgvDanhSachMatHang.Rows[e.RowIndex];
            new fOrder(idHoaDon, r).ShowDialog();
        }

        private void tbcContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idLoaiSan = tbcContent.SelectedTab.Name; // lấy id loại sân đã được ở trên
            var tabIndex = tbcContent.SelectedIndex;
            LoadSan(int.Parse(idLoaiSan), tabIndex);
        }

        private void pnlControl_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

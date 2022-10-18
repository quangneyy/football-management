using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private ImageList img1;
        private string nhanvien = "admin";
        private void fBanHang_Load(object sender, EventArgs e)
        {
            db = new dbSanContentDataContext();
            var dsLoaiSan = db.LoaiSans; // lấy danh sách cho loại sân
            foreach (var l in dsLoaiSan)
            {
                TabPage tp = new TabPage(l.TenLoaiSan);
                tp.Name = l.ID.ToString();
                tbcContent.Controls.Add(tp);
            }
            idLoaiSan = db.LoaiSans.Min(x => x.ID);
            // mặc định sẽ load tabpage đầu tiên có tabIndex = 0
            LoadSan(idLoaiSan, tabIndex);

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

            showLSGD(); // gọi hàm LSGD khi load form
            dgvLSGD.Columns["idHoaDon"].Visible = false;
            dgvLSGD.Columns["san"].HeaderText = "Sân";
            dgvLSGD.Columns["tgBatDau"].HeaderText = "Bắt đầu";
            dgvLSGD.Columns["tgKetThuc"].HeaderText = "Kết thúc";
            dgvLSGD.Columns["soTien"].HeaderText = "Số tiền";
            dgvLSGD.Columns["sotien"].DefaultCellStyle.Format = "N0";
            dgvLSGD.Columns["sotien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void LoadSan(int loaisan, int tabIndex)
        {
            tbcContent.TabPages[tabIndex].Controls.Clear();
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
        int idLoaiSan = 0;
        private string tensan;
        private long idHoaDon = 0;
        private int idSan = 0;
        private int tabIndex = 0;
        private object ptReceipt;

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = lv.SelectedIndices;
            if (idx.Count > 0)
            {
                idSan = int.Parse(lv.SelectedItems[0].Name);
                tensan = lv.SelectedItems[0].Text.ToUpper();
                lblSanDangChon.Text = tensan;
                if ((bool)lv.SelectedItems[0].Tag) // nếu sân đang có khách
                {
                    btnBatDau.Enabled = false;
                    btnKetThuc.Enabled = true;
                    // khi click vào item trên listview <=> click vào sân đang có khách
                    // lấy thông tin hóa đơn bán hàng dựa vào id sân
                    // lấy hóa đơn có id lớn nhất có mã sân đang được chọn
                    var hd = db.HoaDonBanHangs.FirstOrDefault(x => x.IDHoaDon == db.HoaDonBanHangs.Where(y => y.IDSan == idSan).Max(z => z.IDHoaDon));
                    idHoaDon = hd.IDHoaDon;
                    // khi sân đang có khách -> thời gian bắt đầu được tính trong hóa đơn

                    mtbKetThuc.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm"); // giờ kết thúc bằng giờ hiện tại
                    mtbBatDau.Text = ((DateTime)hd.ThoiGianBDau).ToString("dd/MM/yyyy HH:mm");

                    ShowChiTietHoaDon();
                }
                else
                {
                    // nếu sân chưa có khách thì cho timer chạy để lấy giờ hiện tại làm giờ bắt đầu sử dụng sân
                    dgvChiTietBanHang.DataSource = null;
                    mtbBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm"); // giờ bắt đầu bằng giờ hiện tại
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

        private void dgvDanhSachMatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDanhSachMatHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (idSan == 0)
            {
                MessageBox.Show("Vui lòng chọn sân để tiếp tục", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
            if (e.RowIndex < 0)
            {
                return;
            }

            // chỉ hiển thị fOrder khi sân đang ở tạng thái có khách
            var san = db.Sans.SingleOrDefault(x => x.ID == idSan);
            /*if (san.TrangThai == 0)
            {
                return; // nếu phòng trông thì không thực hiện câu lệnh phía dưới
            }*/

            var r = dgvDanhSachMatHang.Rows[e.RowIndex];
            new fOrder(idHoaDon, tensan, r).ShowDialog();
            ShowMatHang(); // sau khi form fOrder đóng lại gọi hàm hiển thị thông tin mặt hàng để cập nhật lại tồn kho
            ShowChiTietHoaDon();
        }

        private void tbcContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            idLoaiSan = int.Parse(tbcContent.SelectedTab.Name); // lấy id loại sân đã được ở trên
            tabIndex = tbcContent.SelectedIndex;
            LoadSan(idLoaiSan, tabIndex);
        }

        private void pnlControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowChiTietHoaDon()
        {
            // lấy chi tiết hóa đơn bán hàng liên quan tới hóa đơn được lấy ở trên
            // vì trong chitiethoadonban chỉ lưu mã hàng
            // trong khi chúng ta cần lấy thông tin tường mình là tên mặt hàng
            // nên cần join 2 bảng chitiethoadon va mathang dựa vào idmathang
            var rs = from ct in db.ChiTietHoaDonBans.Where(x => x.IDHoaDon == idHoaDon)
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

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            try
            {
                // tạo đơn hàng xong cần cập nhật lại trạng thái sân
                var p = db.Sans.SingleOrDefault(x => x.ID == idSan);
                // lấy ra loại sân tương ứng sân được chọn
                var lp = db.LoaiSans.SingleOrDefault(x => x.ID == p.IDLoaiSan);

                var od = new HoaDonBanHang();
                od.IDSan = idSan;
                od.NguoiBan = nhanvien;
                od.ThoiGianBDau = DateTime.ParseExact(mtbBatDau.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                od.NgayTao = DateTime.Now;
                od.NguoiTao = nhanvien;
                od.DonGiaSan = lp.DonGia;

                db.HoaDonBanHangs.InsertOnSubmit(od);
                db.SubmitChanges();

                p.TrangThai = 1;
                db.SubmitChanges();
                LoadSan(idLoaiSan, tabIndex);
                btnBatDau.Enabled = false;
                btnKetThuc.Enabled = true;
                MessageBox.Show("Gọi sân thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Gọi sân thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            try
            {


                // cập nhật trạng thái thời gian kết thúc cho hóa đơn bán hàng
                var hd = db.HoaDonBanHangs.SingleOrDefault(x => x.IDHoaDon == idHoaDon);
                hd.ThoiGianKetThuc = DateTime.ParseExact(mtbKetThuc.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                db.SubmitChanges();

                // cập nhật lại cho sân từ có khách -> không có khách
                var p = db.Sans.SingleOrDefault(x => x.ID == idSan);
                p.TrangThai = 0;
                db.SubmitChanges();

                // load lại danh sách sân
                LoadSan(idLoaiSan, tabIndex);

                // reset lại các component
                mtbBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                btnBatDau.Enabled = true;
                btnKetThuc.Enabled = false;
                MessageBox.Show("Thanh toán sân thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showLSGD();

                idHoaDon = hd.IDHoaDon;
                InHoaDon(); //gọi tới hàm in hóa đơn khi kết thúc sử dụng sân
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thanh toán sân thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showLSGD()
        {
            var result = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGianKetThuc != null)
                         join p in db.Sans on hd.IDSan equals p.ID
                         join ct in db.ChiTietHoaDonBans.GroupBy(t => t.IDHoaDon)
                         on hd.IDHoaDon equals ct.First().IDHoaDon
                         select new
                         {
                             idHoaDon = hd.IDHoaDon,
                             san = p.TenSan,
                             tgBatDau = DateTime.Parse(hd.ThoiGianBDau.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             tgKetThuc = DateTime.Parse(hd.ThoiGianKetThuc.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             soTien = ((TimeSpan)((DateTime)hd.ThoiGianKetThuc - (DateTime)hd.ThoiGianBDau)).TotalHours * hd.DonGiaSan // tiền sân 
                             + ct.Sum(x => x.SoLuong * x.DonGia) // tiền hàng
                         };
            dgvLSGD.DataSource = result;
        }

        private void dgvLSGD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idHoaDon = long.Parse(dgvLSGD.Rows[e.RowIndex].Cells["idHoaDon"].Value.ToString());
                InHoaDon();
            }
        }

        // hàm xử lý in hóa đơn
        private void InHoaDon()
        {
            pddHoaDon.Document = pdHoaDon;
            pddHoaDon.ShowDialog();
        }

        private void pdHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string tenSanBong = "Sân Bóng Naruto";

            // lấy hóa đơn dựa vào idhoadon
            var hd = db.HoaDonBanHangs.SingleOrDefault(x => x.IDHoaDon == idHoaDon);

            // lấy bề rộng của giấy in 
            var w = pdHoaDon.DefaultPageSettings.PaperSize.Width;

            // vẽ header của bill
            //1 .tên sân bóng
            e.Graphics.DrawString(
                tenSanBong.ToUpper(),
                new Font("Courier New", 12, FontStyle.Bold),
                Brushes.Black, new Point(100, 20)
                );

            // thời gian in hóa đơn
            e.Graphics.DrawString(
                    String.Format("HD{0}", hd.IDHoaDon),
                    new Font("Courier New", 12, FontStyle.Bold),
                    Brushes.Black,
                    new Point(w / 2 + 200, 20)
                    );

            // ngày giờ xuát hóa đơn
            e.Graphics.DrawString(
                String.Format("{0}", DateTime.Now.ToString("dd/MM/yyyy HH:mm")),
                new Font("Courier New", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(w / 2 + 200, 20)
                );

            // định dạng bút vẽ
            Pen blackPen = new Pen(Color.Black, 1);

            // tọa độ theo chiều dọc
            var y = 70;

            // định nghĩa 2 điểm để vẽ đường thẳng
            // cách lề trái 10, cách lề phải 10
            Point p1 = new Point(10, y);
            Point p2 = new Point(w - 10, y);
            // kẻ đường thẳng thứ nhất
            e.Graphics.DrawLine(blackPen, p1, p2);

            y += 10;
            e.Graphics.DrawString(
                    String.Format("Giờ bắt đầu: {0}",
                    ((DateTime)hd.ThoiGianBDau).ToString("dd/MM/yyyy HH:mm")),
                    new Font("Courier New", 12, FontStyle.Bold),
                    Brushes.Black, new Point(10, y)
                );

            e.Graphics.DrawString(
                    String.Format("Giờ kết thúc: {0}",
                    ((DateTime)hd.ThoiGianKetThuc).ToString("dd/MM/yyyy HH:mm")),
                    new Font("Courier New", 12, FontStyle.Bold),
                    Brushes.Black, new Point(w / 2, y)
                );

            y += 20;
            // tổng tiền
            int sum = 0;

            var tgsd = ((DateTime)hd.ThoiGianKetThuc - (DateTime)hd.ThoiGianBDau).TotalMinutes;

            var gio = (int)(tgsd / 60);
            var phut = tgsd % 60;

            // Tiền sử dụng sân
            var tiensan = (int)Math.Round((double)(tgsd / 60 * hd.DonGiaSan) / 1000, 3) * 1000;
            sum += tiensan;

            // hiển thị thời gian sử dụng sân
            e.Graphics.DrawString(String.Format("Thời gian sử dụng: {0}:{1}", gio, phut), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(10, y));

            // hiển thị tiền sân 
            e.Graphics.DrawString(String.Format("Thành tiền: {0:N0} VNĐ", tiensan), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));

            // set lại tọa đọ cho 2 điểm để vẽ đường thẳng thứ 2
            y += 20;
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPen, p1, p2);

            #region body
            y += 10;
            e.Graphics.DrawString("STT", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString("Mặt hàng", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(50, y));
            e.Graphics.DrawString("SL", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString("Đơn giá", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));
            e.Graphics.DrawString("Thành tiền", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
            

            // lấy dữ liệu hóa đơn dựa trên idhoadon
            var result = from ct in db.ChiTietHoaDonBans.Where(x => x.IDHoaDon == idHoaDon)
                         join h in db.MatHangs on ct.IDMatHang equals h.ID
                         select new
                         {
                             TenMatHang = h.TenMatHang,
                             SL = (int)ct.SoLuong,
                             DG = (int)ct.DonGia,
                             ThanhTien = ct.SoLuong * ct.DonGia,
                         };

            // lặp các phần tử của mảng
            // mỗi phần tử tương ứng 1 hàng trên bill
            int i = 1;
            y += 20;
            foreach (var l in result)
            {
                sum += l.SL * l.DG;
                e.Graphics.DrawString(string.Format("{0}", i++), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(10, y));
                e.Graphics.DrawString(l.TenMatHang, new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.SL), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.DG), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.ThanhTien), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
                y += 20;
            }
            #endregion
            y += 40;

            // set lại tọa đọ cho 2 điểm để vẽ đường thẳng thứ 3
            y += 20;
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPen, p1, p2);

            // tổng tiền thanh toán
            y += 20;
            e.Graphics.DrawString(string.Format("Tổng tiền: {0:N0} VNĐ", sum), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));

            y += 40;
            e.Graphics.DrawString(string.Format("Xin chân thành cảm ơn sự ủng hộ của quý khách!"), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
        }
    }
}

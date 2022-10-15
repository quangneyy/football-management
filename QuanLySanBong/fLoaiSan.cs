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
    public partial class fLoaiSan : Form
    {
        public fLoaiSan()
        {
            InitializeComponent();
        }

        private dbSanContentDataContext db;

        private string nhanvien = "admin";
        private void fLoaiSan_Load(object sender, EventArgs e)
        {
            db = new dbSanContentDataContext();
            ShowData();

            // tùy chỉnh lại thuộc tính hiển thị
            dgvLoaiSan.Columns["id"].HeaderText = "Mã loại";
            dgvLoaiSan.Columns["tenloaisan"].HeaderText = "Tên loại sân";
            dgvLoaiSan.Columns["dongia"].HeaderText = "Đơn giá";

            // bề rộng
            dgvLoaiSan.Columns["id"].Width = 100;
            dgvLoaiSan.Columns["dongia"].Width = 150;
            dgvLoaiSan.Columns["tenloaisan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // định dạng cho đơn giá
            dgvLoaiSan.Columns["dongia"].DefaultCellStyle.Format = "N0";
        }

        private void ShowData()
        {
            var rs = from h in db.LoaiSans
                     select new
                     {
                         h.ID,
                         h.TenLoaiSan,
                         h.DonGia,
                     };
            dgvLoaiSan.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbLoaiSan.Text)) // kiểm tra không được rỗng
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbLoaiSan.Select();
                return; //dừng ngay
            }

            if (string.IsNullOrEmpty(txbDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbDonGia.Select();
                return; //dừng ngay
            }

            LoaiSan l = new LoaiSan();
            l.TenLoaiSan = txbLoaiSan.Text;
            l.DonGia = int.Parse(txbDonGia.Text);
            l.NgayTao = DateTime.Now;
            l.NguoiTao = nhanvien;

            db.LoaiSans.InsertOnSubmit(l); // thêm vào db
            db.SubmitChanges(); // lưu
            MessageBox.Show("Thêm mới loại sân thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ShowData(); // hien thi loai phong

            txbDonGia.Text = "0";
            txbLoaiSan.Text = null;
        }

        private void txbDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) // chỉ cho phép nhập số tự nhiên
            {
                e.Handled = true;
            }
        }

        private DataGridViewRow r;

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng muốn cập nhập", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // dừng ngay không thực hiện chương trình tiếp theo
            }
            // r!= null là có 1 hàng nào đó mà đã được lựa chọn

            var l = db.LoaiSans.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            l.TenLoaiSan = txbLoaiSan.Text;
            l.DonGia = int.Parse(txbDonGia.Text);

            l.NgayCapNhat = DateTime.Now;
            l.NguoiCapNhat = nhanvien;

            db.SubmitChanges();

            MessageBox.Show("Cập nhật loại phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData(); // hiển thị danh sách khi thêm mới thành công

            txbDonGia.Text = "0";
            txbLoaiSan.Text = null;
            r = null; // không còn hàng nào được chọn
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng muốn cập nhập", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // dừng ngay không thực hiện chương trình tiếp theo
            }
            if (
                    MessageBox.Show("Bạn thực sự muốn xóa loại sân: " + r.Cells["tenloaisan"].Value.ToString()+" ?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
                try
                {
                    var l = db.LoaiSans.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                    db.LoaiSans.DeleteOnSubmit(l);
                    db.SubmitChanges();

                    MessageBox.Show("Xóa loại sân thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData(); // hiển thị danh sách khi thêm mới thành công

                    txbDonGia.Text = "0";
                    txbLoaiSan.Text = null;
                    r = null; // không còn hàng nào được chọn
                }
                catch
                {
                    // vì phòng và loại phòng được liên kết bằng khóa ngoại
                    // trong trường hợp đã có sân tham chiếu tới mã loại đang xóa thì sẽ không xóa được (quan hệ 1-n update/delete)
                    // vì vậy sẽ phát sinh trường hợp catch này
                    MessageBox.Show("Xóa loại sân thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvLoaiSan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvLoaiSan.Rows[e.RowIndex];
                txbLoaiSan.Text = r.Cells["tenloaisan"].Value.ToString();
                txbDonGia.Text = r.Cells["dongia"].Value.ToString();
            }
        }
    }
}

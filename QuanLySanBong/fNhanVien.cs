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
    public partial class fNhanVien : Form
    {
        public fNhanVien()
        {
            InitializeComponent();
        }

        private dbSanContentDataContext db;
        private void fNhanVien_Load(object sender, EventArgs e)
        {
            db = new dbSanContentDataContext();
            ShowData();

            dgvNhanVien.Columns["password"].Visible = false; // ẩn cột mật khẩu
            dgvNhanVien.Columns["Username"].HeaderText = "Tài khoản";
            dgvNhanVien.Columns["hovaten"].HeaderText = "Họ và tên";
            dgvNhanVien.Columns["dienthoai"].HeaderText = "Điện thoại";
            dgvNhanVien.Columns["diachi"].HeaderText = "Địa chỉ";

            dgvNhanVien.Columns["username"].Width = 100;
            dgvNhanVien.Columns["dienthoai"].Width = 100;
            dgvNhanVien.Columns["hovaten"].Width = 100;
            dgvNhanVien.Columns["diachi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ShowData()
        {
            var rs = from nv in db.NhanViens
                     select new
                     {
                         nv.Username,
                         nv.Password,
                         nv.HoVaTen,
                         nv.DienThoai,
                         nv.DiaChi,
                     };
            dgvNhanVien.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản nhân viên", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTaiKhoan.Select();
                return;
            }
            if (string.IsNullOrEmpty(txbMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbMatKhau.Select();
                return;
            }

            // kiểm tra tài khoản có tồn tại trong csdl không
            var c = db.NhanViens.Where(x => x.Username.Trim().ToLower() == txbTaiKhoan.Text.Trim().ToLower()).Count();
            if (c > 0)
            {
                MessageBox.Show("Tài khoản này đã tồn tại", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTaiKhoan.Select();
                return;
            }

            var nv = new NhanVien();
            nv.Username = txbTaiKhoan.Text.Trim().ToLower();
            nv.Password = txbMatKhau.Text;
            nv.HoVaTen = txbHoTen.Text;
            nv.DienThoai = txbDienThoai.Text;
            nv.DiaChi = txbDiaChi.Text;

            db.NhanViens.InsertOnSubmit(nv);
            db.SubmitChanges();
            MessageBox.Show("Thêm mới nhân viên thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ShowData();
            txbTaiKhoan.Text = txbMatKhau.Text = txbDiaChi.Text = txbDienThoai.Text = txbHoTen.Text = null;
        }

        private DataGridViewRow r;
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvNhanVien.Rows[e.RowIndex];
                txbTaiKhoan.Text = r.Cells["username"].Value.ToString();
                txbMatKhau.Text = r.Cells["password"].Value.ToString();
                txbHoTen.Text = r.Cells["hovaten"].Value.ToString();
                txbDienThoai.Text = r.Cells["dienthoai"].Value.ToString();
                txbDiaChi.Text = r.Cells["diachi"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên muốn cập nhập", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // dừng ngay không thực hiện chương trình tiếp theo
            }

            var nv = db.NhanViens.SingleOrDefault(x => x.Username == r.Cells["username"].Value.ToString());
            nv.Password = txbMatKhau.Text;
            nv.HoVaTen = txbHoTen.Text;
            nv.DienThoai = txbDienThoai.Text;
            nv.DiaChi = txbDiaChi.Text;

            db.SubmitChanges();
            MessageBox.Show("Cập nhật nhân viên thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ShowData();
            txbTaiKhoan.Text = txbMatKhau.Text = txbDiaChi.Text = txbDienThoai.Text = txbHoTen.Text = null;
            r = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng muốn xóa", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // dừng ngay không thực hiện chương trình tiếp theo
            }
            if (
                    MessageBox.Show("Bạn thực sự muốn xóa nhân viên: " + r.Cells["username"].Value.ToString() + " ?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
                try
                {
                    var nv = db.NhanViens.SingleOrDefault(x => x.Username == r.Cells["username"].Value.ToString());
                    db.NhanViens.DeleteOnSubmit(nv);
                    db.SubmitChanges();

                    MessageBox.Show("Xóa nhân viên thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
                }
                catch
                {
                    // vì phòng và loại phòng được liên kết bằng khóa ngoại
                    // trong trường hợp đã có sân tham chiếu tới mã loại đang xóa thì sẽ không xóa được (quan hệ 1-n update/delete)
                    // vì vậy sẽ phát sinh trường hợp catch này
                    MessageBox.Show("Xóa nhân viên thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ShowData(); // hiển thị danh sách khi thêm mới thành công

                    txbTaiKhoan.Text = txbMatKhau.Text = txbDiaChi.Text = txbDienThoai.Text = txbHoTen.Text = null;
                    r = null; // không còn hàng nào được chọn
                }
            }
        }
    }
}

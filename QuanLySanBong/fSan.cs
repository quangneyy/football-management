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
    public partial class fSan : Form
    {
        public fSan()
        {
            InitializeComponent();
        }

        private dbSanContentDataContext db;
        private string nhanvien = "admin"; // tạm thời dùng admin
        private void fSan_Load(object sender, EventArgs e)
        {
            db = new dbSanContentDataContext();
            ShowData(); // goi hàm hiển thị danh sách sân khi form được load

            // đổ dữ liệu cho combobox cbbLoaiSan
            cbbLoaiSan.DataSource = db.LoaiSans;
            cbbLoaiSan.DisplayMember = "tenloaisan"; // thuộc tính hiển thị
            cbbLoaiSan.ValueMember = "id";
            cbbLoaiSan.SelectedIndex = -1; // mặc định không chọn loại sân nào cả

            // tùy chỉnh thuộc tính
            dgvSan.Columns["id"].HeaderText = "Mã sân";
            dgvSan.Columns["tenloaisan"].HeaderText = "Loại sân";
            dgvSan.Columns["tensan"].HeaderText = "Tên sân";
            dgvSan.Columns["dongia"].HeaderText = "Đơn giá";

            // bề rộng
            dgvSan.Columns["id"].Width = 100;
            dgvSan.Columns["tenloaisan"].Width = 200;
            dgvSan.Columns["dongia"].Width = 100;
            dgvSan.Columns["tensan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // định dạng cho đơn giá
            dgvSan.Columns["dongia"].DefaultCellStyle.Format = "N0";
        }

        private void ShowData()
        {
            // theo thiết kế thì 2 bảng Sân và loại sân quan hệ với nhau 1 - n
            // dưa vào khóa ngoại [IDLoaiSan]
            // nên lấy dữ liệu từ 2 bảng này, chúng ta sử dụng join trong linq
            var rs = from p in db.Sans
                     join l in db.LoaiSans on p.IDLoaiSan equals l.ID
                     select new
                     {
                         p.ID,
                         l.TenLoaiSan,
                         p.TenSan,
                         l.DonGia,
                     };
            dgvSan.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbTenSan.Text)) // kiểm tra không được rỗng
            {
                MessageBox.Show("Vui lòng nhập tên sân", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTenSan.Select();
                return; //dừng ngay
            }
            if (cbbLoaiSan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại sân", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //dừng ngay
            }

            var p = new San();
            p.TenSan = txbTenSan.Text;
            p.IDLoaiSan = int.Parse(cbbLoaiSan.SelectedValue.ToString());

            p.NgayTao = DateTime.Now;
            p.NguoiTao = nhanvien;

            db.Sans.InsertOnSubmit(p);
            db.SubmitChanges();

            MessageBox.Show("Thêm mới sân thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData(); // gọi lại hàm hiển thị danh sách sân

            //reset
            cbbLoaiSan.SelectedIndex = -1;
        }

        private DataGridViewRow r;

        private void dgvSan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex >= 0)
            {
                r = dgvSan.Rows[e.RowIndex];
                txbTenSan.Text = r.Cells["tensan"].Value.ToString();
                cbbLoaiSan.Text = r.Cells["tenloaisan"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbTenSan.Text)) // kiểm tra không được rỗng
            {
                MessageBox.Show("Vui lòng nhập tên sân", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTenSan.Select();
                return; //dừng ngay
            }
            if (cbbLoaiSan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại sân", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //dừng ngay
            }

            var p = db.Sans.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            p.TenSan = txbTenSan.Text;
            p.IDLoaiSan = int.Parse(cbbLoaiSan.SelectedValue.ToString());

            p.NgayCapNhat = DateTime.Now;
            p.NguoiCapNhat = nhanvien;
            db.SubmitChanges();
            MessageBox.Show("Cập nhật sân thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData(); // hiển thị danh sách khi cập nhât thành công

            txbTenSan.Text = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn sân muốn xóa", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // dừng ngay không thực hiện chương trình tiếp theo
            }
            if (
                    MessageBox.Show("Bạn thực sự muốn xóa sân: " + r.Cells["tensan"].Value.ToString() + " ?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
                try
                {
                    var l = db.Sans.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                    db.Sans.DeleteOnSubmit(l);
                    db.SubmitChanges();

                    MessageBox.Show("Xóa sân thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData(); // hiển thị danh sách khi thêm mới thành công

                    txbTenSan.Text = null;
                    cbbLoaiSan.SelectedIndex = -1;
                    r = null; // không còn hàng nào được chọn
                }
                catch
                {
                    // vì phòng và loại phòng được liên kết bằng khóa ngoại
                    // trong trường hợp đã có sân tham chiếu tới mã loại đang xóa thì sẽ không xóa được (quan hệ 1-n update/delete)
                    // vì vậy sẽ phát sinh trường hợp catch này
                    MessageBox.Show("Xóa sân thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

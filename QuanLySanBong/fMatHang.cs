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
        private string nhanvien = "admin"; // tạm thời khai báo admin
        private DataGridViewRow r;

        private void fMatHang_Load(object sender, EventArgs e)
        {
            db = new dbSanContentDataContext(); // khoitao doi tuong db
            ShowData(); // hien thi danh sach mat hang

            dgvMatHang.Columns["id"].Width = 100;
            dgvMatHang.Columns["dongiaban"].Width = 100;
            dgvMatHang.Columns["tenmathang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvMatHang.Columns["dongiaban"].DefaultCellStyle.Format = "N0";

            // đặt lại lại tên cột
            dgvMatHang.Columns["id"].HeaderText = "Mã hàng";
            dgvMatHang.Columns["dongiaban"].HeaderText = "Đơn giá";
            dgvMatHang.Columns["tenmathang"].HeaderText = "Tên mặt hàng";
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
            if (string.IsNullOrEmpty(txbTenMatHang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTenMatHang.Select();
                return;
            }
            if (string.IsNullOrEmpty(txbDonGia.Text))
            {
                MessageBox.Show("Vui lòng đơn giá mặt hàng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTenMatHang.Select();
                return;
            }


            var mh = new MatHang();
            mh.TenMatHang = txbTenMatHang.Text;
            mh.DonGiaBan = int.Parse(txbDonGia.Text);

            mh.NgayTao = DateTime.Now;
            mh.NguoiTao = nhanvien;

            db.MatHangs.InsertOnSubmit(mh); // thêm mặt hàng vào DB
            db.SubmitChanges(); // lưu

            ShowData(); // sau khi thêm xong cập nhật danh sách hiển thị mặt hàng
            MessageBox.Show("Thêm mới mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // reset lại giá trị cho các component
            txbTenMatHang.Text = null;
            txbDonGia.Text = "0";
        }

        private void txbDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) // chỉ cho phép nhập số tự nhiên vào txb
            {
                e.Handled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            // tìm ra mặt hàng trong DB cần được cập nhật dựa vào khóa chính là id của mặt hàng
            var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            
            // ràng buộc dữ liệu
            if (string.IsNullOrEmpty(txbTenMatHang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTenMatHang.Select();
                return;
            }
            if (string.IsNullOrEmpty(txbDonGia.Text))
            {
                MessageBox.Show("Vui lòng đơn giá mặt hàng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTenMatHang.Select();
                return;
            }

            // cập nhật cho các mặt hàng được tì thấy ở trên
            mh.TenMatHang = txbTenMatHang.Text;
            mh.DonGiaBan = int.Parse(txbDonGia.Text);

            mh.NgayCapNhat = DateTime.Now;
            mh.NguoiCapNhat = nhanvien;

            db.SubmitChanges();

            ShowData(); // sau khi thêm xong cập nhật danh sách hiển thị mặt hàng
            MessageBox.Show("Cập nhật mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // reset lại giá trị cho các component
            txbTenMatHang.Text = null;
            txbDonGia.Text = "0";
        }

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvMatHang.Rows[e.RowIndex]; // xác định một hàng vừa được click

                // set các giá trị cho các component 
                txbTenMatHang.Text = r.Cells["tenmathang"].Value.ToString();
                txbDonGia.Text = r.Cells["dongiaban"].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // xóa mặt hàng cũng phải dựa vào hàng được click trên datagridview
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần xóa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (
                    MessageBox.Show("Bạn thực sự muốn xóa mặt hàng: " + r.Cells["tenmathang"].Value.ToString() + " ?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
                try
                {
                    var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                    db.MatHangs.DeleteOnSubmit(mh);
                    db.SubmitChanges();

                    MessageBox.Show("Xóa mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    // vì phòng và loại phòng được liên kết bằng khóa ngoại
                    // trong trường hợp đã có sân tham chiếu tới mã loại đang xóa thì sẽ không xóa được (quan hệ 1-n update/delete)
                    // vì vậy sẽ phát sinh trường hợp catch này
                    MessageBox.Show("Xóa mặt hàng thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ShowData(); // hiển thị danh sách khi thêm mới thành công

                    txbTenMatHang.Text = txbDonGia.Text = null;
                    r = null; // không còn hàng nào được chọn
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySanBong.Model;

namespace QuanLySanBong
{
    public partial class fMatHang : Form
    {
        public fMatHang()
        {
            InitializeComponent();
        }

        private DBSanContent db;
        private string nhanvien = "admin";
        private DataGridViewRow r;
        private void fMatHang_Load(object sender, EventArgs e)
        {
            db = new DBSanContent(); //khởi tạo đối tượng DB
            showData(); // hiển thị giá trị danh sách mặt hàng

            dgvMatHang.Columns["id"].Width = 100;
            dgvMatHang.Columns["dongiaban"].Width = 100;
            dgvMatHang.Columns["tenmathang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void showData()
        {
            var rs = (from h in db.MatHang
                     select new 
                     {
                         h.ID,
                         h.TenMatHang,
                         h.DonGiaBan
                     }).ToList();
            dgvMatHang.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txbTenMatHang.Text)) // kiểm tra không được rỗng
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTenMatHang.Select();
                return; //dừng ngay
            }

            if (string.IsNullOrEmpty(txbDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //dừng ngay
            }
            MatHang mh = new MatHang();
            mh.TenMatHang = txbTenMatHang.Text;
            mh.DonGiaBan = int.Parse(txbDonGia.Text);

            mh.NgayTao = DateTime.Now;
            mh.NguoiTao = nhanvien;

            db.MatHang.Add(mh);
            db.SaveChanges(); // lưu

            showData();
            MessageBox.Show("Thêm mới mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txbTenMatHang.Text = null;
            txbDonGia.Text = "0";
        }

        private void txbDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) // chỉ cho phép nhập số tự nhiên
            {
                e.Handled = true;
            }    
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var mh = db.MatHang.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));

            if (string.IsNullOrEmpty(txbTenMatHang.Text)) // kiểm tra không được rỗng
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTenMatHang.Select();
                return; //dừng ngay
            }

            if (string.IsNullOrEmpty(txbDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //dừng ngay
            }

            // cập nhật lại hàng vừa được tìm thấy
            mh.TenMatHang = txbTenMatHang.Text;
            mh.DonGiaBan = int.Parse(txbDonGia.Text);

            mh.NgayCapNhat = DateTime.Now;
            mh.NguoiCapNhat = nhanvien;

            db.SaveChanges();

            showData();
            MessageBox.Show("Cập nhật mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txbTenMatHang.Text = null;
            txbDonGia.Text = "0";
        }

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvMatHang.Rows[e.RowIndex]; // xác định 1 hàng vừa click

                // set các giá trị cho các component
                txbTenMatHang.Text = r.Cells["tenmathang"].Value.ToString();
                txbDonGia.Text = r.Cells["dongiaban"].Value.ToString();
            }
        }

        /*private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show(
                "Bạn có muốn xóa mặt hàng: " + r.Cells["tenmathang"].Value.ToString()+"?",
                "Xác nhận xóa mặt hàng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                ) == DialogResult.Yes
                )
            }*/
        }
    }
}

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
    }
}

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
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public NhanVien nv;
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbTaiKhoan.Text) || string.IsNullOrEmpty(txbMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTaiKhoan.Select();
                return;
            }

            dbSanContentDataContext db = new dbSanContentDataContext();
            var tk = db.NhanViens.SingleOrDefault(x => x.Username == txbTaiKhoan.Text && x.Password == txbMatKhau.Text);
            if (tk != null)
            {
                nv = tk;
                this.Dispose();
            } else
            {
                MessageBox.Show("Vui lòng kiểm tra lại tài khoản và mật khẩu", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTaiKhoan.Select();
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

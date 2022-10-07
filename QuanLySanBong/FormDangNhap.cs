using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using QuanLySanBong.DAO;

namespace QuanLySanBong
{
    public partial class FormDangNhap : Form
    {
       
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txtTaiKhoan.Text;
            string passWord = txtMatKhau.Text;
            if (Login(userName, passWord))
            {
                fTableManager f = new fTableManager();
                this.Hide();
                f.ShowDialog();
                this.Show();
            } 
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }

        bool Login (string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thật sự muốn xóa chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}

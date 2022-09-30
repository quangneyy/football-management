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
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8FJ7VHUC\SQLEXPRESS;Initial Catalog=QLSanBanh;Integrated Security=True");
            try
            {
                con.Open();
                string taiKhoan = txtTaiKhoan.Text;
                string matKhau = txtMatKhau.Text;
                string sql = "select * from TaiKhoan where Username = '"+taiKhoan+"' and Password = '"+matKhau+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read() == true)
                {
                    MessageBox.Show("ĐĂNG NHẬP THÀNH CÔNG");
                    FormMenu f = new FormMenu();
                    f.Show();
                    this.Hide();
                } else
                {
                    MessageBox.Show("ĐĂNG NHẬP THẤT BẠI");
                }
            } 
            catch (Exception)
            {
                MessageBox.Show("LỖI KẾT NỐI");
            }
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
    }
}

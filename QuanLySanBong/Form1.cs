﻿using System;
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
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J16KJ8A\SQLEXPRESS;Initial Catalog=QLSanBanh;Integrated Security=True");
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
    }
}

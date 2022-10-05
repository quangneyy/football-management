using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            new FormDangNhap().Show();
        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {

        }

        private void btnDatSan_Click(object sender, EventArgs e)
        {

        }

        private void btnQLKH_Click_1(object sender, EventArgs e)
        {

        }
    }
}

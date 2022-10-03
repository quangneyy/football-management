using QuanLySanBong.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

        private void btnDatSan_Click(object sender, EventArgs e)
        {

        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
              //< data name = "bongda-3" type = "System.Resources.ResXFileRef, System.Windows.Forms" >
   // < value > ..\Resources\bongda - 3.png; System.Drawing.Bitmap, System.Drawing, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a </ value >
  //</ data >
        }

        private void btnQLDV_Click(object sender, EventArgs e)
        {
            FormQLdichvu fqldv = new FormQLdichvu();
            fqldv.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void btnQLSan_Click(object sender, EventArgs e)
        {
            Form1QLSancs fqls = new Form1QLSancs();
            fqls.Show();
            this.Hide();
        }
    }
}

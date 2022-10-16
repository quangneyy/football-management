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
    public partial class fOrder : Form
    {
        public fOrder(long idHoaDon, DataGridViewRow r)
        {
            this.idHoaDon = idHoaDon;
            this.r = r;
            InitializeComponent();
        }

        private long idHoaDon;
        private DataGridViewRow r; 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void fOrder_Load(object sender, EventArgs e)
        {
            this.lblTenMatHang.Text = r.Cells["tenhang"].Value.ToString();
        }
    }
}

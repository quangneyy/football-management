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
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
            loadSan();
        }

        #region Method
        void loadSan()
        {

        }
        #endregion


        #region Events
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fMenu f = new fMenu();
            f.ShowDialog();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongTinCaNhan f = new fThongTinCaNhan();
            f.ShowDialog();
        }
        #endregion
    }
}

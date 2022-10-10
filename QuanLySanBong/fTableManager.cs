using QuanLySanBong.DAO;
using QuanLySanBong.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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

        #endregion
        void loadSan()
        {
            List<Table> tablelist = SanDAO.Instancce.loadSanList();
            foreach (Table table in tablelist)
            {

                Button button = new Button() { Width = SanDAO.widthSan, Height = SanDAO.heightSan };
                button.Text = table.Tensan + Environment.NewLine + table.Trangthai ;
                button.Click += Button_Click;
                button.Tag = table;
                switch (table.Trangthai)
                {
                    case "Trong":
                        button.BackColor = Color.Aqua;
                        break;
                    default:
                        button.BackColor = Color.Red;
                        break;
                }
                flpSan.Controls.Add(button);
            }
        }

        void showHoaDon(int id)
        {
            List<HoaDonInfo> hdinfo = HoaDonInfoDAO.Instanse.getHoaDonInfo(HoaDonDAO.Instanse.getHoaDOn(id));
            foreach (HoaDonInfo item in hdinfo)
            {
                ListViewItem listhd = new ListViewItem(item.IdThucUong.ToString());
                listhd.SubItems.Add(item.Count.ToString());
                

            }
        }
        
        #region Events
        private void Button_Click(object sender, EventArgs e)
        {
            int tableId = ((sender as Button).Tag as Table ).Id;
            showHoaDon(tableId);
            
        }
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

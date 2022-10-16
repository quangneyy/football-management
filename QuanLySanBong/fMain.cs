using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySanBong.DB;

namespace QuanLySanBong
{
    public partial class fMain : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public fMain()
        {
            InitializeComponent();
        }

        private Boolean isMaximize = false;
        private void ptbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ptbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ptbMaximize_Click(object sender, EventArgs e)
        {
            if (!isMaximize)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;

            } else
            {
                this.WindowState = FormWindowState.Normal;
            }
            isMaximize = !isMaximize;
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private dbSanContentDataContext db;


        private void fMain_Load(object sender, EventArgs e)
        {
            var f = new fDangNhap();
            f.ShowDialog();
            var nv = f.nv;
            lblNhanVien.Text = String.Format("Nhân viên: {0}", nv.HoVaTen);
            lblTitle.Text = "SÂN BÓNG NARUTO";
        }

        private void loạiSânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new fLoaiSan(); // khai báo form
            addForm(f);
        }

        private void addForm(Form f)
        {
            f.FormBorderStyle = FormBorderStyle.None; // bỏ viền form
            f.Dock = DockStyle.Fill; // tự động co giãn 
            f.TopLevel = false;
            f.TopMost = true;
            grbContent.Controls.Clear(); // xóa các item đang có trên grb
            grbContent.Controls.Add(f);
            f.Show();
        }

        private void sânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new fSan(); // khai báo form
            addForm(f);
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new fMatHang(); // khai báo form
            addForm(f);
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new fNhanVien(); // khai báo form
            addForm(f);
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new fBanHang(); // khai báo form
            addForm(f);
        }
    }
}

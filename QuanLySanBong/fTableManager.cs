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
using System.Globalization;
using Menu = QuanLySanBong.DTO.Menu;

namespace QuanLySanBong
{
    public partial class fTableManager : Form
    {
        public object Selected { get; private set; }

        public fTableManager()
        {
            InitializeComponent();
            loadSan();
            loadLoaiTU();
        }

        #region Method

        #endregion
        void loadLoaiTU()
        {
            List<LoaiTU> loaiTUs = LoaiTUDAO.Instance.GetLoaiTUs();
            cbSan.DataSource = loaiTUs;
            cbSan.DisplayMember = "TenLoai";


        }
        void loadDoUong(int id)
        {
            List<ThucUong> thucs = ThucUongDAO.Instance.getListThucUong(id);
            cbDichVu.DataSource = thucs;
            cbDichVu.DisplayMember = "TenThucUong";
        }
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
            flpSan.Controls.Clear();
            lsvHoaDon.Items.Clear();
            List<Menu> hdinfo = MenuDAO.Instance.getlistMenu(id);
            float tongtien = 0;
            foreach (Menu item in hdinfo)
            {
                ListViewItem listhd = new ListViewItem(item.TenThucUong.ToString());
                listhd.SubItems.Add(item.Count.ToString());
                listhd.SubItems.Add(item.Price.ToString());
                listhd.SubItems.Add(item.ThanhTien.ToString());
                tongtien += item.ThanhTien;
                lsvHoaDon.Items.Add(listhd);

            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txtTongtien.Text = tongtien.ToString("c",culture);
            
        }
        private void Button_Click(object sender, EventArgs e)
        {
            int tableId = ((sender as Button).Tag as Table).Id;
            lsvHoaDon.Tag = (sender as Button).Tag;
            showHoaDon(tableId);

        }
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

        private void cbSan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
               
            LoaiTU loaiTU = cb.SelectedItem as LoaiTU;
            id = loaiTU.Id;
            


            loadDoUong(id);
        }

        private void btnThemSan_Click(object sender, EventArgs e)
        {
            Table tale = lsvHoaDon.Tag as Table;
            int idHoaDon = HoaDonDAO.Instanse.getHoaDOn(tale.Id);
            int idThucUong = (cbSan.SelectedItem as LoaiTU).Id;
            int count = (int)nmSoSan.Value;
            if (idHoaDon == -1)
            {
                HoaDonDAO.Instanse.insertHoaDOn(tale.Id);
                HoaDonInfoDAO.Instanse.insertHoaDOnÌno(HoaDonDAO.Instanse.getMaxHoaDon(),idThucUong,count);

            }
            else
            {
                HoaDonInfoDAO.Instanse.insertHoaDOnÌno(idHoaDon,idThucUong,count);
            }
            showHoaDon(tale.Id);
            loadSan();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Table table = lsvHoaDon.Tag as Table;
            int idhoadon = HoaDonDAO.Instanse.getHoaDOn(table.Id);
            if(idhoadon != -1)
            {
                if (MessageBox.Show("Bạn có muốn thanh toán sân này" + table.Tensan,"Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK);
                HoaDonDAO.Instanse.checkout(idhoadon);
                showHoaDon(table.Id);
                loadSan();
            }
        }
    }
}

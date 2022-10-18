using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySanBong.DB;

namespace QuanLySanBong
{
    public partial class fOrder : Form
    {
        public fOrder(long idHoaDon, string tensan, DataGridViewRow r)
        { 
            this.idHoaDon = idHoaDon;
            this.r = r;
            this.tensan = tensan;
            InitializeComponent();
        }

        private long idHoaDon;
        private DataGridViewRow r;
        private string tensan;

        private dbSanContentDataContext db;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void fOrder_Load(object sender, EventArgs e)
        {
            this.lblTenMatHang.Text = "Mặt hàng yêu cầu: "+r.Cells["tenhang"].Value.ToString();
            this.lblSan.Text = string.Format("Sân phục vụ: {0}", tensan);
            txbSL.Select(); // set focus
            db = new dbSanContentDataContext();
        }

        private void lblTenMatHang_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txbSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) // chỉ cho phép nhập số tự nhiên
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)13)
            {
                btnSubmit.PerformClick(); // gọi sự kiện click của thằng button
            }
        }

        private void txbSL_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int sl = 0;
                try
                {
                    sl = int.Parse(txbSL.Text);
                    if (sl == 0)
                    {
                        MessageBox.Show("Số lượng không hợp lệ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbSL.Select();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Số lượng không hợp lệ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbSL.Select();
                    return;
                }

                // trước khi thêm, cần kiểm tra đã tồn tại chưa mặt hàng này trong hóa đơn được chọn hay chưa
                var item = db.ChiTietHoaDonBans.SingleOrDefault(x => x.IDHoaDon == idHoaDon && x.IDMatHang == int.Parse(r.Cells["mahang"].Value.ToString()));
                if (item != null)
                {
                    // nếu đã tồn tại thì chỉ cập nhập sl
                    item.SoLuong += sl; // cộng dồn
                    db.SubmitChanges();
                }
                else
                {
                    var ct = new ChiTietHoaDonBan();
                    ct.IDHoaDon = (int)idHoaDon;
                    ct.IDMatHang = int.Parse(r.Cells["mahang"].Value.ToString());
                    ct.SoLuong = sl;
                    // trong db. còn có cột đơn giá
                    // đơn giá được lấy từ cột giaban trong bảng mathang
                    // muốn lấy được ta cần tìm ra một hàng có mã id = int.Parse(r.Cells["mahang"].Value.ToString()); chính là mã hàng được truyền qua từ trong fBanHang
                    var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["mahang"].Value.ToString()));

                    ct.DonGia = mh.DonGiaBan;

                    db.ChiTietHoaDonBans.InsertOnSubmit(ct);
                    db.SubmitChanges();
                }
                MessageBox.Show("Thêm mặt hàng vào sân: " + tensan + " thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Dispose(); // đóng fOrder sau khi gọi mon thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Yêu cầu phuc vụ thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

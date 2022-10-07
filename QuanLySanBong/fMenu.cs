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
using QuanLySanBong.DAO;

namespace QuanLySanBong
{
    public partial class fMenu : Form
    {
        public fMenu()
        {
            InitializeComponent();

            LoadAccountList();
        }

        void LoadAccountList()
        {
            string query = "exec dbo.USP_LayNhanVienTen @hoTen";

            dtgvNhanVien.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { "Nguyen Thi Na" });
        }
    }
}

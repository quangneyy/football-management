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

namespace QuanLySanBong
{
    public partial class FormQLdichvu : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-8FJ7VHUC\SQLEXPRESS;Initial Catalog=QLSanBanh;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        

        void loaddata()
        {
        command = connection.CreateCommand();
        command.CommandText = "select * from ChiTietDichVu";
        adapter.SelectCommand = command;
        table.Clear();
        adapter.Fill(table);
        dvgthontin.DataSource = table;
        }

        public FormQLdichvu()
        {
            InitializeComponent();
        }

        private void FormQLdichvu_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMenu FMN = new FormMenu();
            FMN.Show();
        }



        private void btnxoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from ChiTietDichVu where ('" + txtmadv.Text + "','" + txtmahd.Text + "','" + txtmasan.Text + "','" + txtthanhtien.Text + "')";
            command.ExecuteNonQuery();
            loaddata();
        }

       

        private void dvgthontin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmadv.ReadOnly = true;
            int i;
            i = dvgthontin.CurrentRow.Index;
            txtmadv.Text = dvgthontin.Rows[i].Cells[0].Value.ToString();
            txtmahd.Text = dvgthontin.Rows[i].Cells[1].Value.ToString();
            txtmasan.Text = dvgthontin.Rows[i].Cells[2].Value.ToString();
            txtthanhtien.Text = dvgthontin.Rows[i].Cells[3].Value.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into ChiTietDichVu values ('"+txtmadv.Text+ "','"+txtmahd.Text+ "','"+txtmasan.Text+ "','"+txtthanhtien.Text+"')";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into ChiTietDichVu values ('" + txtmadv.Text + "','" + txtmahd.Text + "','" + txtmasan.Text + "','" + txtthanhtien.Text + "')";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtmadv_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

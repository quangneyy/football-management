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
    public partial class Form1QLSancs : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-8FJ7VHUC\SQLEXPRESS;Initial Catalog=QLSanBanh;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loadata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from ChiTietThueSan";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dvgthongtin.DataSource = table;

        }
        public Form1QLSancs()
        {
            InitializeComponent();
        }

        private void Form1QLSancs_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadata();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dvgthongtin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmahd.ReadOnly = true;
            int i;
            i = dvgthongtin.CurrentRow.Index;
            txtmahd.Text = dvgthongtin.Rows[i].Cells[0].Value.ToString();
            txtmasan.Text = dvgthongtin.Rows[i].Cells[1].Value.ToString();
            txtgiasan.Text = dvgthongtin.Rows[i].Cells[2].Value.ToString();
            txtgiothue.Text = dvgthongtin.Rows[i].Cells[3].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            
        }

        private void btntrolai_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMenu FMN = new FormMenu();
            FMN.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into ChiTietDichVu values ('" + txtmahd.Text + "','" + txtmasan.Text + "','" + txtgiasan.Text + "','" + txtgiothue.Text + "')";
            command.ExecuteNonQuery();
            loadata();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from ChiTietDichVu where ('" + txtmahd.Text + "')";
            command.ExecuteNonQuery();
            loadata();
        }
    }
}

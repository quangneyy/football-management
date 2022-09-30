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
        
        SqlConnection connect;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-8FJ7VHUC\SQLEXPRESS;Initial Catalog=QLSanBanh;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connect.CreateCommand();
            command.CommandText = "select * from DichVu"; command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dvgthontin.DataSource = table;


        }

        public FormQLdichvu()
        {
            InitializeComponent();
        }

       

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void btnxoa_Click(object sender, EventArgs e)
        {
            txtmadv.ReadOnly = true;
            command = connect.CreateCommand();
            command.CommandText = "delete from DichVu where MaDV = ('" + txtmadv.Text + "')";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void FormQLdichvu_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection(str);
            connect.Open();
            loaddata();
        }

        private void dvgthontin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dvgthontin.CurrentRow.Index;
            txtmadv.Text = dvgthontin.Rows[i].Cells[0].Value.ToString();
            txttendv.Text = dvgthontin.Rows[i].Cells[1].Value.ToString();
            txtcp.Text = dvgthontin.Rows[i].Cells[2].Value.ToString();
            //txtmadv.Text = dvgthontin.Rows.Count.ToString();

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            
            command = connect.CreateCommand();
            command.CommandText = "insert into DichVu values ('"+txtmadv.Text+ "','"+txttendv.Text+ "','"+txtcp.Text+ "')";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            txtmadv.ReadOnly = true;
            command = connect.CreateCommand();
            command.CommandText = "update DichVu set TenDV = '" + txttendv.Text + "',ChiPhi = '" + txtcp.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
        }
    }
}

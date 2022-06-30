using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas_Akhir_PABD
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-4S8UKI2A\RAFFIRENANDA;Initial Catalog=TOKOBUKUBARU;User ID=sa;Password=12345678");
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tOKOBUKUBARUDataSet4.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.tOKOBUKUBARUDataSet4.Suppliers);
            

        }
        public void display()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Suppliers]";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dtadp = new SqlDataAdapter(cmd);
            dtadp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void buttonAddSup_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Suppliers values (@id_supplier, @kode_buku, @nama_supplier, @alamat_supplier, @telp_supplier)", con);
            cmd.Parameters.AddWithValue("@id_supplier", textBoxIdSup.Text);
            cmd.Parameters.AddWithValue("@kode_buku", textBoxKodecBuku.Text);
            cmd.Parameters.AddWithValue("@nama_supplier", textBoxNamaSup.Text);
            cmd.Parameters.AddWithValue("@alamat_supplier", AlamatSUp.Text);
            cmd.Parameters.AddWithValue("@telp_supplier", textBoxTelp.Text);
            
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxIdSup.Text = "";
            textBoxKodecBuku.Text = "";
            textBoxNamaSup.Text = "";
            AlamatSUp.Text = "";
            
            textBoxTelp.Text = "";
            
            MessageBox.Show("Data berhasil ditambah!");
            display();
        }

        private void buttonDellSup_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [Suppliers] where kode_buku = '" + textBoxKodecBuku.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxKodecBuku.Text = "";
            textBoxIdSup.Text = "";
            textBoxNamaSup.Text = "";
            textBoxTelp.Text = "";
            AlamatSUp.Text = "";
            MessageBox.Show("Data berhasil dihapus!");
            display();
        }

        

        private void buttonEditSup_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [Suppliers] set id_supplier='" + this.textBoxIdSup.Text + "',kode_buku='" + this.textBoxKodecBuku.Text + "',nama_supplier='" + this.textBoxNamaSup.Text + "',alamat_supplier='" + this.AlamatSUp.Text + "', telp_supplier='" + this.textBoxTelp.Text + "' where kode_buku='" + this.textBoxKodecBuku.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxKodecBuku.Text = "";
            textBoxIdSup.Text = "";
            textBoxNamaSup.Text = "";
            textBoxTelp.Text = "";
            AlamatSUp.Text = "";
            MessageBox.Show("Data berhasil diedit!");
            display();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void buttonClearSup_Click(object sender, EventArgs e)
        {
            textBoxKodecBuku.Text = "";
            textBoxIdSup.Text = "";
            textBoxNamaSup.Text = "";
            textBoxTelp.Text = "";
            AlamatSUp.Text = "";
        }

        private void buttonSearchSup_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Suppliers] where nama_supplier = '" + textBoxCariSup.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter datAdp = new SqlDataAdapter(cmd);
            datAdp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            textBoxCariSup.Text = "";
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            display();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Log Out akan mengharuskan anda untuk Log In kembali !!", "Konfirmasi",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rows = int.Parse(e.RowIndex.ToString());
            textBoxIdSup.Text = dataGridView1[0, rows].Value.ToString();
            textBoxKodecBuku.Text = dataGridView1[1, rows].Value.ToString();
            textBoxNamaSup.Text = dataGridView1[2, rows].Value.ToString();
            AlamatSUp.Text = dataGridView1[3, rows].Value.ToString();
            textBoxTelp.Text = dataGridView1[4, rows].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            display();
        }
    }
}

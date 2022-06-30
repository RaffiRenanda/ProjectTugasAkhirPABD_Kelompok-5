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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-4S8UKI2A\RAFFIRENANDA;Initial Catalog=TOKOBUKUBARU;User ID=sa;Password=12345678");

        public Form1()
        {
            InitializeComponent();
            display();
        }
        public Form1(string terima)
            : this()
        {
            label12.Text = terima;
        }
        
        SqlCommand cmd;

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tOKOBUKUBARUDataSet3.BukuKu' table. You can move, or remove it, as needed.
            this.bukuKuTableAdapter.Fill(this.tOKOBUKUBARUDataSet3.BukuKu);
            

        }

        public void display()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [BukuKu]";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dtadp = new SqlDataAdapter(cmd);
            dtadp.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            con.Open();

            SqlCommand cmd = new SqlCommand("insert into BukuKu values (@kode_buku, @id_toko, @id_supplier, @judul_buku, @tahun_terbit, @rak_buku, @harga_buku, @penulis)", con);
            cmd.Parameters.AddWithValue("@kode_buku", textBoxKodBuku.Text);
            cmd.Parameters.AddWithValue("@id_toko", textBoxIdToko.Text);
            cmd.Parameters.AddWithValue("@id_supplier", textBoxIdSupp.Text);
            cmd.Parameters.AddWithValue("@judul_buku", textBoxJudulBuku.Text);
            cmd.Parameters.AddWithValue("@tahun_terbit", dateTimePickerTahun.Text);
            cmd.Parameters.AddWithValue("@rak_buku", textBoxRak.Text);
            cmd.Parameters.AddWithValue("@harga_buku", textBoxHarga.Text);
            cmd.Parameters.AddWithValue("@penulis", textBoxPenulis.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxKodBuku.Text = "";
            textBoxIdToko.Text = "";
            textBoxIdSupp.Text = "";
            textBoxJudulBuku.Text = "";
            dateTimePickerTahun.Value = DateTime.Now;
            textBoxRak.Text = "";
            textBoxHarga.Text = "";
            textBoxPenulis.Text = "";
            MessageBox.Show("Data berhasil ditambah!");
            display();

        }

        private void buttonDell_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [BukuKu] where kode_buku = '" + textBoxKodBuku.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxKodBuku.Text = "";
            textBoxIdToko.Text = "";
            textBoxIdSupp.Text = "";
            textBoxJudulBuku.Text = "";
            dateTimePickerTahun.Value = DateTime.Now;
            textBoxRak.Text = "";
            textBoxHarga.Text = "";
            textBoxPenulis.Text = "";
            MessageBox.Show("Data berhasil dihapus!");
            display();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [BukuKu] where judul_buku = '" + textBoxCari.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter datAdp = new SqlDataAdapter(cmd);
            datAdp.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
            textBoxCari.Text = "";
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [BukuKu] set kode_buku='" + this.textBoxKodBuku.Text + "',id_toko='" + this.textBoxIdToko.Text + "',id_supplier='" + this.textBoxIdSupp.Text + "',judul_buku='" + this.textBoxJudulBuku.Text + "', tahun_terbit='" + dateTimePickerTahun.Text + "', rak_buku='" + this.textBoxRak.Text + "', harga_buku='" + this.textBoxHarga.Text + "', penulis='" + this.textBoxPenulis.Text + "' where kode_buku='" + this.textBoxKodBuku.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxKodBuku.Text = "";
            textBoxIdToko.Text = "";
            textBoxIdSupp.Text = "";
            textBoxJudulBuku.Text = "";
            dateTimePickerTahun.Value = DateTime.Now;
            textBoxRak.Text = "";
            textBoxHarga.Text = "";
            textBoxPenulis.Text = "";
            MessageBox.Show("Data berhasil diedit!");
            display();
        }

        

        

        

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxKodBuku.Text = "";
            textBoxIdToko.Text = "";
            textBoxIdSupp.Text = "";
            textBoxJudulBuku.Text = "";
            dateTimePickerTahun.Value = DateTime.Now;
            textBoxRak.Text = "";
            textBoxHarga.Text = "";
            textBoxPenulis.Text = "";
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

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            display();
        }

        

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 1)
            {
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.Blue;
                e.CellStyle.BackColor = Color.Gray;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerTahun.Format = DateTimePickerFormat.Custom;
            dateTimePickerTahun.CustomFormat = "MM/yyyy";
        }

        

        private void buttonTblSup_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rows = int.Parse(e.RowIndex.ToString());
            textBoxKodBuku.Text = dataGridView2[0, rows].Value.ToString();
            textBoxIdToko.Text = dataGridView2[1, rows].Value.ToString();
            textBoxIdSupp.Text = dataGridView2[2, rows].Value.ToString();
            textBoxJudulBuku.Text = dataGridView2[3, rows].Value.ToString();
            dateTimePickerTahun.Text = dataGridView2[4, rows].Value.ToString();
            textBoxRak.Text = dataGridView2[5, rows].Value.ToString();
            textBoxHarga.Text = dataGridView2[6, rows].Value.ToString();
            textBoxPenulis.Text = dataGridView2[7, rows].Value.ToString();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rows = int.Parse(e.RowIndex.ToString());

            string data1, data2, data3, data4, data5, data6, data7, data8;
            data1 = dataGridView2[0, rows].Value.ToString();
            data2 = dataGridView2[1, rows].Value.ToString();
            data3 = dataGridView2[2, rows].Value.ToString();
            data4 = dataGridView2[3, rows].Value.ToString();
            data5 = dataGridView2[4, rows].Value.ToString();
            data6 = dataGridView2[5, rows].Value.ToString();
            data7 = dataGridView2[6, rows].Value.ToString();
            data8 = dataGridView2[7, rows].Value.ToString();
            Form3 f3 = new Form3(data1, data2, data3, data4, data5, data6, data7, data8);

            f3.Show();
            this.Hide();
        }
    }
}

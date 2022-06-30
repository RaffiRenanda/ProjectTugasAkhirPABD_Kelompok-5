using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas_Akhir_PABD
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Benarkah Anda Ingin Keluar  dari aplikasi ini ???", "Konfirmasi",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kiriman;
            kiriman = textBox1.Text;


            if (textBox1.Text == "Raffi Renanda" && textBox2.Text == "raffi020")
            {
                Form1 f1 = new Form1(kiriman);
                f1.Show();
                this.Hide();
            }
            else if (textBox1.Text == "Aulia Nabila" && textBox2.Text == "nabila006")
            {
                Form1 f1 = new Form1(kiriman);
                f1.Show();
                this.Hide();
            }
            else if (textBox1.Text == "Rezka Mulya" && textBox2.Text == "rezka010")
            {
                Form1 f1 = new Form1(kiriman);
                f1.Show();
                this.Hide();
            }
            else if (textBox1.Text == "Muhammad Fachri" && textBox2.Text == "fachri144")
            {
                Form1 f1 = new Form1(kiriman);
                f1.Show();
                this.Hide();
            }
            else if (textBox1.Text == "Yusuf Hardi" && textBox2.Text == "yusuf001")
            {
                Form1 f1 = new Form1(kiriman);
                f1.Show();
                this.Hide();
            }
            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kamu belum mengisi form login");
            }
            else
            {
                MessageBox.Show("Username atau Password Salah ");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
                var checkBox = (CheckBox)sender;

            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                var checkBox = (CheckBox)sender;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}

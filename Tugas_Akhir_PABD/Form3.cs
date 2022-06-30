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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(string terima, string terima1, string terima2, string terima3, string terima4, string terima5, string terima6, string terima7)
        
            : this()
                {
            labelkod.Text = terima;
            labelidtoko.Text = terima1;
            labelidsupp.Text = terima2;
            labeljudul.Text = terima3;
            labeltahun.Text = terima4;
            labelrak.Text = terima5;
            labelharga.Text = terima6;
            labelpenulis.Text = terima7;

            }
        



        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}

using DDA_line;
using GraphicsProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics
{
    public partial class LineBres : Form
    {
        public LineBres()
        {
            InitializeComponent();
        }

        private void LineBres_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Bres_line ln = new Bres_line(
             new Point(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)),
             new Point(Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text))
             );
            Bitmap bm = ln.Draw();
            this.pictureBoxBres.Image = bm;
            this.pictureBoxBres.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bres_line ln = new Bres_line(
            new Point(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)),
            new Point(Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text))
            );
            Bitmap bm = ln.Draw();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    bm = ln.translate(Int32.Parse(textBox5.Text), Int32.Parse(textBox6.Text));
                    break;
                case 1:
                    bm = ln.rotate(Int32.Parse(textBox7.Text));
                    break;
                case 2:
                    Line_Clipping lnc = new Line_Clipping(
                        new Point(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)),
                        new Point(Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text)),
                        new Point(Int32.Parse(textBox8.Text), Int32.Parse(textBox9.Text)),
                         new Point(Int32.Parse(textBox10.Text), Int32.Parse(textBox11.Text))
                     );
                    bm = lnc.Draw();
                    break;

            }

            this.pictureBoxBres.Image = bm;
            this.pictureBoxBres.Show();
        }
    }
}

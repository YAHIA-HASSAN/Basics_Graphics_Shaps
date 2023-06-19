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
    public partial class Circle : Form
    {
        public Circle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CircleDraw cr = new CircleDraw(
                Int32.Parse(textBox1.Text),
                Int32.Parse(textBox3.Text),
                Int32.Parse(textBox4.Text)
                );
            this.pictureBox1.Image = cr.drawCircle1();
            this.pictureBox1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CircleDraw cr = new CircleDraw(
                Int32.Parse(textBox1.Text),
                Int32.Parse(textBox3.Text),
                Int32.Parse(textBox4.Text)
                );

            if (this.comboBox1.SelectedIndex == 0)
            {
                cr.translate(Int32.Parse(textBox5.Text),
                Int32.Parse(textBox6.Text));
            }

            this.pictureBox1.Image = cr.drawCircle1();
            this.pictureBox1.Show();

        }
    }
}

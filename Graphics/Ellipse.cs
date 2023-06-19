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
    public partial class Ellipse : Form
    {
        public Ellipse()
        {
            InitializeComponent();
        }
  
        private void button1_Click_1(object sender, EventArgs e)
        {
            EllipsDraw el = new EllipsDraw(
                Int32.Parse(textBox1.Text),
                Int32.Parse(textBox2.Text),
                Int32.Parse(textBox3.Text),
                Int32.Parse(textBox4.Text)
                );

            this.pictureBox1.Image = el.Draw_mid_point();
            this.pictureBox1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            EllipsDraw el = new EllipsDraw(
                Int32.Parse(textBox1.Text),
                Int32.Parse(textBox2.Text),
                Int32.Parse(textBox3.Text),
                Int32.Parse(textBox4.Text)
                );
            el.translate(
                Int32.Parse(textBox5.Text),
                Int32.Parse(textBox6.Text)
                );

            this.pictureBox1.Image = el.Draw_mid_point();
            this.pictureBox1.Show();

        }
    }
}

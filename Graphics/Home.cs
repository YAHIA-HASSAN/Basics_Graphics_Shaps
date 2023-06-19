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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            Form dda = new LineDDA();
            dda.MdiParent = this;
            dda.Show();
        }


        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void elipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            Form ellipse = new Ellipse();
            ellipse.MdiParent = this;
            ellipse.Show();
        }

        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer= true;
            Form dda= new LineDDA();
            dda.MdiParent = this;
            dda.Show();

        }

        private void bresenhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            Form bres = new LineBres();
            bres.MdiParent = this;
            bres.Show();
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            Form circle = new Circle();
            circle.MdiParent = this;
            circle.Show();

        }
    }
}

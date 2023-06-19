using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProject
{
    class mid_point
    {

        private int rx, ry, xc, yc, counter = 0;

        public mid_point(int rx, int ry, int xc, int yc)
        {
            this.rx = rx;
            this.ry = ry;
            this.xc = xc;
            this.yc = yc;
        }
        public Bitmap Draw_mid_point()
        {
            int x = 0;
            int y = ry;
            double po = 0;
            double d = 0;
            double p = Math.Pow(ry, 2) - (Math.Pow(rx, 2) * ry) + (0.25 * (Math.Pow(rx, 2)));
            double dx = 2 * Math.Pow(ry, 2) * x;
            double dy = 2 * Math.Pow(rx, 2) * y;

            Bitmap bm = new Bitmap(1000, 1000);
            if (dx < dy)
            {
                bm.SetPixel(xc + x, yc + y, Color.Black);
                bm.SetPixel(xc - x, yc - y, Color.Black);
                bm.SetPixel(xc + x, yc - y, Color.Black);
                bm.SetPixel(xc - x, yc + y, Color.Black);


                if (p < 0)
                {
                    x++;
                    dx = dx + ((2 * (Math.Pow(ry, 2))));
                    p = p + 2 * Math.Pow(ry, 2) * x + (3 * Math.Pow(ry, 2));
                }
                else
                {
                    x++;
                    y--;
                    dx = dx + (2 * (Math.Pow(ry, 2)));
                    dy = dy - (2 * (Math.Pow(rx, 2)));
                    p = p + dx - dy + (Math.Pow(ry, 2));

                }
            }


            double p2 = (ry * ry * (x + 0.5) * (x + 0.5)) + (rx * rx * (y - 1) * (y - 1)) - (ry * ry * rx * rx);

            if (y < 0)
            {
                bm.SetPixel(xc + x, yc + y, Color.Black);
                bm.SetPixel(xc - x, yc - y, Color.Black);
                bm.SetPixel(xc + x, yc - y, Color.Black);
                bm.SetPixel(xc - x, yc + y, Color.Black);
                if (p2 > 0)
                {
                    x = x;
                    y--;
                    dy = dy + ((2 * (Math.Pow(rx, 2))));
                    p2 = p2 - dy + Math.Pow(rx, 2);
                }
                else
                {
                    x++;
                    y--;
                    dx = dx + (2 * (Math.Pow(ry, 2)));
                    dy = dy - (2 * (Math.Pow(rx, 2)));
                    p2 = p2 + dx - dy + (Math.Pow(rx, 2));

                }
            }

            return bm;
        }
    }

}
        /*
        private void transformation(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)   //Translate
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                int tx = int.Parse(textBox1.Text);  //tx box 
                int ty = int.Parse(textBox2.Text);  //ty box
                int rx = int.Parse(textBox3.Text);
                int ry = int.Parse(textBox4.Text);
                int xc = pictureBox1.Width / 2;
                int yc = pictureBox1.Height / 2;


                int x = 0, y;

                double p0 = 0.0, d0 = 0.0;

                y = ry;
                int i = 0;
                Bitmap s = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                p0 = ry * ry - rx * rx * ry + 0.25 * rx * rx;


                //region 1

                while (2 * ry * ry * x < 2 * rx * rx * y)
                {
                    DataGridViewRow rw = new DataGridViewRow();
                    rw.CreateCells(dataGridView1);
                    rw.Cells[0].Value = i;
                    rw.Cells[1].Value = p0;
                    s.SetPixel(xc + x + tx, ty + yc + y, Color.Red);
                    s.SetPixel(xc - x + tx, yc + y + ty, Color.Red);
                    s.SetPixel(xc - x + tx, yc - y + ty, Color.Red);
                    s.SetPixel(xc + x + tx, ty + yc - y, Color.Red);
                    x++;

                    if (p0 < 0)
                    {
                        p0 += 2 * ry * ry * x + ry * ry;

                    }
                    else
                    {
                        y--;
                        p0 += 2 * ry * ry * x + ry * ry - 2 * rx * rx * y;

                    }
                    i++;
                    rw.Cells[2].Value = x + tx;
                    rw.Cells[3].Value = y + ty;
                    rw.Cells[4].Value = 2 * ry * ry * x;
                    rw.Cells[5].Value = 2 * rx * rx * y;
                    dataGridView1.Rows.Add(rw);

                }

                //region 2
                i = 0;
                d0 = ry * ry * (x + 0.5) * (x + 0.5) + rx * rx * (y - 1) * (y - 1) - ry * ry * rx * rx;
                while (y > 0)
                {
                    DataGridViewRow rw2 = new DataGridViewRow();
                    rw2.CreateCells(dataGridView1);
                    rw2.Cells[1].Value = d0;
                    y--;
                    if (d0 < 0)
                    {
                        x++;
                        d0 += 2 * ry * ry * x - 2 * rx * rx * y + rx * rx;
                    }
                    else
                    {
                        d0 += -2 * rx * rx * y + rx * rx;
                    }
                    s.SetPixel(xc + x + tx, yc + y + ty, Color.Red);
                    s.SetPixel(xc - x + tx, yc + y + ty, Color.Red);
                    s.SetPixel(xc - x + tx, yc - y + ty, Color.Red);
                    s.SetPixel(xc + x + tx, yc - y + ty, Color.Red);
                    rw2.Cells[0].Value = i;
                    rw2.Cells[2].Value = x + tx;
                    rw2.Cells[3].Value = y + ty;
                    rw2.Cells[4].Value = 2 * ry * ry * x;
                    rw2.Cells[5].Value = 2 * rx * rx * y;
                    i++;
                    dataGridView1.Rows.Add(rw2);
                }

                pictureBox1.Image = s;
            }

            else if (comboBox1.SelectedIndex == 1)  // Scaling
            { }

            else if (comboBox1.SelectedIndex == 2)  //Rotate
            { }
        }

    
}**/
    
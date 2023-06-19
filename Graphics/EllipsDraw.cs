using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics
{
    internal class EllipsDraw
    {
        private int rx, ry, xc, yc, counter = 0;

        public EllipsDraw(int rx, int ry, int xc, int yc)
        {
            this.rx = rx;
            this.ry = ry;
            this.xc = xc;
            this.yc = yc;
        }
        public Bitmap Draw_mid_point()
        {


            int x = 0, y;

            double p0 = 0.0, d0 = 0.0;

            y = ry;
            int i = 0;
            Bitmap s = new Bitmap(1000, 1000);
            p0 = ry * ry - rx * rx * ry + 0.25 * rx * rx;


            //region 1

            while (2 * ry * ry * x < 2 * rx * rx * y)
            {
                s.SetPixel(xc + x, yc + y, Color.Black);
                s.SetPixel(xc - x, yc + y, Color.Black);
                s.SetPixel(xc - x, yc - y, Color.Black);
                s.SetPixel(xc + x, yc - y, Color.Black);
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
            

            }

            //region 2
            i = 0;
            d0 = ry * ry * (x + 0.5) * (x + 0.5) + rx * rx * (y - 1) * (y - 1) - ry * ry * rx * rx;
            while (y > 0)
            {
                
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
                s.SetPixel(xc + x, yc + y, Color.Black);
                s.SetPixel(xc - x, yc + y, Color.Black);
                s.SetPixel(xc - x, yc - y, Color.Black);
                s.SetPixel(xc + x, yc - y, Color.Black);
               
                i++;
                
            }


            return s;
        }
        public Bitmap translate(int tx,int ty)
        {
            this.xc = tx;
            this.yc = ty;

            return this.Draw_mid_point();
        }
    }
}

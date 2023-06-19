using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProject
{
    class Ellips_Midpoint
    {

        int rx, ry, xc, yc, counter = 0;


        public void Draw(int rx, int ry, int xc, int yc)
        {

            this.rx = rx;
            this.ry = ry;
            this.xc = xc;
            this.yc = yc;

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
            }
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
        }


    }
}
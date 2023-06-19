using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    internal class CircleDraw
    {
        int counter = 0;
        private int xc;
        private int yc;
        private int red;

        public CircleDraw(int red, int xc, int yc)
        {
            this.xc = xc;
            this.yc = yc;
            this.red = red;
        }

        public Bitmap drawCircle1()
        {
            Bitmap g = new Bitmap(1000, 1000);
            if (xc < 100 || yc < 100) { xc = 100; yc = 100; }
            else
            {
                int i = 0;
                int p0 = 1 - red;
                int pi = 0;

                int x;
                int y = 0;
                x = red;
                while (x > y)
                {
                    if (p0 < 0)
                    {
                        pi = p0 + 2 * (y + 1) + 1;
                        p0 = pi;
                    }
                    else
                    {
                        pi = p0 + 2 * (y + 1) - 2 * (x + 1) + 1;
                        p0 = pi;
                        x--;
                    }
                    y++;

                    int xcenter = 500;
                    int ycenter = 500;
                    g.SetPixel(x + xc, y + yc, Color.Red);
                    g.SetPixel(y + xc, x + yc, Color.Red);
                    g.SetPixel(y + xc, -x + yc, Color.Red);
                    g.SetPixel(x + xc, -y + yc, Color.Red);
                    g.SetPixel(-y + xc, -x + yc, Color.Red);
                    g.SetPixel(-x + xc, -y + yc, Color.Red);
                    g.SetPixel(-y + xc, x + yc, Color.Red);
                    g.SetPixel(-x + xc, y + yc, Color.Red);
                    i = i + 1;

                }
            }
            return g;
        }





        public Bitmap translate(int tx, int ty)
        {
                this.xc = tx;
                this.yc = ty;

                return this.drawCircle1();

            }
        }
    
}

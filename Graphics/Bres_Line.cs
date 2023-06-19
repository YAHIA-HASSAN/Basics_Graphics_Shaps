using GraphicsProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDA_line
{
    class Bres_line:AbstractLine
    {
        int x0, y0, xEnd, yEnd;
        /* Bresenham line-drawing */
        public Bres_line(Point startPoint, Point endPoint) : base(startPoint, endPoint)
        {
            x0 = startPoint.X;
            y0 = startPoint.Y;
            xEnd = endPoint.X;
            yEnd = endPoint.Y;
        }
        public override Bitmap Draw()
        {
            Bitmap bm = new Bitmap(1000, 1000);
            int dx = Math.Abs(xEnd - x0), dy = Math.Abs(yEnd - y0);
            int x, y, p = 2 * dy - dx;
            int twoDy = 2 * dy, twoDyMinusDx = 2 * (dy - dx);
            /* Determine which endpoint to use as start position. */
            if (x0 > xEnd)
            {
                x = xEnd; y = yEnd; xEnd = x0;
            }
            else
            {
                x = x0; y = y0;
            }
            bm.SetPixel(x, y,Color.Black);
            while (x < xEnd)
            {
                x++;
                if (p < 0)
                {
                    p += twoDy;
                }
                else
                {
                    y++;
                    p += twoDyMinusDx;
                    bm.SetPixel(x, y,Color.Black);
                }
            }
            return bm;
        }




        //After creation (comboBox1) contains index 0 (Translate)...index 1 (Scaling)...index 2 (Rotate).

        public Bitmap translate(int tx, int ty)
        {
            this.x0 = x0 + tx;
            this.y0 = y0 + ty;
            this.xEnd = xEnd + tx;
            this.yEnd = yEnd + ty;

            return Draw();
        }


        public Bitmap rotate(int ro)
        {
            int xr1, yr1, xr2, yr2;
            xr1 = (int)((x0 * (Math.Cos(ro))) - (y0 * Math.Sin(ro)));
            xr2 = (int)((xEnd * (Math.Cos(ro))) - (yEnd * Math.Sin(ro)));
            yr1 = (int)((y0 * (Math.Cos(ro))) + (x0 * Math.Sin(ro)));
            yr2 = (int)((yEnd * (Math.Cos(ro))) + (xEnd * Math.Sin(ro)));

            this.x0 = xr1;
            this.y0 = yr1;
            this.xEnd = xr2;
            this.yEnd = yr2;
            return Draw();
        }
    }
}

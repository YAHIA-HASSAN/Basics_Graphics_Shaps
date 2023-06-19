using Graphics;
using GraphicsProject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA_line
{
    class DDA_Line : AbstractLine
    {
        int x0; int y0; int xEnd; int yEnd;
        /* DDA line-drawing */
        public DDA_Line(Point startPoint,Point endPoint) : base(startPoint, endPoint)
        {
            x0 = startPoint.X;
            y0 = startPoint.Y;
            xEnd = endPoint.X;
            yEnd = endPoint.Y;
        }
        public override Bitmap Draw()
        {
            Bitmap bm = new Bitmap(1000, 1000);
            int dx = xEnd - x0, dy = yEnd - y0, steps, k; float xIncrement, yIncremen, x = x0, y = y0;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                steps = Math.Abs(dx);
            }
            else
            {
                steps = Math.Abs(dy);
            }
            xIncrement = (float)dx / (float)steps;
            yIncremen = (float)(dy) / (float)steps;
            bm.SetPixel((int)Math.Round(x), (int)Math.Round(y),Color.Black);
            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                y += yIncremen;
                bm.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Black);
            }
            return bm;
        }


        public Bitmap translate(int tx,int ty)
        {
            this.x0=x0+tx;
            this.y0=y0+ty;
            this.xEnd= xEnd+tx;
            this.yEnd= yEnd+ty;

            return Draw();
        }


        public Bitmap rotate(int ro)
        {
            int xr1, yr1, xr2, yr2;
            xr1 = (int)((x0 * (Math.Cos(ro))) - (y0 * Math.Sin(ro)));
            xr2 = (int)((xEnd * (Math.Cos(ro))) - (yEnd * Math.Sin(ro)));
            yr1 = (int)((y0 * (Math.Cos(ro))) + (x0 * Math.Sin(ro)));
            yr2 = (int)((yEnd * (Math.Cos(ro))) + (xEnd * Math.Sin(ro)));

            this.x0= xr1;
            this.y0= yr1;
            this.xEnd= xr2;
            this.yEnd= yr2;
            return Draw();
        }
        

    }
}

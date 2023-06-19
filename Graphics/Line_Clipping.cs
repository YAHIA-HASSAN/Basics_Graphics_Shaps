using DDA_line;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GraphicsProject
{
    public class Line_Clipping : AbstractLine
    {
        Point startPoint, endPoint, topRight, bottomLeft;
         double m = 0;

        public Line_Clipping(Point startPoint, Point endPoint, Point bottomLeft, Point topRight) : base(startPoint, endPoint)
        {
            this.topRight = topRight;
            this.bottomLeft = bottomLeft;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            char[]
                startPointCode = bitcode(startPoint),
                endPointCode = bitcode(endPoint),
                zero = "0000".ToCharArray();
            if ((endPoint.X - startPoint.X) != 0)
                m = (double)(endPoint.Y - startPoint.Y) /(double) (endPoint.X - startPoint.X);

            if (!(isEqual(ref startPointCode, ref zero) && isEqual(ref endPointCode, ref zero)))
            {
                if (bitwiseAND(ref startPointCode, ref endPointCode))
                {
                    startPoint = new Point(0, 0);
                    endPoint = new Point(0, 0);
                }
                else
                {


                    while (!isEqual(ref startPointCode,ref zero))
                    {
                        startPoint = PointBitcodeClipping(ref startPointCode, ref startPoint);
                        startPointCode = bitcode(startPoint);
                    }
                    while (!isEqual(ref endPointCode, ref zero))
                    {
                        endPoint = PointBitcodeClipping(ref endPointCode,ref endPoint);
                        endPointCode = bitcode(endPoint);
                    }
                }
            }
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            
        }

        bool isEqual(ref char[] a, ref char[] b)
        {
            for(int i=0;i<Math.Min(a.Length,b.Length);i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        //changing point to new clipped point
        private Point PointBitcodeClipping(ref char[] point, ref Point pt)
        {
            //TBRL
            char[] temp = new char[4];
            temp = ("1000".ToCharArray());
            if (isEqual(ref point, ref temp))
            {
                pt.X = pt.X + (int)((pt.Y - topRight.Y) * m);
                return new Point(pt.X,topRight.Y);
            }
            temp = ("0100".ToCharArray());
            if (isEqual(ref point, ref temp))
            {
                pt.X = bottomLeft.X + (int)((pt.Y - bottomLeft.X) * m);
                return new Point(pt.X, bottomLeft.Y);
            }
            temp = ("0010".ToCharArray());
            if (isEqual(ref point, ref temp))
            {
                pt.Y = bottomLeft.Y + (int)((pt.X - topRight.X) / m);
                return new Point(topRight.X,pt.Y);
            }
            temp = ("0001".ToCharArray());
            if (isEqual(ref point, ref temp))
            {
                pt.Y = bottomLeft.Y +(int) ((pt.X-bottomLeft.X) / m);
                return new Point(bottomLeft.X, pt.Y);
            }
     
            temp = ("1010".ToCharArray());
            if (isEqual(ref point, ref temp))
            {
               
                return new Point(topRight.X, topRight.Y);
            }
            temp = ("1001".ToCharArray());
            if (isEqual(ref point, ref temp))
            {
                return new Point(bottomLeft.X, topRight.Y);
            }
            temp = ("0110".ToCharArray());
            if (isEqual(ref point, ref temp))
            {
                return new Point(pt.X, topRight.Y);
            }
            temp = ("0101".ToCharArray());
            if (isEqual(ref point, ref temp))
            {
                return new Point(bottomLeft.X, bottomLeft.Y);
            }

            return pt;
        }

        //bits section converting and doing bitwise on bitcodes 
        private bool bitwiseAND(ref char[] startPointCode, ref char[] endPointCode)
        {
            char[] bt = bitcodeAND(ref startPointCode, ref endPointCode);
            for (int i = 0; i < 4; i++)
            {
                if (bt[i] == '1')
                {
                    return true;
                }
            }
            return false;
        }
        private char[] bitcodeAND(ref char[] startPointCode, ref char[] endPointCode)
        {
            char[] bt = new char[4];
            for (int i = 0; i < 4; i++)
            {
                if (AND(startPointCode[i], endPointCode[i]))
                {
                    bt[i] = '1';
                }
                else
                {
                    bt[i] = '0';
                }
            }
            return bt;
        }
        private bool AND(char a, char b)
        {
            return ((a == b) && (a == '1'));
        }


        private char[] bitcode(Point p)
        {
            //TBRL
            char[] bta = new char[4];
            bta[0] = bta[1] = bta[2] = bta[3] = '0';
            if (p.X < bottomLeft.X)
            {
                bta[3] = '1';
            }
            if (p.X > topRight.X)
            {
                bta[2] = '1';
            }
            if (p.Y < bottomLeft.Y)
            {
                bta[1] = '1';
            }
            if(p.Y > topRight.Y)
            {
                bta[0] = '1';
            }

            return bta;
        }



        //ovrride Draw function to draw new line
        public override Bitmap Draw()
        {
            DDA_Line ln = new DDA_Line(startPoint, endPoint);
            return ln.Draw();

        }
    }
}

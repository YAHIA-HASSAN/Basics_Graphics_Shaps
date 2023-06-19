using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProject
{
    public abstract class AbstractLine
    {
       //private Point startPoin, endPoint;
        public AbstractLine(Point startPoint, Point endPoint)
        { 
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            
        }
        private Point startPoint { get; set; }
        private Point endPoint { get; set;  }


        public abstract Bitmap Draw();
        

    }
}

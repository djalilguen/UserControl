using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Windows.Data;

namespace Chrono
{

    public class Aiguille : Figure
    {
        private Point centre;
        private Point point;
        private double angle;

    //    public event EventHandler Disposed;

        // private double rayon;

        public Aiguille() : this(new Point(), new Point())
        {
            this.angle = 0;
        }
        public Aiguille(Point centre, Point point) : base(true)
        {
            this.centre = centre;
            this.point = point;
            this.angle = 0;
        }

        public Aiguille(double x1, double y1, double x2, double y2) : this(new Point(x1, y1), new Point(x2, y2))
        {

        }
        //public override String ToString()
        //{
        //    return "[" + centre + ";" + rayon + "]";
        //}
        public override double getSurface()
        {
            return 0; ;
        }
        public Point getCercle()
        {
            return centre;
        }
        //public double getRayon()
        //{
        //    return rayon;
        //}

        public Point Centre {
            get{ return centre; }
            set{ if (centre !=value)
                { centre = value; }
            }

        }

        public Point Point {
            get { return point; }
            set { if (point != value)
                    point = value;
                }
        }

        public double Angle {
            get { return angle; }
            set { if (angle !=value)
                { this.angle = value; } }
        }

       
        public override bool contient(Point p)
        {
            return true;
        }

        public override void dessine(Graphics g, Pen p)
        {
            
            // Create points that define line.
           // PointF point1 = new PointF((float)this.centre.x, );
           // PointF point2 = new PointF(500.0F, 100.0F);
            
            // Draw line to screen.
            
            g.DrawLine(p, (float)(this.centre.x), (float)(this.centre.y), (float)(this.point.x), (float)(this.point.y));
           

           // g.DrawEllipse(p, (float)(this.centre.x-rayon), (float)(this.centre.y - rayon), 2 * (float)rayon, 2 * (float)rayon);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Chrono
{
    public class Cercle : Figure
    {
        private Point centre;
        private double rayon;

        public Cercle() : this(new Point())
        {
            //centre = new Point();
            //rayon = 10;
        }
        public Cercle(Point p) : base(true)
        {
            centre = p;
            rayon = 10;
        }

        public Cercle(Point p, double r) : base(true)
        {
            centre = p;
            rayon = r;
        }

        public Cercle(double a, double b, double r): this(new Point(a,b))
        {
            rayon = r;
        }
        public override String ToString()
        {
            return "[" + centre + ";" + rayon + "]";
        }
        public override double getSurface()
        {
            return Math.PI*Math.Pow(rayon,2);
        }
        public Point getCercle()
        {
            return centre;
        }
        public double getRayon()
        {
            return rayon;
        }
        public override bool contient(Point p)
        {
            return centre.distanceDe(p) <= rayon;
        }
        public override void dessine(Graphics g, Pen p)
        {
            g.DrawEllipse(p, (float)(this.centre.x-rayon), (float)(this.centre.y - rayon), 2 * (float)rayon, 2 * (float)rayon);
        }

        // events 
        //protected override void OnControlAdded(System.Windows.Forms.ControlEventArgs e)
        //{
        //   // base.OnControlAdded(e);
        //    e.Control.DoubleClick += new EventHandler(Control_DoubleClick);
        //}
        //protected override void OnControlRemoved(System.Windows.Forms.ControlEventArgs e)
        //{
        //    e.Control.DoubleClick -= new EventHandler(Control_DoubleClick);
        //  //  base.OnControlRemoved(e);
        //}
        //void Control_DoubleClick(object sender, EventArgs e)
        //{
        //    this.OnDoubleClick(e);
        //}
    }
}

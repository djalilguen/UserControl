using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chrono
{

    public class Point
    {
        private double abscisse, ordonnee;

        public Point(double abscisse, double ordonnee)
        {
            this.abscisse = abscisse;
            this.ordonnee = ordonnee;
        }
        public Point(double abscisse) : this(abscisse, 0)
        {
        }
        public Point() : this(0,0)
        { 
        }

        public override String ToString()
        {
            return "(" + abscisse + ";" + ordonnee + ")";
        }

        public double distanceDe(Point p)
        {
            return Math.Sqrt( Math.Pow((abscisse - p.abscisse), 2) 
                            + Math.Pow((ordonnee - p.ordonnee), 2));
        }
        public double distanceOrigine()
        {
            //return this.distanceDe(new Point(0, 0));
            //OU:
            return new Point(0, 0).distanceDe(this);
        }
        public double x
        {
            get { return abscisse; }
            set { abscisse = value; }
        }
        public double y
        {
            get { return ordonnee; }
            set { ordonnee = value; }
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Point)
            {
                Point p = (Point)obj;
                return this.x == p.x && this.y == p.y;
            }
            else
                return false;
        }
    }
}

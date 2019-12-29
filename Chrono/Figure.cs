using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Chrono
{
    public abstract class Figure : IComparable<Figure>
    {
        private bool visible;

        //public Figure()
        //{
        //    visible = true;
        //}
        public Figure(bool visible)
        {
            this.visible = visible;
        }
        public bool isVisible()
        {
            return visible;
        }
        public void setVisible(bool v)
        {
            visible = v;
        }
        public abstract double getSurface();
        public abstract bool contient(Point p);
        public abstract void dessine(Graphics g, Pen p);
        public int CompareTo(Figure fig)
        {
            if (this.getSurface() > fig.getSurface())
                return 1;
            else if (this.getSurface() == fig.getSurface())
                return 0;
            return -1;
        }
    }
}

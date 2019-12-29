using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chrono

{

    public class AnalogHorloge : Figure
    {
        private Cercle cercle;
        private Point centre;
        private double rayon;
        private double abscisse;
        private double ordonnee;
        private int angle = 6;

        private int initSeconds;
        private int initMinutes;
        private int initHeures;

        private Point pointAiguilleSeconds;
        private Point initPSeconds;
        private Point initPMinutes;
        private Point initPHoures;
        private Point pointAiguilleMinutes;
        private Point pointAiguilleHeures;

        private Aiguille aiguille0;
        private Aiguille aiguilleSeconds;
        private Aiguille aiguilleMinutes;
        private Aiguille aiguilleHeures;


        public AnalogHorloge(double abscisse, double ordonnee, double rayon, int initSeconds, int initMinutes, int initHeures, int angle) : base(true)
        {
            this.abscisse = abscisse;
            this.ordonnee = ordonnee;
            this.rayon = rayon;
            this.initSeconds = initSeconds;
            this.initMinutes = initMinutes;
            this.initHeures = initHeures;
            this.angle = angle;

            creerCercle();
            creerAiguille0();
            creerAuiguilleHeures();
            creerAuiguilleMinute();
            creerAiguilleSeconds();

        }

        public Point PointAiguilleSeconds
        {
            get { return pointAiguilleSeconds; }
            set { pointAiguilleSeconds = value; }
        }


        private void creerAiguille0()
        {
            aiguille0 = new Aiguille(centre, new Point(abscisse, 0));
        }

        private void creerCercle()
        {

            centre = new Point(abscisse, ordonnee);
            cercle = new Cercle(centre, rayon);

            //draw figure
            Bitmap bmp = new Bitmap(140, 140);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF(140, 2));
            g.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(286, 140));
            g.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF(142, 282));
            g.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(0, 140));
        }

        private void creerAiguilleSeconds()
        {
            initPSeconds = RotatePoint(new Point(abscisse, 0), centre, initSeconds * (-6));
            aiguilleSeconds = new Aiguille(centre, initPSeconds);
        }

        private void creerAuiguilleMinute()
        {
            initPMinutes = RotatePoint(new Point(abscisse, 0), centre, initMinutes * (-6));
            aiguilleMinutes = new Aiguille(centre, initPMinutes);
        }

        private void creerAuiguilleHeures()
        {
            initPHoures = RotatePoint(new Point(abscisse, 0), centre, initHeures * (-6));
            aiguilleHeures = new Aiguille(centre, initPHoures);
        }

        public void majAnalogHorloge(int seconds, int minutes, int hours)
        {
            majAiguilleSeconds(seconds);
            if (seconds == 0)
            {
                mAJAiguilleMinutes(minutes);
                if (minutes == 0)
                {
                    mAJAiguilleHeures(hours);
                }
            }

        }
        public void majAiguilleSeconds(int seconds)
        {
            pointAiguilleSeconds = RotatePoint(initPSeconds, centre, (initSeconds - seconds) * angle);
            aiguilleSeconds = new Aiguille(centre, pointAiguilleSeconds);
        }

        public void mAJAiguilleMinutes(int minutes)
        {
            pointAiguilleMinutes = RotatePoint(initPMinutes, centre, (initMinutes - minutes) * angle);
            aiguilleMinutes = new Aiguille(centre, pointAiguilleMinutes);
        }

        public void mAJAiguilleHeures(int hours)
        {
            pointAiguilleHeures = RotatePoint(initPHoures, centre, (initHeures - hours) * angle);
            aiguilleHeures = new Aiguille(centre, pointAiguilleHeures);

        }

        public Point RotatePoint(Point p1, Point centre, double angle)
        {

            angle = (angle) * (Math.PI / 180); // Convert to radians

            double rotatedX = Math.Cos(angle) * (p1.x - centre.x) - Math.Sin(angle) * (p1.y - centre.y) + centre.x;

            double rotatedY = Math.Sin(angle) * (p1.x - centre.x) + Math.Cos(angle) * (p1.y - centre.y) + centre.y;

            Point newPoint = new Point((double)rotatedX, (double)rotatedY);
            return newPoint;

        }

        public override String ToString()
        {
            return "[" + centre + ";" + rayon + "]";
        }
        public override double getSurface()
        {
            return Math.PI * Math.Pow(rayon, 2);
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
            return true;// centre.distanceDe(p) <= rayon;
        }
        public override void dessine(Graphics g, Pen p)
        {
            Pen stylo = new Pen(Color.Red);
            Pen styloMinute = new Pen(Color.Black, 2);// Pens.Black;
            Pen styloHours = new Pen(Color.Blue, 2);

            cercle.dessine(g, p);
            aiguille0.dessine(g, p);
            aiguilleSeconds.dessine(g, p);
            aiguilleMinutes.dessine(g, styloMinute);
            aiguilleHeures.dessine(g, styloHours);
        }

        
    }
}

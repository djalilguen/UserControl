using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Chrono
{
    public partial class CompteARebours : UserControl, INotifyPropertyChanged
    {
        private Chrono chrono;
        private int initialSeconds;
        private int initialMinutes;
        private int initialHours;
        private int angle = 6;
        private int s = 0;

        private double rayon = 50;
        private double abscisse = 50;
        private double ordonnee = 50;
        private AnalogHorloge analogHorloge;

        private bool isActive = false;
        private bool isNotTimeOut = true;

        private Thread t1;
        delegate void Delegue();
        Delegue unDelegue;


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propriete)
        {
            if (PropertyChanged != null)
            {
                //On déclenche l'événement indiquant que la propriete de this a été modifiée:
                PropertyChanged(this, new PropertyChangedEventArgs(propriete));
            }
        }

        public CompteARebours()
        {
            chrono = new Chrono(10, 0, 0);
            chrono.TimeOut += chrono_TimeOut;
            InitializeComponent();
            analogicClock();
            labelsBindings();
            isNotTimeOut = true;
            t1 = null;

             chrono.startChrono();
        }

        public bool IsNotTimeOut
        {
            get { return isNotTimeOut; }
            set
            {
                isNotTimeOut = value;
                NotifyPropertyChanged("isNotTimeOut");
            }
        }

        public int InitialSeconds
        {
            get { return chrono.InitialSeconds; }
            set
            {
                if (value == 0 && chrono.InitialMinutes == 0 && chrono.InitialHours == 0)
                {
                    chrono.InitialSeconds = 10;
                }
                else
                {
                    chrono.InitialSeconds = value;
                }

            }
        }

        public int InitialMinutes
        {
            get { return chrono.InitialMinutes; }
            set { chrono.InitialMinutes = value; }
        }

        public int InitialHours
        {
            get { return chrono.InitialHours; }
            set { chrono.InitialHours = value; }
        }

        public void startChrono()
        {
            analogicClock();
            chrono.startChrono();
        }
        public void stopChrono()
        {
            chrono.stopChrono();
        }

        private void labelsBindings()
        {

            lSeconds.DataBindings.Add("Text", chrono, "seconds");
            lMinutes.DataBindings.Add("Text", chrono, "minutes");
            lHours.DataBindings.Add("Text", chrono, "hours");

            // formater l<affichage des labels
            lHours.DataBindings[0].FormattingEnabled = true;
            lHours.DataBindings[0].FormatString = "00";
            lMinutes.DataBindings[0].FormattingEnabled = true;
            lMinutes.DataBindings[0].FormatString = "00";
            lSeconds.DataBindings[0].FormattingEnabled = true;
            lSeconds.DataBindings[0].FormatString = "00";

        }


        private void analogicClock()
        {
            rayon = Math.Min(panAnalog.Width / 2, panAnalog.Height / 2) - 1; // calculer le rayon du cercle
            abscisse = panAnalog.Width / 2;
            ordonnee = panAnalog.Height / 2;
            int initSeconds = (chrono.InitialSeconds % 60); // le nombre total des seconds
            int initMinutes = (chrono.InitialMinutes % 60); // le nombre total des seconds
            int initHeures = (chrono.InitialHours % 12); // le nombre total des seconds

            analogHorloge = new AnalogHorloge(abscisse, ordonnee, rayon, initSeconds, initMinutes, initHeures,angle);

        }

        private void panAnalog_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen stylo = new Pen(Color.Red);// Pens.Black;
            Pen styloMinute = new Pen(Color.Black, 2);// Pens.Black;
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            analogHorloge.dessine(g, stylo);
           // Graphics g = Graphics.FromImage(bmp);
            g.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF((int)abscisse-10, 5));
            g.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(panAnalog.Width-15, (int)ordonnee-7));
            g.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF((int)abscisse-7, panAnalog.Height-15));
            g.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(0, (int)ordonnee-7));

                if (chrono.Seconds <= 15 && chrono.Minutes == 0 && chrono.Hours == 0)
                {
                    if (chrono.InitialSeconds >= 15 || chrono.InitialMinutes > 0 || chrono.InitialHours > 0)
                    {
                        g.FillPie(redBrush, 0, 0, panAnalog.Width, panAnalog.Height, 180, 90 - chrono.Seconds * 6);
                    }
                    else
                        {
                        g.FillPie(greenBrush, 0, 0, panAnalog.Width, panAnalog.Height, 180, 90 -chrono.InitialSeconds * 6);
                        g.FillPie(redBrush, 0, 0, panAnalog.Width, panAnalog.Height, -90 - chrono.InitialSeconds * 6, (chrono.InitialSeconds-chrono.Seconds) * 6);
                }
                   
                }
               
            this.Invalidate();
        }


        private void panAnalog_DoubleClick(object sender, EventArgs e)
        {
            permuterAffichage();
        }

        private void panDigital_DoubleClick(object sender, EventArgs e)
        {
            permuterAffichage();
        }

        private void permuterAffichage()
        {
            if (panAnalog.Visible == true)
            {
                if(t1 !=null) t1.Suspend();
                panDigital.Visible = true;
                panAnalog.Visible = false;
              //  if(t1.IsAlive) t1.Suspend();
            }
            else
            {
                panDigital.Visible = false;
                panAnalog.Visible = true;
                if (chrono.IsNotTimeOut)
                {
                    if (t1 == null) //pour ne pas le démarrer plusieurs fois :
                    {
                        t1 = new Thread(new ThreadStart(horloge));
                        t1.Start();
                    }
                    else { t1.Resume(); }
                }
                else { if (t1 != null) t1.Suspend(); }
                
               
                  //  MessageBox.Show(t1.IsAlive.ToString());
               
            }
        }

        private void lHours_DoubleClick(object sender, EventArgs e)
        {
            permuterAffichage();
        }



        private void lSeconds_DoubleClick(object sender, EventArgs e)
        {
            permuterAffichage();
        }

        private void label3_DoubleClick(object sender, EventArgs e)
        {
            permuterAffichage();
        }

        private void lMinutes_DoubleClick(object sender, EventArgs e)
        {
            permuterAffichage();
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            permuterAffichage();
        }

        private void horloge()
        {
            while (true)
            {
                Thread.Sleep(100);
                Invoke(unDelegue);
            }
        }


        public void majAnalogHorloge()
        {
            
            if(s != chrono.Seconds)
            {
                analogHorloge.majAnalogHorloge(chrono.Seconds % 60, chrono.Minutes % 60, chrono.Hours % 60);
                panAnalog.Invalidate();
                s = chrono.Seconds;
            }

        }

        private void CompteARebours_Load(object sender, EventArgs e)
        {
            unDelegue = new Delegue(majAnalogHorloge);
            s = chrono.InitialSeconds;
        }

        protected override void OnHandleDestroyed(EventArgs e)

        {
            try
            {
                t1.Abort();
            }
            catch (ThreadStateException)
            {
                t1.Resume();
            }
        }

        private void chrono_TimeOut(object sender, EventArgs e)
        {
            IsNotTimeOut = false; // utilise pour desactive le label de la reponse
            MessageBox.Show("Temps écoulé", " Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}

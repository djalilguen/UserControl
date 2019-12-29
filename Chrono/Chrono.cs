using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Timers;
using System.ComponentModel;
using System.Windows.Forms;

namespace Chrono
{
    class Chrono: INotifyPropertyChanged
{
        private int initialHours;
        private int initialMinutes;
        private int initialSeconds;
        private int hours;
        private int minutes;
        private int seconds;
        private Timer timer;
        private int interval=1000;
        private bool isActive=false;
        private bool isNotTimeOut = true;


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propriete)
        {
            if (PropertyChanged != null)
            {
                //On déclenche l'événement indiquant que la propriete de this a été modifiée:
                PropertyChanged(this, new PropertyChangedEventArgs(propriete));
            }
        }

        public Chrono(int initialSeconds, int initialMinutes, int initialHours)
        {
            this.initialSeconds = initialSeconds;
            this.initialMinutes = (initialMinutes + (initialSeconds /60)) %60;
            this.initialHours = initialHours + (initialMinutes + (initialSeconds / 60))/60;
            timer = new Timer();
            timer.Tick += new System.EventHandler(OnTimerEvent);

        }


        public Chrono(int initialSeconds, int initialMinutes) :this(initialSeconds, initialMinutes, 0)  { }
        public Chrono(int initialSeconds) : this(initialSeconds, 0, 0) { }

        protected virtual void OnTimeOut(EventArgs e)
        {
            EventHandler handler = TimeOut;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler TimeOut;


        public bool IsNotTimeOut
        {
            get { return isNotTimeOut; }
            set
            {
                if (value != isNotTimeOut)
                    isNotTimeOut = value;
                    NotifyPropertyChanged("isNotTimeOut");
            }
        }

        public int InitialHours {
            get { return initialHours; }
            set {
                if (value != initialHours)
                    initialHours = value; }
        }

        public int InitialMinutes
        {
            get { return initialMinutes; }
            set
            {
                if (value != initialMinutes)
                    initialMinutes = value % 60;
                    InitialHours = InitialHours + (value / 60);
            }
        }

        public int InitialSeconds
        {
            get { return initialSeconds; }
            set
            {
                if (value != initialSeconds)
                    initialSeconds = value % 60;
                InitialMinutes = (InitialMinutes + (value / 60) %60);
            }
        }

        public int Hours
        {
            get { return hours; }
            set
            {
                if (value != hours)
                    hours = value;
                NotifyPropertyChanged("hours");
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value != minutes)
                    minutes = value;
                NotifyPropertyChanged("minutes");
            }
        }

        public int Seconds
        {
            get { return seconds; }
            set
            {
                if (value !=seconds)
                    seconds = value;
               NotifyPropertyChanged("seconds");
            }
        }

        // Methode pour demarrer le chrono

        public void startChrono() {
            isActive = true;
            initializeChrono();
            timer.Enabled = true;
           }

        public void stopChrono()
        {
            isActive = false;
            timer.Stop();
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            if (seconds > 0)
            {
                Seconds--;
            }
            else if (minutes > 0)
            {
                minutes--;
                seconds = 60;
            }
            else if (hours > 0)
            {
                hours--;
                minutes = 60;
            }
            else
            {
                minutes = 60;
            }
            if (hours==0 && minutes==0 && seconds==0)
            {
                isNotTimeOut = false;
                timer.Stop();
                OnTimeOut(EventArgs.Empty);
               
            }
        }

       
        public void initializeChrono (){
            timer.Interval= interval;
            this.seconds = initialSeconds;
            this.minutes = initialMinutes;
            this.hours = initialHours;

        }
        }
}

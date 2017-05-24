using System;
using System.Timers;

namespace ZooClassLibrary.MyTimer
{
    public class MyTimer
    {
        Zoo zoo;
        private Timer timer;
        public MyTimer(Zoo zoo)
        {
            this.zoo = zoo; 
            timer = new Timer(5000);
            timer.Elapsed += (sender, args) => PressureEvent(sender, args);
            timer.Start();
        }

        private void PressureEvent(object sender, ElapsedEventArgs args)
        {
            zoo.TimeForChangeState();
        }

        public void TimerStart()
        {
            timer.Start();
        }

        public void TimerStop()
        {
            timer.Stop();
        }
    }
}

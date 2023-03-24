using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSharpConsoleClockObserver
{
    public class Ticker
    {
        
        
        public delegate void OnTenthsDelegate();
        public delegate void OnSecondsDelegate();
        public delegate void OnHundredthsDelegate();
        public delegate void OnMinutesDelegate();

        
        public event OnTenthsDelegate OnTenthsTick;
        public event OnSecondsDelegate OnSecondsTick;
        public event OnHundredthsDelegate OnHundredthsTick;
        public event OnMinutesDelegate OnMinutesTick;

        private void NullHandler() {  }

        public Ticker()
        {
            OnSecondsTick = NullHandler;
            OnTenthsTick = NullHandler;
            OnHundredthsTick = NullHandler;
            OnMinutesTick = NullHandler;
        }

        private bool done;
        public bool Done
        {
            get { return done; }
            set { done = value; }
        }
        public void Run()
        {
            int count = 0;
            while (!done)
            {
                Interlocked.Increment(ref count);


                //timer.HundredthSecond();
                OnHundredthsTick();

                if (count % 10 == 0)
                {
                    OnTenthsTick();
                }
                if (count % 100 == 0)
                {
                    //timer.Second();
                    OnSecondsTick();
                }
                if (count % 6000 == 0)
                {
                    //timer.Minute();
                    OnMinutesTick();
                }
                //if (count % 36000 == 0)
                //{
                //    timer.Hour();
                //}
                
                if (count % 36000 == 0)
                {
                    count = 0;
                }
            }
        }
        
    }
}

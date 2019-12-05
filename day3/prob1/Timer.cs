using System;

namespace prob1
{
    class Timer
    {
        protected int interval;

        private Action<string> callback;

        public int Interval 
        { 
            get { return this.interval; }
            set { 
                if (value < 0 || value > 1000)
                {
                    throw new ArgumentException("Out of range");
                }

                this.interval = value * 60;
            }
        }

        public Timer(Action<string> callback)
        {
            this.callback = callback;
        }
        public void Start()
        {
            string message = "Waiting ... ";
            int i = 0;

            do
            {
                this.callback(message + i);
                i++;
                System.Threading.Thread.Sleep(this.Interval);
            } while(true);
        }
    }
}

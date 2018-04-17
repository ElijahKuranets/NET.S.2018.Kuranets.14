using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Timer
{
    public abstract class Listener
    {
        private string name;

        protected Listener(string name)
        {
            this.name = name;
        }

        protected string Name
        { get => name;
          set => name = value;
        }

        public virtual void Notify(string message, byte seconds)
        {
            var timer = new TimerLib(message, seconds);
            timer.Signal += SignalRecieved;
            timer.StartCountdown();
        }

        public void SignalRecieved(object sender, TimerLib.SignalEventArgs e)
        {
            Console.WriteLine($"{e.Now.ToLocalTime()}: {e.Message}");
        }
    }
}

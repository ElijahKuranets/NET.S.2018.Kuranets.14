using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    class Listener2 : Listener
    {
        public Listener2(string name) : base(name)
        {
        }

        public override void Notify(string message, byte seconds)
        {
            base.Notify($"{message}, {Name}!", seconds);
        }
    }
}

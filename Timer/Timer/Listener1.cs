using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    public class Listener1 : Listener
    {
        public Listener1(string name) : base(name)
            {}
        public override void Notify(string message, byte seconds)
        {
            base.Notify($"{message}, {Name}",seconds);
        }

    }
}

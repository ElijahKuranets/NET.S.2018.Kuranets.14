using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
     internal class Program
    {
        private static void Main(string[] args)
        { 
            var rick = new Listener1("Rick");
            rick.Notify("Okay", 5);

            var morty = new Listener2("Morty");
            morty.Notify("It's time to adventures", 3);

            Console.Read();
        }
    }
}

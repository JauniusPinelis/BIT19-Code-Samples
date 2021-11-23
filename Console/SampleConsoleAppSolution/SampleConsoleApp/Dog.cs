using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp
{
    public class Dog
    {
        public void Bark()
        {
            Console.WriteLine("Bark");
        }

        public static void StaticBark()
        {
            Console.WriteLine("Static Bark");
        }
    }
}

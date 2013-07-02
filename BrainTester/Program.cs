using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VDG.TheBrain;

namespace BrainTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Brain brain = new Brain();
            string diff = brain.diff("print(\"adsd 45\")", "print(\"asd 12223\")");
            Console.WriteLine(brain.GetPatterns(diff));
            Console.Read();
        }
    }
}

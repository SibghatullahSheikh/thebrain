using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDG
{
    namespace TheBrain
    {

        public delegate void SenseEventHandler(string description);

        public interface ISense
        {
            string Peek();
            string Imagine();
            string OnChange(SenseEventHandler handler);
        }
    }
}

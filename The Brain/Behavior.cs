using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDG
{
    namespace TheBrain
    {

        public interface IBehavior
        {
            string DoRandom();
            string Predict();
            string Do(string description);
        }
    }
}

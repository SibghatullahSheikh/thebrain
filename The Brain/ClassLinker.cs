using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDG
{
    namespace TheBrain
    {

        static class ClassLinker
        {
            public static Brain Brain = new Brain();
            public static GammaWorker GammaWorker = new GammaWorker();
            public static ChainWorker ChainWorker = new ChainWorker();
        }
    }
}

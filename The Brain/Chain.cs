using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDG
{
    namespace TheBrain
    {
        class Chain
        {
            private static int IDAutoIncrement = 0;

            private byte[] code;
            public int ID;

            public Chain(string script)
            {
                code = ClassLinker.GammaWorker.Compile(script);
                ID = IDAutoIncrement++;
            }

            public void Change(string script)
            {
                code = ClassLinker.GammaWorker.Compile(script);
            }

            public void Execute()
            {
                ClassLinker.GammaWorker.Run(code);
            }

        }
    }
}

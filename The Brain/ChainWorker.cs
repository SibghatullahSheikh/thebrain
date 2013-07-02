using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDG
{
    namespace TheBrain
    {

        class ChainWorker
        {
            private List<Chain> Chains;

            public ChainWorker()
            {
                Chains = new List<Chain>();
            }

            public Chain GetChainByID(int id)
            {
                return Chains.Exists(c => c.ID == id) ? Chains.Find(c => c.ID == id) : null;
            }

            public int AddChain(string script)
            {
                Chain toadd = new Chain(script);
                Chains.Add(toadd);
                return toadd.ID;
            }

        }
    }
}

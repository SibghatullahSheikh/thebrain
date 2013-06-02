using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDG
{
    namespace TheBrain
    {
        class GammaWorker
        {
            private object ChainExecute(object[] args){
                int id = (int)args[0];
                ClassLinker.ChainWorker.GetChainByID(id).Execute();
                return null;
            }

            public GammaWorker()
            {
                this.Init();
            }

            private void Init()
            {
                GammaRuntime.Init();
                GammaRuntime.AddFunction("ChainExecute", ChainExecute);
            }

            public void Run(byte[] script)
            {
                this.Init();
                GammaRuntime.VMRUn(script);
            }

            public byte[] Compile(string script)
            {
                GammaCompiler compiler = new GammaCompiler();
                return compiler.Compile(script);
            }

        }
    }
}

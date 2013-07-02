using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDG
{
    namespace TheBrain
    {

        public class EnergyWorker
        {
            long energy;
            public void AddEnergy(long value) { energy += value; }
            public void RemoveEnergy(long value) { energy -= value; }

            public byte Precentage()
            {
                return (byte)((energy * 100) / long.MaxValue);
            }

            public EnergyWorker()
            {
                energy = long.MaxValue;
            }

            public void Tick()
            {
                energy -= long.MaxValue/1000;
            }
        }

        public class GoodBadWorker
        {
            byte goodbad;
            public void Good(byte value) { goodbad = (byte)((goodbad + (goodbad + value)) / 2); }
            public void Bad(byte value) { goodbad = (byte)((goodbad - (goodbad - value)) / 2); }

            public byte Precentage()
            {
                return (byte)((goodbad * 100) / byte.MaxValue);
            }

            public GoodBadWorker()
            {
                goodbad = byte.MaxValue;
            }
        }

        public class Instinct
        {
            //ID
            System.Timers.Timer worker;
            EnergyWorker EnergyWorker;
            GoodBadWorker GoodBadWorker;

            public Instinct()
            {
                worker = new System.Timers.Timer(60);
                worker.Elapsed += Tick;
                EnergyWorker = new EnergyWorker();
                GoodBadWorker = new GoodBadWorker();
            }

            void Tick(object s, System.Timers.ElapsedEventArgs e)
            {
                EnergyWorker.Tick();
            }

            public void Good(byte value)
            {
                GoodBadWorker.Good(value);
            }

            public void Bad(byte value)
            {
                GoodBadWorker.Bad(value);
            }

        }
    }
}

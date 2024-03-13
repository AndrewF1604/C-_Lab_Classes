using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3_homework
{
    internal class OxygenBottle : IVisitPort
    {
        protected double maxcapacity;

        public OxygenBottle(double _maxcapacity)
        {
            this.maxcapacity = _maxcapacity;
        }
        public double MaxCapacity
        {
            get { return this.maxcapacity; }
        }

        protected double volume, weight;
        public double Volume
        {
            get { return volume; }

            set
            {
                volume = value;
                weight = value * 0.00142; // assume density oxygen
            }
        }
        public double Weight
        {
            get { return weight; }

            set
            {
                weight = value;
                volume = value / 0.00142; // assume density oxygen
            }
        }

        public double VisitPort()
        {
            double newoxygen = maxcapacity - volume;
            volume = MaxCapacity;
            return newoxygen * 2;
        }
    }
}

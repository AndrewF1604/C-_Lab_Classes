using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_homework
{
    class FoodContainer : IVisitPort
    {
        protected double maxcapacity;

        public FoodContainer(double _maxcapacity)
        {
            this.maxcapacity = _maxcapacity;
        }

        public double MaxCapacity
        {
            get { return maxcapacity; }
        }
        protected double volume, weight;
        public double Volume
        {
            get { return volume; }

            set
            {
                volume = value;
                weight = value * 3.3; //food density
            }
        }
        public double Weight
        {
            get { return weight; }

            set
            {
                weight = value;
                volume = value / 3.3;//food density
            }
        }

        public double VisitPort()
        {
            double newvolume = MaxCapacity - volume;
            this.Volume = MaxCapacity;
            return newvolume * 100;  // czy powinno byc rozróżninie cenowe na rodza paliwa ???
        }
    }
}

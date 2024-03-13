using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_homework
{
    class FuelTank: IVisitPort
    {
        protected double maxcapacity;
        private Fuel fueltype;

        public FuelTank (double _maxcapacity , Fuel _fueltype)
        {
            maxcapacity = _maxcapacity;
            this.fueltype = _fueltype;
        }

        public double MaxCapacity
        {
            get { return maxcapacity; }
        }

        public string CheckFuelMaterial()
        {
            return fueltype.Material;
        }

        protected double volume, weight;
        public double Volume
        {
            get { return volume; }

            set
            {
                volume = value;
                weight = value * fueltype.Density;
            }
        }
        public double Weight
        {
            get { return weight; }

            set
            {
                weight = value;
                volume = value / fueltype.Density;
            }
        }
        
        public double VisitPort()
        {
            double newvolume = MaxCapacity - volume;
            this.Volume = MaxCapacity;
            if (fueltype.Material == "Nuclear")
                return newvolume * 1000;  // nucler refile
            else
                return newvolume*7.55; //diesel cost
        }



    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_homework
{
    abstract class Fuel : ITransportable
    {
        protected double volume, weight;
        public double Volume
        {
            get { return volume; }

            set
            {
                volume = value;
                weight = value * 3.5;
            }
        }
        public double Weight
        {
            get { return weight; }

            set
            {
                weight = value;
                volume = value / 3.5;
            }
        }

        protected string material;
        public string Material
        {
            get { return material; }
        }

        protected double density;
        public double Density { get { return density; } }
        
    }
}

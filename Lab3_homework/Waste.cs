using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3_homework
{
    class Waste : IVisitPort
    {
        protected double volume, weight;
        public double Volume
        {
            get { return volume; }

            set
            {
                volume = value;
                weight = value * 2;
            }
        }
        public double Weight
        {
            get { return weight; }

            set
            {
                weight = value;
                volume = value / 2;
            }
        }

        public double VisitPort()
        {
            this.Volume = 0;
            return 500; 
        }
    }
}

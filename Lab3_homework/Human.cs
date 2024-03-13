using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_homework
{
    abstract class Human : ITransportable
    {
        private string name = "No Name";

        public Human()
        {
            Name = "No Name";
        }
        public Human(string _name)
        {
            Name = _name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        protected double volume, weight;
        public double Volume
        {
            get { return volume; }

            set
            {
                volume = value;
                weight = value * (1350/63);
            }
        }
        public double Weight
        {
            get { return weight; }

            set
            {
                weight = value;
                volume = value / (1350 / 63);
            }
        }
    }
}

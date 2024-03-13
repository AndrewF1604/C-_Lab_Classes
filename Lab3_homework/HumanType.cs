using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_homework
{
    class Crewman : Human
    {
        //for future use
    }


    class Scientist : Human
    {
        private Equipment equipment;

        public Scientist(Equipment _equipment)
        {
            this.equipment = _equipment;
        }

        public void Work(double time)
        {
            for(double temp=0; temp < time; temp += 24)
            {
                equipment.GatherData();
            }
        }

    }
}

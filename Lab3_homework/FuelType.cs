using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_homework
{
    class FuelDiesel : Fuel
    {
        public FuelDiesel ()
        {
            density = 0.86;
            material = "Diesel";
        }
    }

    class FuelNuclear : Fuel
    {
        public FuelNuclear()
        {
            density = 16;
            material = "Nuclear";
        }

    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_homework
{
    class LifeSupportSystem
    {
        private List<OxygenBottle> oxygenbuttles;
        private FoodContainer foodContainer;
        private Waste waste;
        private List<Human> crew;

        public LifeSupportSystem(List<OxygenBottle> _oxygenbuttles, FoodContainer _foodContainer, Waste _waste, List<Human> _crew)
        {
            oxygenbuttles = _oxygenbuttles;
            foodContainer = _foodContainer;
            crew = _crew;
            waste = _waste;
        }

        public bool CheckSuppliesBeforeTravel(double travelTime)
        {
            double totalOxygen = 0;
            foreach (OxygenBottle buttle in oxygenbuttles)
            {
                totalOxygen += buttle.Volume;
            }

            if (totalOxygen <= (crew.Capacity * 10 * travelTime/24))
            {
                return false;
            }
            else
            {
                if (foodContainer.Weight <= (travelTime * crew.Capacity))
                    return false;
                else
                    return true;
            }
                

        }

        public void Run(double time)
        {
            foreach (OxygenBottle buttle in oxygenbuttles)
            {
                buttle.Volume -= (time / 24 * crew.Capacity *10 / oxygenbuttles.Capacity);
            }
            waste.Volume += (time / 24) * crew.Capacity;
            foodContainer.Volume -= time/24 * crew.Capacity;
        }
    }
}

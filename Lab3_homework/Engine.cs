using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab3_homework
{
    
    class Engine
    {
        private FuelTank tank;
        private Waste waste;

        public Engine (FuelTank _tank , Waste _waste)
        {
            this.tank = _tank;
            this.waste = _waste;
        }

        public double GetVelocity (double submarineWeigth)
        {
            if (tank.CheckFuelMaterial() == "Diesel")
                return 50 - Math.Log2(100 + submarineWeigth);
            else if (tank.CheckFuelMaterial() == "Nuclear")
                return 100 - Math.Log2(100 + submarineWeigth);


            else
                return 0;
        }

        public bool CheckFuelBeforeTravel(double travelTime)
        {
            if (tank.CheckFuelMaterial() == "Diesel")
                if (tank.Volume / 0.1 >= travelTime && tank.Volume != 0)    //  5l/h 
                    return true;
                else
                    return false;
            else if (tank.CheckFuelMaterial() == "Nuclear")
                if (tank.Volume / 0.01 >= travelTime && tank.Volume != 0)    //  0.01 / h
                    return true;
                else
                    return false;
            else 
            {
                //Console.WriteLine(tank.CheckFuelMaterial(), "1");
                return false;
            }
        }

        public void Travel(double travelTime)
        {
            if (tank.CheckFuelMaterial() == "Diesel"){
                tank.Volume -= 5*travelTime;
                waste.Volume += 5 * travelTime;
            }
            else if (tank.CheckFuelMaterial() == "Nuclear"){
                tank.Volume -= 0.01 * travelTime;
                waste.Volume += 0.01 * travelTime;
            }
        }
    }
}

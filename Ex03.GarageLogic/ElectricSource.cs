using System;

namespace Ex03.GarageLogic
{
    public class ElectricSource : EnergySource
    {
        public ElectricSource(float i_MaxBatteryTime) : base(i_MaxBatteryTime)
        {

        }

        protected override string UnitName
        {
            get
            {
                return "Hours";
            }
        }

        public void chargeElectricVehicle(float i_HoursToAdd)
        {
            this.AddEnergy(i_HoursToAdd);
        }
        public override string ToString()
        {

            return "Electricity: " + " " + base.ToString();

        }
    }
}

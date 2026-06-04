using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricSource : EnergySource
    {
        public ElectricSource(float i_MaxBatteryTime) : base(i_MaxBatteryTime) { }

        protected override string UnitName
        {
            get
            {
                return "Hours";
            }
        }

        public void ChargeElectricVehicle(float i_HoursToAdd)
        {
            this.AddEnergy(i_HoursToAdd);
        }

        public override string ToString()
        {
            StringBuilder electricSourceDetails = new StringBuilder();

            electricSourceDetails.AppendLine("Energy Type: Electricity");
            electricSourceDetails.Append(base.ToString());

            return electricSourceDetails.ToString();
        }
    }
}

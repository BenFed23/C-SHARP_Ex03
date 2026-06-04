using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelSource : EnergySource
    {
        private eFuelType m_FuelType;
 
        public FuelSource(float i_MaxCapacity, eFuelType i_FuelType): base(i_MaxCapacity)
        {
            m_FuelType = i_FuelType;    
        }
      
        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public void RefuelVehicle(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType == m_FuelType)
            {
                this.AddEnergy(i_AmountOfFuelToAdd);
            }
            else
            {
                throw new ArgumentException("Wrong fuel type");
            }
        }

        public override string ToString()
        {
            StringBuilder fuelSourceDetails = new StringBuilder();

            fuelSourceDetails.AppendLine("Energy Type: Fuel");
            fuelSourceDetails.AppendLine(string.Format("Fuel Type: {0}", m_FuelType));
            fuelSourceDetails.Append(base.ToString());

            return fuelSourceDetails.ToString();
        }

        protected override string UnitName
        {
            get
            {
                return "Liters";
            }
        }
    }
}

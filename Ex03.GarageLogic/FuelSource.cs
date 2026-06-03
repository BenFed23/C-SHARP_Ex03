using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelSource : EnergySource
    {
        private eFuelType m_fuelType;
 
        public FuelSource(float i_maxcapacity,eFuelType i_fuelType): base(i_maxcapacity)
        {
            m_fuelType = i_fuelType;    
        }
      
        public eFuelType FuelType
        {
            get
            {
                return m_fuelType;
            }
        }

        public void RefuelVehicle(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType == m_fuelType)
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
            fuelSourceDetails.AppendLine(string.Format("Fuel Type: {0}", m_fuelType));
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

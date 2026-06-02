using System;


namespace Ex03.GarageLogic
{
    public class FuelSource : EnergySource
    {
        private eFuelType m_fuelType;
        private float m_fuelAmount;
        private float m_maxFuelCapacity;
        public float MaxFuelCapacity
        {
            get
            {
                return m_maxFuelCapacity;
            }
            set
            {
                m_maxFuelCapacity = value;
            }
        }
        public float FuelAmount
        {
            get
            {
                return m_fuelAmount;
            }
            set
            {
                m_fuelAmount = value;
            }
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
            return m_fuelType.ToString() + " " + m_CurrentEnergyAmount.ToString() + m_MaxEnergyAmount.ToString() ;
        }

    }
}

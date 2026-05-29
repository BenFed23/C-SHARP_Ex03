using System;


namespace Ex03.GarageLogic
{
    internal class FuelSource
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

    }
}

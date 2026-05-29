using System;


namespace Ex03.GarageLogic
{
    public class FuelSource : EnergySource
    {
        private readonly eFuelType m_FuelType;

        public FuelSource(float i_MaxFuelCapacity, eFuelType i_FuelType) : base(i_MaxFuelCapacity)
        {
            m_FuelType = i_FuelType;
        }

        public void Refuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            if(i_FuelType != m_FuelType)
            {
                //exception
            }
       

            this.AddEnergy(i_AmountOfFuelToAdd);
        }


    }
}

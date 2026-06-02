using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class FuelCar: Car
    {
        
        protected FuelSource m_FuelSource;

        public FuelCar( string i_idPlate, string  i_ModelName) : base( i_idPlate, i_ModelName)
        {
            m_FuelSource = new FuelSource(51 , eFuelType.Octan95 );
            
        }

        public override void Refuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {

            m_FuelSource.RefuelVehicle(i_AmountOfFuelToAdd, i_FuelType);
            m_energyPercentages = (m_FuelSource.FuelAmount/m_FuelSource.MaxFuelCapacity)*100; 
        }
        public override string ToString()
        {
            string details = base.ToString();
            details += m_FuelSource.ToString();
            return details;
        }
        public override List<string> GetSpecialPrameters() 
        {
            return new List<string>();
        }



    } 
}

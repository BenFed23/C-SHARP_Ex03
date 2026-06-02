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
            m_energyPercentages = (m_FuelSource.CurrentAmount/m_FuelSource.MaxCapacity)*100; 
        }

        public override List<string> GetSpecialPrameters()
        {
            List<string> specialParameters = GetCarBaseParameters();

            specialParameters.Add("float currentFuelAmountInLiters");

            return specialParameters;
        }

        public override void SetSpecialParameters(List<string> i_SpecialParameters)
        {
            SetCarBaseParameters(i_SpecialParameters);
            if (!float.TryParse(i_SpecialParameters[2], out float currentFuelAmount))
            {
                throw new FormatException("Invalid fuel amount format. Please enter a number.");
            }

            if (currentFuelAmount > m_FuelSource.MaxCapacity)
            {
                throw new ValueRangeException(0, m_FuelSource.MaxCapacity, "Fuel amount exceeds tank capacity");
            }

            m_FuelSource.CurrentAmount = currentFuelAmount;
        }
    }
}

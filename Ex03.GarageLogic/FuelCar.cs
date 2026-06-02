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
            List<string> specialParameters = new List<string>();

            specialParameters.Add("eCarColor carColor");
            specialParameters.Add("eNumberOfDoors numOfDoors");
            specialParameters.Add("float currentFuelAmountInLiters");

            return specialParameters;
        }

        public override void SetSpecialParameters(List<string> i_Parameters)
        {
            if (!Enum.TryParse(i_Parameters[0], out eCarColor carColor))
            {
                throw new FormatException("Invalid car color");
            }

            if (!Enum.TryParse(i_Parameters[1], out eNumberOfDoors numberOfDoors))
            {
                throw new FormatException("Invalid number of doors");
            }

            if (!float.TryParse(i_Parameters[2], out float currentFuelAmount))
            {
                throw new FormatException("Invalid fuel amount format. Please enter a number.");
            }

            if (currentFuelAmount > m_FuelSource.MaxCapacity)
            {
                throw new ValueRangeException(0, m_FuelSource.MaxCapacity, "Fuel amount exceeds tank capacity");
            }

            m_carColor = carColor;
            m_numOfDoors = numberOfDoors;
            m_FuelSource.CurrentAmount = currentFuelAmount;
        }
    }
}

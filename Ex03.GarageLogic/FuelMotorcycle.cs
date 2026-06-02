using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle: Motorcycle
    {
        protected FuelSource m_FuelSource;

        public FuelMotorcycle(string i_LicensePlateNumber, string i_ModelName) : base(i_LicensePlateNumber, i_ModelName)
        {
            m_FuelSource = new FuelSource(5.6f, eFuelType.Octan98);
        }
        public override void Refuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            m_FuelSource.RefuelVehicle(i_AmountOfFuelToAdd, i_FuelType);
        }

        public override List<string> GetSpecialPrameters()
        {
            List<string> specialParameters = GetMotorcycleBaseParameters();

            specialParameters.Add("float currentFuelAmountInLiters");

            return specialParameters;
        }

        public override void SetSpecialParameters(List<string> i_SpecialParameters)
        {
            SetMotorcycleBaseParameters(i_SpecialParameters);
            if (!float.TryParse(i_SpecialParameters[2], out float currentFuelAmount))
            {
                throw new FormatException("Invalid fuel amount format");
            }

            if (currentFuelAmount > m_FuelSource.MaxCapacity)
            {
                throw new ValueRangeException(0, m_FuelSource.MaxCapacity, "Fuel amount exceeds tank capacity");
            }

            m_FuelSource.CurrentAmount = currentFuelAmount;
            m_energyPercentages = m_FuelSource.EnergyPercentage;
        }
        public override string ToString()
        {
            string fuelMotorcycleDetails = base.ToString() + " " + m_FuelSource.ToString();

            return fuelMotorcycleDetails;
        }
    }
}

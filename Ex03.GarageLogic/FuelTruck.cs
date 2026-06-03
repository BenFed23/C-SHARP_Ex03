using System;
using System.Text;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class FuelTruck: Vehicle
    {
        private bool m_HasRefrigeratedCargo;
        private float m_CargoVolume;
        protected FuelSource m_FuelSource;
        private const int k_AmountOfWheels = 14;
        private const int k_MaxAirPressure = 23;

        public FuelTruck(string i_ModelName, string i_LicensePlateNumber) : base(i_ModelName, i_LicensePlateNumber)
        {
            m_tyresCollection = new Tyre[k_AmountOfWheels];
            for (int i = 0; i < m_tyresCollection.Length; i++)
            {
                m_tyresCollection[i] = new Tyre(k_MaxAirPressure);
                m_FuelSource = new FuelSource(125, eFuelType.Soler);
                m_HasRefrigeratedCargo = false;
                m_CargoVolume = 0;
            }
        }

        public override void Refuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            m_FuelSource.RefuelVehicle(i_AmountOfFuelToAdd, i_FuelType);
            m_energyPercentages = (m_FuelSource.CurrentAmount / m_FuelSource.MaxCapacity) * 100;
        }

        public override List<string> GetSpecialPrameters()
        {
            List<string> specialParameters = new List<string>();

            specialParameters.Add("if it has refrigerated cargo");
            specialParameters.Add("cargo volume");
            specialParameters.Add("current fuel amount in liters");

            return specialParameters;
        }

        public override void SetSpecialParameters(List<string> i_Parameters)
        {
            if (!bool.TryParse(i_Parameters[0], out bool isRefrigerated))
            {
                throw new FormatException("Invalid input for refrigerated cargo. Please enter 'true' or 'false'.");
            }

            if (!float.TryParse(i_Parameters[1], out float cargoVolume))
            {
                throw new FormatException("Invalid cargo volume");
            }

            if (!float.TryParse(i_Parameters[2], out float currentFuelAmount))
            {
                throw new FormatException("Invalid fuel amount");
            }

            if (currentFuelAmount > m_FuelSource.MaxCapacity)
            {
                throw new ValueRangeException(0, m_FuelSource.MaxCapacity, "Fuel amount exceeds tank capacity");
            }

            m_HasRefrigeratedCargo = isRefrigerated;
            m_CargoVolume = cargoVolume;
            m_FuelSource.CurrentAmount = currentFuelAmount;
            m_energyPercentages = m_FuelSource.EnergyPercentage;
        }
       
        public override string ToString()
        {
            StringBuilder truckDetails = new StringBuilder();

            truckDetails.AppendLine(base.ToString());
            truckDetails.AppendLine(string.Format("Has Refrigerated Cargo: {0}", m_HasRefrigeratedCargo ? "Yes" : "No"));
            truckDetails.AppendLine(string.Format("Cargo Volume: {0}", m_CargoVolume));
            if (m_tyresCollection != null && m_tyresCollection.Length > 0)
            {
                truckDetails.AppendLine(string.Format("Wheels Information ({0} wheels):", m_tyresCollection.Length));
                truckDetails.AppendLine(m_tyresCollection[0].ToString());
            }

            truckDetails.AppendLine("*** Engine Details: ***");
            truckDetails.Append(m_FuelSource.ToString());

            return truckDetails.ToString();
        }
    }
}

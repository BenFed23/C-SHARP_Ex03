using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle: Motorcycle
    {
        protected FuelSource m_FuelSource;
        public FuelMotorcycle(string i_LicensePlateNumber, string i_ModelName) : base(i_LicensePlateNumber, i_ModelName)
        {

        }

        public override void Refuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            m_FuelSource.RefuelVehicle(i_AmountOfFuelToAdd, i_FuelType);
        }

        public override List<string> GetSpecialPrameters()
        {
            List<string> specialParameters = new List<string>();

            specialParameters.Add("eLicenseType licenseType");
            specialParameters.Add("int engineVolume");
            specialParameters.Add("float currentFuelAmountInLiters");

            return specialParameters;
        }

        public override void SetSpecialParameters(List<string> i_Parameters)
        {
            if (!Enum.TryParse(i_Parameters[0], out eLicenseType licenseType))
            {
                throw new FormatException("Invalid license type");
            }

            if (!int.TryParse(i_Parameters[1], out int engineVolume))
            {
                throw new FormatException("Invalid engine volume format");
            }

            if (!float.TryParse(i_Parameters[2], out float currentFuelAmount))
            {
                throw new FormatException("Invalid fuel amount format");
            }

            if (currentFuelAmount > m_FuelSource.MaxCapacity)
            {
                throw new ValueRangeException(0, m_FuelSource.MaxCapacity, "Fuel amount exceeds tank capacity");
            }

            m_LicenseType = licenseType;
            m_EngineVolume = engineVolume;
            m_FuelSource.CurrentAmount = currentFuelAmount;
        }
    }
}

using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle: Motorcycle
    {
        protected ElectricSource m_ElectricSource;

        public ElectricMotorcycle(string i_LicensePlateNumber, string i_ModelName): base(i_LicensePlateNumber, i_ModelName)
        {
            m_ElectricSource = new ElectricSource(3.0f);
        }

        public override void Charge(float i_AmountOfMinutesToCharge)
        {
            m_ElectricSource.chargeElectricVehicle(i_AmountOfMinutesToCharge / 60f);
        }

        public override List<string> GetSpecialPrameters() 
        {
            List<string> specialParameters = new List<string>();
            specialParameters.Add("eLicenseType licenseType");
            specialParameters.Add("float engineVolume");
            specialParameters.Add("float currentBatteryTimeInHours");
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
                throw new FormatException("Invalid engine volume");
            }

            if (!float.TryParse(i_Parameters[2], out float currentBattery))
            {
                throw new FormatException("Invalid battery time. Please enter a number.");
            }

            m_LicenseType = licenseType;
            m_EngineVolume = engineVolume;
            m_ElectricSource.CurrentAmount = currentBattery;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected eLicenseType m_LicenseType;
        protected int m_EngineVolume;
        private const int k_AmountOfWheels = 2;
        private const int k_MaxAirPressure = 30;

        public Motorcycle(string i_LicensePlateNumber, string i_ModelName) : base(i_LicensePlateNumber, i_ModelName)
        {
           m_tyresCollection = new Tyre[k_AmountOfWheels];
            for (int i = 0; i<m_tyresCollection.Length;i++ )
            {
                m_tyresCollection[i] = new Tyre(k_MaxAirPressure);
            } 
        }

        protected List<string> GetMotorcycleBaseParameters()
        {
            List<string> baseMotorcycleParameters = new List<string>();
            string licenseOptions = string.Join(", ", Enum.GetNames(typeof(eLicenseType)));

            baseMotorcycleParameters.Add($"license type ({licenseOptions})");
            baseMotorcycleParameters.Add("engine volume (int)");

            return baseMotorcycleParameters;
        }

        protected void SetMotorcycleBaseParameters(List<string> i_BaseMotorcycleParameters)
        {
            if (!Enum.TryParse(i_BaseMotorcycleParameters[0], out eLicenseType licenseType))
            {
                throw new FormatException("Invalid license type");
            }

            if (!int.TryParse(i_BaseMotorcycleParameters[1], out int engineVolume))
            {
                throw new FormatException("Invalid engine volume");
            }

            m_LicenseType = licenseType;
            m_EngineVolume = engineVolume;
        }

    }
}

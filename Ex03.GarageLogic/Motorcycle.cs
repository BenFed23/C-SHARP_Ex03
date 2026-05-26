using System;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected eLicenseType m_LicenseType;
        protected int m_EngineVolume;
        private const int k_AmountOfWheels = 2;
        private const int k_MaxAirPressure = 30;

        public Motorcycle(string i_ModelName, string i_LicenseNumber) : base(i_ModelName, i_LicenseNumber)
        {
            InitTyres(k_AmountOfWheels, k_MaxAirPressure);
        }
    }
}

using System;

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
    }
}

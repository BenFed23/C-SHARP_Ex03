using System;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        string m_modelName;
        string m_licensePlateNumber;
        float m_energyPercentages;
        protected Tyre[] m_tyresCollection; 
        public Vehicle(string i_LicensePlateNumber, string i_ModelName)
        {
            m_modelName = i_ModelName;
            m_licensePlateNumber = i_LicensePlateNumber;
            m_energyPercentages = 100;
            m_tyresCollection = null;
        }

        protected void InitTyres(int i_AmountOfWheels, float i_MaxAirPressure)
        {
            m_tyresCollection = new Tyre[i_AmountOfWheels];
            for (int i = 0; i < i_AmountOfWheels; i++)
            {
                m_tyresCollection[i] = new Tyre(i_MaxAirPressure);
            }
        }
    }
}

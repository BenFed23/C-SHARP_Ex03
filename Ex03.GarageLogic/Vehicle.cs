using System;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
       private string m_modelName;
       private string m_licenseNumber;
       float m_energyPercentages;

        protected Tyre[] m_tyresCollection; 
        public Vehicle(string i_modelName, string i_licenseNumber) 
        {
            m_modelName = i_modelName;
            m_licenseNumber = i_licenseNumber;
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

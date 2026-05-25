using System;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        string m_modelName;
        string m_licenseNumber;
        float m_energyPercentages;
        Tyre[] m_tyresCollection; 
        public Vehicle(string i_modelName, string i_licenseNumber) 
        {
            m_modelName = i_modelName;
            m_licenseNumber = i_licenseNumber;
            m_energyPercentages = 100;
            m_tyresCollection = null;
        }
    }
}

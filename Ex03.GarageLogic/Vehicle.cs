using System;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        string m_modelName;
        string m_licenseNumber;
        float m_energyPercentages;
        Tyre[] m_tyresCollection; 
    }
}

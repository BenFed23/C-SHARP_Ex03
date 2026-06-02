using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
       private string m_modelName;
       private string m_licensePlateNumber;
       protected float m_energyPercentages;
       protected Tyre[] m_tyresCollection; 
        public Vehicle(string i_LicensePlateNumber, string i_ModelName)
        {
            m_modelName = i_ModelName;
            m_licensePlateNumber = i_LicensePlateNumber;
            m_energyPercentages = 100;
            m_tyresCollection = null;
        }
        public Tyre[] GetTyresColaction()
        {
            return m_tyresCollection;
        }

        public virtual void Refuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            throw new ArgumentException("This vehicle isn't run by fuel");
        }

        public virtual void Charge(float i_AmountOfMinutesToCharge)
        {
            throw new ArgumentException("This vehicle isn't run by Electricity");
        }
        public abstract List<string> GetSpecialPrameters();
        public  override string ToString() 
        {
            string details =  m_modelName + " " + m_licensePlateNumber + m_energyPercentages.ToString() + " " ; 
            foreach(Tyre tyre in m_tyresCollection)
            {
                details += tyre.ToString(); 
            }
            

            return details;
        }
        
       
    }
}

using System;


namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected float m_CurrentEnergyAmount;
        protected float m_MaxEnergyAmount;

        protected EnergySource(float i_MaxEnergyAmount)
        {
            m_MaxEnergyAmount = i_MaxEnergyAmount;
            m_CurrentEnergyAmount = 0;
        }

        protected void  AddEnergy (float i_EnergyAmountToAdd)
        {
            if(i_EnergyAmountToAdd < 0)
            {
                //exception
            }
            
            if(m_CurrentEnergyAmount + i_EnergyAmountToAdd > m_MaxEnergyAmount)
            {
                //exception
            }

            m_CurrentEnergyAmount += i_EnergyAmountToAdd;
        }
    }
}

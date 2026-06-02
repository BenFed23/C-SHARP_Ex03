using System;


namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private const float k_MinEnergyAmountToAdd = 0.0f;
        protected float m_CurrentEnergyAmount;
        protected float m_MaxEnergyAmount;

        protected EnergySource(float i_MaxEnergyAmount)
        {
            m_MaxEnergyAmount = i_MaxEnergyAmount;
            m_CurrentEnergyAmount = 0;
        }

        public float MaxCapacity
        {
            get
            {
                return m_MaxEnergyAmount;
            }
            set
            {
                m_MaxEnergyAmount = value;
            }
        }

        public float CurrentAmount
        {
            get
            {
                return m_CurrentEnergyAmount;
            }
            set
            {
                m_CurrentEnergyAmount = value;
            }
        }

        protected void AddEnergy (float i_EnergyAmountToAdd)
        {
            if(i_EnergyAmountToAdd < 0)
            {
                throw new ArgumentException("Cannot add a negative amount of energy");
            }
            
            if(m_CurrentEnergyAmount + i_EnergyAmountToAdd > m_MaxEnergyAmount)
            {
                float maxPossibleAmountToAdd = m_MaxEnergyAmount - m_CurrentEnergyAmount;
                throw new ValueRangeException(k_MinEnergyAmountToAdd, m_MaxEnergyAmount, $"You tried adding {i_EnergyAmountToAdd} but you can only add up to {maxPossibleAmountToAdd}");
            }

            m_CurrentEnergyAmount += i_EnergyAmountToAdd;
        }

        public float EnergyPercentage
        {
            get
            {
                return (m_CurrentEnergyAmount/ m_CurrentEnergyAmount) * 100;
            }
        }
    }
}

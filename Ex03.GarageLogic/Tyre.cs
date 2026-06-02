using System;


namespace Ex03.GarageLogic
{
    public class Tyre
    {
        string m_ManufacturerName;
        float m_CurrentAirPresure;
        float m_MaxAirPresure;

        public Tyre(float i_MaxAirPresure)
        {
            m_MaxAirPresure = i_MaxAirPresure;
            m_CurrentAirPresure = 0;
        }

        public bool InflateTire(float i_airToFile) 
        {
            bool succes = true;
            if (m_CurrentAirPresure + i_airToFile > m_MaxAirPresure) 
            {
                succes = false;
            }
            else 
            {
                m_CurrentAirPresure += i_airToFile;
            }

            return succes;
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPresure;
            }
            set
            {
                m_MaxAirPresure = value;
            }
        }
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPresure;
            }
            set
            {
                m_CurrentAirPresure = value;
            }
        }
    }
}

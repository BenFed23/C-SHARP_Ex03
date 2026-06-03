using System;


namespace Ex03.GarageLogic
{
    public class Tyre
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPresure;
        private float m_MaxAirPresure;

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

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                m_ManufacturerName = value;
            }
        }
        public override string ToString()
        {
            return "Manufacture Name: " + m_ManufacturerName + " " + "Current tyre air presure: " + m_CurrentAirPresure ;
        }
    }
}

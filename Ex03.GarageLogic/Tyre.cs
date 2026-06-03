using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Tyre
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Tyre(float i_MaxAirPresure)
        {
            m_MaxAirPressure = i_MaxAirPresure;
            m_CurrentAirPressure = 0;
        }

        public bool InflateTire(float i_airToFile) 
        {
            bool succes = true;
            if (m_CurrentAirPressure + i_airToFile > m_MaxAirPressure) 
            {
                succes = false;
            }
            else 
            {
                m_CurrentAirPressure += i_airToFile;
            }

            return succes;
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
            set
            {
                m_MaxAirPressure = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
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
            StringBuilder tyreDetails = new StringBuilder();

            tyreDetails.AppendLine(string.Format("Manufacturer: {0}", m_ManufacturerName));
            tyreDetails.Append(string.Format("Air Pressure: {0} (Max: {1})", m_CurrentAirPressure, m_MaxAirPressure));

            return tyreDetails.ToString();
        }
    }
}

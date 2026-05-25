using System;


namespace Ex03.GarageLogic
{
    internal class Tyre
    {
        string m_menafactureName;
        float m_currentAirPresure;
        float m_maxAirPresure;
        public bool InflateTire(float i_airToFile) 
        {
            bool succes = true;
            if (m_currentAirPresure + i_airToFile > m_maxAirPresure) 
            {
                succes = false;
            }
            else 
            {
                m_currentAirPresure += i_airToFile;
            }

            return succes;
        }
    }
}

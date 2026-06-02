using System;


namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eCarColor m_carColor;
        protected eNumberOfDoors m_numOfDoors;
        private const int k_AmountOfWheels = 5;
        private const int k_MaxAirPressure = 31;
        public Car(string i_LicensePlateNumber, string i_ModelName) : base( i_LicensePlateNumber,  i_ModelName)
        {
            m_tyresCollection = new Tyre[k_AmountOfWheels];
            for (int i = 0; i < m_tyresCollection.Length; i++)
            {
                m_tyresCollection[i] = new Tyre(k_MaxAirPressure);
            }
            m_numOfDoors = eNumberOfDoors.Option4;
            m_carColor = eCarColor.Red;
        }
        public override string ToString()
        {
            string details = base.ToString();
            details += m_carColor + " " + " " + m_numOfDoors;
            return details;
        }
         
    }

}

using System;


namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eCarColor m_carColor;
        protected eNumberOfDoors m_numOfDoors;
        private const int k_AmountOfWheels = 5;
        private const int k_MaxAirPressure = 31;

        public Car(string i_LicensePlateNumber, string i_ModelName) : base(i_LicensePlateNumber, i_ModelName)
        {
            m_tyresCollection = new Tyre[k_AmountOfWheels];
            for (int i = 0; i < m_tyresCollection.Length; i++)
            {
                m_tyresCollection[i] = new Tyre(k_MaxAirPressure);
            }
            m_numOfDoors = eNumberOfDoors.Option4;
            m_carColor = eCarColor.Red;
        }

        protected List<string> GetCarBaseParameters()
        {
            List<string> baseCarParameters = new List<string>();
            string colorOptions = string.Join(", ", Enum.GetNames(typeof(eCarColor)));
            string numberOfDoorOptions = string.Join(", ", Enum.GetNames(typeof(eNumberOfDoors)));

            parameters.Add($"car color ({colorOptions})");
            parameters.Add($"number of doors ({doorOptions})");

            return parameters;
        }

        protected void SetCarBaseParameters(List<string> i_Parameters)
        {
            if (!Enum.TryParse(i_Parameters[0], out eCarColor carColor))
            {
                throw new FormatException("Invalid car color");
            }

            if (!Enum.TryParse(i_Parameters[1], out eNumberOfDoors numberOfDoors))
            {
                throw new FormatException("Invalid number of doors");
            }

            m_carColor = carColor;
            m_numOfDoors = numberOfDoors;
        }
    }

}

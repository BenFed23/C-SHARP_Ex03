using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private eCarColor m_carColor;
        private eNumberOfDoors m_numOfDoors;
        private const int k_AmountOfWheels = 5;
        private const int k_MaxAirPressure = 31;

        public Car(string i_LicensePlateNumber, string i_ModelName) : base(i_LicensePlateNumber, i_ModelName)
        {
            m_tyresCollection = new Tyre[k_AmountOfWheels];
            for (int i = 0; i < m_tyresCollection.Length; i++)
            {
                m_tyresCollection[i] = new Tyre(k_MaxAirPressure);
            }
            m_numOfDoors = eNumberOfDoors.FiveDoors;
            m_carColor = eCarColor.Red;
        }

        protected List<string> GetCarBaseParameters()
        {
            List<string> baseCarParameters = new List<string>();
            string colorOptions = string.Join(", ", Enum.GetNames(typeof(eCarColor)));
            string numberOfDoorOptions = string.Join(", ", Enum.GetNames(typeof(eNumberOfDoors)));

            baseCarParameters.Add($"car color ({colorOptions})");
            baseCarParameters.Add($"number of doors ({numberOfDoorOptions})");

            return baseCarParameters;
        }

        protected void SetCarBaseParameters(List<string> i_baseCarParameters)
        {
            if (!Enum.TryParse(i_baseCarParameters[0], out eCarColor carColor))
            {
                throw new FormatException("Invalid car color");
            }

            if (!Enum.TryParse(i_baseCarParameters[1], out eNumberOfDoors numberOfDoors))
            {
                throw new FormatException("Invalid number of doors");
            }

            m_carColor = carColor;
            m_numOfDoors = numberOfDoors;
        }
        public override string ToString()
        {
            string carDetails =  base.ToString();
            carDetails += " " + "Car color: " + m_carColor.ToString() + " " + "Num of doors: " + m_numOfDoors.ToString();

            return carDetails;
        }
    }

}

using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumOfDoors;
        private const int k_AmountOfWheels = 5;
        private const int k_MaxAirPressure = 31;

        public Car(string i_LicensePlateNumber, string i_ModelName) : base(i_LicensePlateNumber, i_ModelName)
        {
            m_TyresCollection = new Tyre[k_AmountOfWheels];
            for (int i = 0; i < m_TyresCollection.Length; i++)
            {
                m_TyresCollection[i] = new Tyre(k_MaxAirPressure);
            }
            m_NumOfDoors = eNumberOfDoors.FiveDoors;
            m_CarColor = eCarColor.Red;
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

        protected void SetCarBaseParameters(List<string> i_BaseCarParameters)
        {
            if (!Enum.TryParse(i_BaseCarParameters[0], out eCarColor carColor))
            {
                throw new FormatException("Invalid car color");
            }

            if (!Enum.TryParse(i_BaseCarParameters[1], out eNumberOfDoors numberOfDoors))
            {
                throw new FormatException("Invalid number of doors");
            }

            m_CarColor = carColor;
            m_NumOfDoors = numberOfDoors;
        }

        public override string ToString()
        {
            StringBuilder carDetails = new StringBuilder();

            carDetails.AppendLine(base.ToString());
            carDetails.AppendLine(string.Format("Car Color: {0}", m_CarColor));
            carDetails.AppendLine(string.Format("Number of Doors: {0}", m_NumOfDoors));

            if (m_TyresCollection != null && m_TyresCollection.Length > 0)
            {
                carDetails.AppendLine(string.Format("Wheels Information ({0} wheels):", m_TyresCollection.Length));
                carDetails.AppendLine(m_TyresCollection[0].ToString());
            }

            return carDetails.ToString();
        }
    }

}

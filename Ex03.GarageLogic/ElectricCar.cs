using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricCar: Car
    {
        protected ElectricSource m_ElectricSource;
        public ElectricCar(string i_idPlate, string i_ModelName): base( i_idPlate, i_ModelName)
        {
            m_ElectricSource = new ElectricSource(4.6f);
        }

        public override void Charge(float i_AmountOfMinutesToCharge)
        {
            m_ElectricSource.chargeElectricVehicle(i_AmountOfMinutesToCharge / 60f);
            m_energyPercentages = (m_ElectricSource.CurrentAmount / m_ElectricSource.MaxCapacity) * 100;
        }

        public override List<string> GetSpecialPrameters() 
        {
            List<string> specialParametes = new List<string>();
            specialParametes.Add("eCarColor carColor");
            specialParametes.Add("enumOfDors numOfDors");
            specialParametes.Add("float currentBatteryTimeInHours");

            return specialParametes;
        }

        public override void SetSpecialParameters(List<string> i_Parameters)
        {
            if (!Enum.TryParse(i_Parameters[0], out eCarColor carColor))
            {
                throw new FormatException("Invalid car color");
            }

            if (!Enum.TryParse(i_Parameters[1], out eNumberOfDoors numberOfDoors))
            {
                throw new FormatException("Invalid number of doors");
            }

            if (!float.TryParse(i_Parameters[2], out float currentBatteryTime))
            {
                throw new FormatException("Invalid battery time format. Please enter a number.");
            }

            m_carColor = carColor;
            m_numOfDoors = numberOfDoors;
            m_ElectricSource.CurrentAmount = currentBatteryTime;
        }
    }
}

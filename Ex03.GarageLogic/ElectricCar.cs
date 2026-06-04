using System;
using System.Text;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricCar: Car
    {
        protected ElectricSource m_ElectricSource;

        public ElectricCar(string i_IdPlate, string i_ModelName): base( i_IdPlate, i_ModelName)
        {
            m_ElectricSource = new ElectricSource(4.6f);
        }

        public override float MaxEnergyCapacity
        {
            get
            {
                return m_ElectricSource.MaxCapacity;
            }
        }

        public override void Charge(float i_AmountOfMinutesToCharge)
        {
            m_ElectricSource.ChargeElectricVehicle(i_AmountOfMinutesToCharge / 60f);
            m_EnergyPercentages = (m_ElectricSource.CurrentAmount / m_ElectricSource.MaxCapacity) * 100;
        }

        public override List<string> GetSpecialParameters() 
        {
            List<string> specialParameters = GetCarBaseParameters();
     
            specialParameters.Add("current battery time in hours");

            return specialParameters;
        }

        public override void SetSpecialParameters(List<string> i_SpecialParameters)
        {
            SetCarBaseParameters(i_SpecialParameters);
            if (!float.TryParse(i_SpecialParameters[2], out float currentBatteryTime))
            {
                throw new FormatException("Invalid battery time format. Please enter a number.");
            }
           
            m_ElectricSource.CurrentAmount = currentBatteryTime;
            m_EnergyPercentages = m_ElectricSource.EnergyPercentage;
        }

        public override string ToString()
        {
            StringBuilder electricCarDetails = new StringBuilder();

            electricCarDetails.AppendLine(base.ToString());
            electricCarDetails.AppendLine("*** Engine Details: ***");
            electricCarDetails.AppendLine(m_ElectricSource.ToString());

            return electricCarDetails.ToString();
        }
    }
}

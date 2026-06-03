using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle: Motorcycle
    {
        protected ElectricSource m_ElectricSource;

        public ElectricMotorcycle(string i_LicensePlateNumber, string i_ModelName): base(i_LicensePlateNumber, i_ModelName)
        {
            m_ElectricSource = new ElectricSource(3.0f);
        }

        public override void Charge(float i_AmountOfMinutesToCharge)
        {
            m_ElectricSource.chargeElectricVehicle(i_AmountOfMinutesToCharge / 60f);
        }

        public override List<string> GetSpecialPrameters() 
        {
            List<string> specialParameters = GetMotorcycleBaseParameters();

            specialParameters.Add("float currentBatteryTimeInHours");

            return specialParameters;
        }

        public override void SetSpecialParameters(List<string> i_SpecialParameters)
        {
            SetMotorcycleBaseParameters(i_SpecialParameters);
            if (!float.TryParse(i_SpecialParameters[2], out float currentBattery))
            {
                throw new FormatException("Invalid battery time. Please enter a number.");
            }

            m_ElectricSource.CurrentAmount = currentBattery;
            m_energyPercentages = m_ElectricSource.EnergyPercentage;
        }
        public override string ToString()
        {
            string motorcycleDetails = base.ToString();
            motorcycleDetails += m_ElectricSource.ToString();
            return motorcycleDetails;
        }
    }
}

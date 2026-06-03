using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_modelName;
        private string m_licensePlateNumber;
        protected float m_energyPercentages;
        protected Tyre[] m_tyresCollection;

        public Vehicle(string i_LicensePlateNumber, string i_ModelName)
        {
            m_modelName = i_ModelName;
            m_licensePlateNumber = i_LicensePlateNumber;
            m_energyPercentages = 100;
            m_tyresCollection = null;
        }
        public Tyre[] GetTyresColaction()
        {
            return m_tyresCollection;
        }
        public string getVehicleLicensePlateNumber()
        {
            return m_licensePlateNumber;
        }

        public virtual void Refuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            throw new ArgumentException("This vehicle isn't run by fuel");
        }

        public virtual void Charge(float i_AmountOfMinutesToCharge)
        {
            throw new ArgumentException("This vehicle isn't run by Electricity");
        }

        public void SetTyreDetails(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            foreach (Tyre tyre in m_tyresCollection)
            {
                tyre.ManufacturerName = i_ManufacturerName;
                tyre.CurrentAirPressure = i_CurrentAirPressure;
            }
        }

        public virtual List<string> GetBaseVehicleParameters()
        {
            List<string> baseParameters = new List<string>();

            baseParameters.Add("Model name");
            baseParameters.Add("Tyre's manufacturer name");
            baseParameters.Add("Current air pressure for the tyres");

            return baseParameters;
        }

        public virtual void SetBaseVehicleParameters(List<string> i_BaseParameters)
        {
            string modelName = i_BaseParameters[0];
            string manufacturer = i_BaseParameters[1];

            if (!float.TryParse(i_BaseParameters[2], out float airPressure))
            {
                throw new FormatException("Air pressure must be a valid number.");
            }

            m_modelName = modelName;
            foreach (Tyre tyre in m_tyresCollection)
            {
                tyre.ManufacturerName = manufacturer;
                tyre.CurrentAirPressure = airPressure;
            }
        }

        public abstract List<string> GetSpecialPrameters();
        public abstract void SetSpecialParameters(List<string> i_Parameters);
        public override string ToString()
        {
            string vehileDetails ="Model name: " + m_modelName + "" + "Liecense Plate Number: " + m_licensePlateNumber + " " + "remain energy precentages: " + m_energyPercentages;

            return vehileDetails;
        }

    }
}

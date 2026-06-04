using System;
using System.Text;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlateNumber;
        protected float m_EnergyPercentages;
        protected Tyre[] m_TyresCollection;

        public Vehicle(string i_LicensePlateNumber, string i_ModelName)
        {
            m_ModelName = i_ModelName;
            m_LicensePlateNumber = i_LicensePlateNumber;
            m_EnergyPercentages = 100;
            m_TyresCollection = null;
        }
        public Tyre[] GetTyresColaction()
        {
            return m_TyresCollection;
        }

        public abstract float MaxEnergyCapacity 
        {
            get;
        }

        public string GetVehicleLicensePlateNumber()
        {
            return m_LicensePlateNumber;
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
            foreach (Tyre tyre in m_TyresCollection)
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

            m_ModelName = modelName;
            foreach (Tyre tyre in m_TyresCollection)
            {
                tyre.ManufacturerName = manufacturer;
                tyre.CurrentAirPressure = airPressure;
            }
        }

        public abstract List<string> GetSpecialParameters();

        public abstract void SetSpecialParameters(List<string> i_Parameters);

        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.AppendLine(string.Format("License Plate: {0}", m_LicensePlateNumber));
            vehicleDetails.AppendLine(string.Format("Model Name: {0}", m_ModelName));
            vehicleDetails.Append(string.Format("Energy Percentage: {0}%", (int)m_EnergyPercentages));

            return vehicleDetails.ToString();
        }
    }
}

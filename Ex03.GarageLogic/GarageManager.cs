using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, GarageVehicle> m_VehiclesInGarage = new Dictionary<string, GarageVehicle>();


        public bool CheckIfVehicleInGarage(string i_LicensePlateNumber)
        {
            bool vehicleIsInGarage = m_VehiclesInGarage.ContainsKey(i_LicensePlateNumber);

            if (vehicleIsInGarage)
            {
                m_VehiclesInGarage[i_LicensePlateNumber].SetVehicleStatus(eGarageStatus.InRepair);
            }

            return vehicleIsInGarage;
        }

        public void AddVehicle(string i_VehicleType, string i_LicensePlateNumber, string i_ModelName, string i_OwnerName, string i_OwnerPhone)
        {
            Vehicle newVehicle = VehicleCreator.CreateVehicle(i_VehicleType, i_LicensePlateNumber, i_ModelName);
            GarageVehicle newVehicleInGarage = new GarageVehicle(newVehicle, i_OwnerName, i_OwnerPhone);
            m_VehiclesInGarage.Add(i_LicensePlateNumber, newVehicleInGarage);
        }

        public List<string> GetVehicleParameters(string i_VehicleType)
        {
            Vehicle currentVehicle = VehicleCreator.CreateVehicle(i_VehicleType, null, null);
            Type vehicleType = currentVehicle.GetType();

            if (vehicleType.IsSubclassOf(typeof(Vehicle)))
            {
                //get parameters from user (after knowing which parameters)
            }
            else
            {
                throw new ArgumentException("You entered an invalid vehicle type");
            }
        }

        public void ChangeStateOfGarageVehicle(string i_LicensePlateNumber, eGarageStatus i_NewGarageState)
        {
            GarageVehicle currentGarageVehicle = getVehicleByLicensePlateNumber(i_LicensePlateNumber);
            currentGarageVehicle.SetVehicleStatus(i_NewGarageState);
        }

        public void RefuelVehicle(string i_LicensePlateNumber, eFuelType i_FuelType, float i_AmountOfFuelToAdd)
        {
            GarageVehicle currentGarageVehicle = getVehicleByLicensePlateNumber(i_LicensePlateNumber);
            Vehicle currentVehicle = currentGarageVehicle.GetVehicle();
            currentVehicle.Refuel(i_AmountOfFuelToAdd, i_FuelType);
        }

        public void ChargeVehicle(string i_LicensePlateNumber, float i_AmountOfMinutesToAdd)
        {
            GarageVehicle currentGarageVehicle = getVehicleByLicensePlateNumber(i_LicensePlateNumber);
            Vehicle currentVehicle = currentGarageVehicle.GetVehicle();
            currentVehicle.Charge(i_AmountOfMinutesToAdd);
        }

        private GarageVehicle getVehicleByLicensePlateNumber(string i_LicensePlateNumber)
        {
            if(!m_VehiclesInGarage.TryGetValue(i_LicensePlateNumber, out GarageVehicle desiredGarageVehicle))
            {
                throw new ArgumentException($"Vehicle with license number {i_LicensePlateNumber} was not found in the garage");
            }

            return desiredGarageVehicle;
        }
    }
}

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
    }
}

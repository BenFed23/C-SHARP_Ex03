using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, GarageVehicle> m_VehiclesInGarage = new Dictionary<string, GarageVehicle>();

        public void AddVehicle(string i_VehicleType, string i_LicenseNumber, string i_ModelName, string i_OwnerName, string i_OwnerPhone)
        {
            if(m_VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                m_VehiclesInGarage[i_LicenseNumber].SetVehicleStatus(eGarageStatus.InRepair);
                throw new ArgumentException($"Vehicle with license number {i_LicenseNumber} is already in Garage, changing status to 'In Repair'");
            }

            Vehicle newVehicle = VehicleCreator.CreateVehicle(i_VehicleType, i_LicenseNumber, i_ModelName);

            GarageVehicle newVehicleInGarage = new GarageVehicle(newVehicle, i_OwnerName, i_OwnerPhone);

            m_VehiclesInGarage.Add(i_LicenseNumber, newVehicleInGarage);
        }
    }
}

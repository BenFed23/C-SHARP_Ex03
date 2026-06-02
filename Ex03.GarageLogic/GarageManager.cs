using System;
using System.Collections.Generic;
using System.IO;

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

        public void AddVehicleToGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            GarageVehicle newVehicleInGarage = new GarageVehicle(i_Vehicle, i_OwnerName, i_OwnerPhone);
            m_VehiclesInGarage.Add(i_Vehicle.getVehicleLicensePlateNumber(), newVehicleInGarage);
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
        public void FillAirInVehicleTyresToMax(string i_LicensePlateNumber)
        {
            Tyre [] currentVehicleTyres = m_VehiclesInGarage[i_LicensePlateNumber].GetVehicle().GetTyresColaction();
            
            foreach ( Tyre tyre in currentVehicleTyres ) 
            {
                tyre.InflateTire(tyre.MaxAirPressure - tyre.CurrentAirPressure);
            }

           
        }


        private GarageVehicle getVehicleByLicensePlateNumber(string i_LicensePlateNumber)
        {
            if(!m_VehiclesInGarage.TryGetValue(i_LicensePlateNumber, out GarageVehicle desiredGarageVehicle))
            {
                throw new ArgumentException($"Vehicle with license number {i_LicensePlateNumber} was not found in the garage");
            }

            return desiredGarageVehicle;
        }

        public string[] loadVehicleDataBase()
        {
            try
            {
                string[] lines = File.ReadAllLines("VehiclesDB.txt");
                return lines;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Doesn't exist");
                return new string[0];
            }
            catch (IOException) 
            {
                Console.WriteLine("An Eror Occurred while opening the file");
                return new string[0];
            }
           
        }
        public Dictionary<string, GarageVehicle>  GetDictionary() 
        {

            return m_VehiclesInGarage;
        }
    }
}

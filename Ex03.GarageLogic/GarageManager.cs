using System;
using System.Collections.Generic;
using System.IO;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, GarageVehicle> m_VehiclesInGarage = new Dictionary<string, GarageVehicle>();

        public void AddVehicle(string i_VehicleType, string i_LicenseNumber, string i_ModelName, string i_OwnerName, string i_OwnerPhone)
        {
            if(m_VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                //Exception
            }

            Vehicle newVehicle = VehicleCreator.CreateVehicle(i_VehicleType, i_LicenseNumber, i_ModelName);

            GarageVehicle newVehicleInGarage = new GarageVehicle(newVehicle, i_OwnerName, i_OwnerPhone);

            m_VehiclesInGarage.Add(i_LicenseNumber, newVehicleInGarage);
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

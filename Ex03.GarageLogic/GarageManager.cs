using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private const int k_CarType = 0;
        private const int k_LicensePlate = 1;
        private const int k_ModelName = 2;
        private const int k_OwnerName = 6;
        private const int k_OwnerPhone = 7;

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
            Tyre[] currentVehicleTyres = m_VehiclesInGarage[i_LicensePlateNumber].GetVehicle().GetTyresColaction();

            foreach (Tyre tyre in currentVehicleTyres)
            {
                tyre.InflateTire(tyre.MaxAirPressure - tyre.CurrentAirPressure);
            }
        }

        private GarageVehicle getVehicleByLicensePlateNumber(string i_LicensePlateNumber)
        {
            if (!m_VehiclesInGarage.TryGetValue(i_LicensePlateNumber, out GarageVehicle desiredGarageVehicle))
            {
                throw new ArgumentException($"Vehicle with license number {i_LicensePlateNumber} was not found in the garage");
            }

            return desiredGarageVehicle;
        }

        public void loadVehicleDataBase()
        {
            try
            {
                string[] lines = File.ReadAllLines("VehiclesDB.txt");
                foreach (string line in lines)
                {
                    string[] details = line.Split(',');
                    parseVehicleData(details, out string type, out string license, out string model,
                             out string energyPercentStr, out string tyreManuf, out string air,
                             out string ownerName, out string ownerPhone);
                    Vehicle v = VehicleCreator.CreateVehicle(type, license, model);
                    v.SetTyreDetails(tyreManuf, float.Parse(air));
                    float energyPercent = float.Parse(energyPercentStr);
                    float actualEnergyAmount = calculateActualEnergyAmount(v, energyPercent);
                    List<string> specialParameters = extractSpecialParameters(details, 8, actualEnergyAmount.ToString());
                    v.SetSpecialParameters(specialParameters);
                    AddVehicleToGarage(v, ownerName, ownerPhone);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private float calculateActualEnergyAmount(Vehicle i_Vehicle, float i_Percent)
        {
            float maxCapacity = i_Vehicle.MaxEnergyCapacity;

            return (i_Percent / 100f) * maxCapacity;
        }

        private void parseVehicleData(string[] i_FileData, out string o_VehicleType, out string o_LicensePlate, out string o_ModelName,
                              out string o_EnergyPercentage, out string o_TyreModel, out string o_CurrAirPressure,
                              out string o_OwnerName, out string o_OwnerPhone)
        {
            o_VehicleType = i_FileData[0];
            o_LicensePlate = i_FileData[1];
            o_ModelName = i_FileData[2];
            o_EnergyPercentage = i_FileData[3];
            o_TyreModel = i_FileData[4];
            o_CurrAirPressure = i_FileData[5];
            o_OwnerName = i_FileData[6];
            o_OwnerPhone = i_FileData[7];
        }

        private List<string> extractSpecialParameters(string[] i_FileData, int i_StartIdx, string i_Energy)
        {
            List<string> specialParameters = new List<string>();
            for (int i = i_StartIdx; i < i_FileData.Length; i++)
            {
                specialParameters.Add(i_FileData[i]);
            }
            specialParameters.Add(i_Energy);
            return specialParameters;
        }

        public Dictionary<string, GarageVehicle>  GetDictionary() 
        {
            return m_VehiclesInGarage;
        }
    }
}

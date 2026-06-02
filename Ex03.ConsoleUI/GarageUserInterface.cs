using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{

    public class GarageUserInterface
    {
       
        private GarageManager m_garageManager;

        public GarageUserInterface(GarageManager i_garageManager)
        {
            m_garageManager = i_garageManager;
        }
        public void DisplayGarageMenu()
        {
            bool isExitPressed = false;

            while(!isExitPressed)
            {
                printMenuOptions();
                string userChoiceInput = Console.ReadLine();

                try
                {
                    if (!Enum.TryParse(userChoiceInput, out eMenuOptions userChoice))
                    {
                        throw new FormatException("You must choose a number from menu");
                    }

                    executeUserChoice(userChoice, ref isExitPressed);
                }
                catch (FormatException invalidInputException)
                {
                    Console.WriteLine("Invalid Input: {0}", invalidInputException.Message);
                }
                catch (ValueRangeException invalidRangeException)
                {
                    Console.WriteLine("Invalid Range: {0}", invalidRangeException.Message);
                }
            }
        }

        private void printMenuOptions()
        {
            string menuTemplate = @"*** Welcome to the Garage Management System ***
            Please choose one of the following options:
            {0}. Load vehicle data from file
            {1}. Add a new vehicle to the garage
            {2}. Display license numbers of vehicles in the garage
            {3}. Change a vehicle's status in garage
            {4}. Inflate tires to maximum air pressure
            {5}. Refuel a fuel-powered vehicle
            {6}. Charge an electric vehicle
            {7}. Display full vehicle information
            {8}. Exit

            Enter your choice: ";

            string formattedMenu = string.Format(
                menuTemplate,
                (int)eMenuOptions.LoadDataFromDBFile,
                (int)eMenuOptions.AddNewVehicleToGarage, 
                (int)eMenuOptions.ShowListOfLicensePlateNumbers,
                (int)eMenuOptions.ChangeVehicleStateInGarage,
                (int)eMenuOptions.InflateTiresToMaxAirPressure,
                (int)eMenuOptions.RefuelVehicle,
                (int)eMenuOptions.ChargeVehicle,
                (int)eMenuOptions.ShowFullVehicleDetails,
                (int)eMenuOptions.Exit
            );

            Console.Write(formattedMenu);
        }

        private void executeUserChoice(eMenuOptions i_UserMenuChoice, ref bool io_IsExitPressed)
        {
            switch(i_UserMenuChoice)
            {
                case eMenuOptions.LoadDataFromDBFile:
                    break;
                case eMenuOptions.AddNewVehicleToGarage:
                    break;
                case eMenuOptions.ShowListOfLicensePlateNumbers:
                    break;
                case eMenuOptions.ChangeVehicleStateInGarage:
                    executeChangeVehicleState();
                    break;
                case eMenuOptions.InflateTiresToMaxAirPressure:
                    break;
                case eMenuOptions.RefuelVehicle:
                    executeRefuelOption();
                    break;
                case eMenuOptions.ChargeVehicle:
                    executeChargeOption();
                    break;
                case eMenuOptions.ShowFullVehicleDetails:
                    break;
                case eMenuOptions.Exit:
                    io_IsExitPressed = true;
                    break;
            }
        }

        private void executeChangeVehicleState()
        {
            getChangeStateValuesFromUser(out string vehicleLicenseNumber, out string newVehicleState);
            Enum.TryParse(newVehicleState, out eGarageStatus newGarageVehicleStatus);
            m_garageManager.ChangeStateOfGarageVehicle(vehicleLicenseNumber, newGarageVehicleStatus);
        }

        private void getChangeStateValuesFromUser(out string o_VehicleLicenseNumber, out string o_NewVehicleState)
        {
            Console.WriteLine("Please enter license plate number:");
            o_VehicleLicenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter new vehicle state:");
            o_NewVehicleState = Console.ReadLine();
        }

        private void executeRefuelOption()
        {
            getRefuelValuesFromUser(out string vehicleLicenseNumber, out string stringFuelType, out string stringAmountOfFuelToAdd);
            Enum.TryParse(stringFuelType, out eFuelType fuelType);
            float.TryParse(stringAmountOfFuelToAdd, out float amountOfFuelToAdd);
            m_garageManager.RefuelVehicle(vehicleLicenseNumber, fuelType, amountOfFuelToAdd);
        }

        private void executeChargeOption()
        {
            getChargeValuesFromUser(out string vehicleLicenseNumber, out string stringAmountOfMinutesToAdd);
            float.TryParse(stringAmountOfMinutesToAdd, out float amountOfMinutesToAdd);
            m_garageManager.ChargeVehicle(vehicleLicenseNumber, amountOfMinutesToAdd);
        }

        private void getChargeValuesFromUser(out string o_VehicleLicenseNumber, out string o_AmountOfMinutesToAdd)
        {
            Console.WriteLine("Please enter license plate number:");
            o_VehicleLicenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter amount of minutes to add:");
            o_AmountOfMinutesToAdd = Console.ReadLine();
        }

        private void getRefuelValuesFromUser(out string o_VehicleLicenseNumber, out string o_FuelType, out string o_AmountOfFuelToAdd)
        {
            Console.WriteLine("Please enter license plate number:");
            o_VehicleLicenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter fuel type:");
            o_FuelType = Console.ReadLine();
            // add validate fuel type method
            Console.WriteLine("Please enter amount of fuel to add:");
            o_AmountOfFuelToAdd = Console.ReadLine();
        }

        private void getNewVehicleFromUser()
        {
            Console.WriteLine("Please enter the vehicle's license plate number");
            string userLicensePlateNumberInput = Console.ReadLine();

            if(m_garageManager.CheckIfVehicleInGarage(userLicensePlateNumberInput))
            {
                Console.WriteLine($"Vehicle with license plate number: {userLicensePlateNumberInput} is already in Garage. Updated status to 'In Repair'.");
            }
            else //second chance?
            {
                getVehicleDataFromUser();
            }
        }

        private void getVehicleDataFromUser()
        {
            Console.WriteLine("Please enter the vehicle's details:");
            Console.WriteLine("Enter vehicle type:");
            string userVehicleType = Console.ReadLine();
            if(!VehicleCreator.SupportedTypes.Contains(userVehicleType))
            {
                throw new ArgumentException($"The vehicle type '{userVehicleType}' is not supported");
            }

            getVehicleParamsAccordingToType(userVehicleType);
        }

        private Vehicle getVehicleParamsAccordingToType(string i_VehicleType)
        {
            List<string> currentVehicleParameters = GetVehicleParameters(i_VehicleType);

            foreach(string parameter in currentVehicleParameters)
            {
                Console.WriteLine($"please enter the vehicle's {parameter}");
                String assignedParameter = Console.ReadLine();
                //check if valid
                //create parameter
                // else Exception
            }

            //return vehicle 
            return null;
        }

        public List<string> GetVehicleParameters(string i_VehicleType)
        {
            Vehicle currentVehicle = VehicleCreator.CreateVehicle(i_VehicleType, null, null);
            Type vehicleType = currentVehicle.GetType();

            if (vehicleType.IsSubclassOf(typeof(Vehicle)))
            {
                return null;
            }
            else
            {
                throw new ArgumentException("You entered an invalid vehicle type");
            }
        }

        public void ShowPlateList()
        {
            Dictionary<string, GarageVehicle> garageDictionary = m_garageManager.GetDictionary();
            foreach (string plate in garageDictionary.Keys)
            {
                Console.WriteLine(plate);
            }
        }
        public void ShowPlateLisAcourdingToState(eGarageStatus i_carStatus)
        {
            List<string> carPlatesWithGivenState = new List<string>();
            Dictionary<string, GarageVehicle> garageDictionary = m_garageManager.GetDictionary();
            foreach (KeyValuePair<string, GarageVehicle> car in garageDictionary)
            {
                if (car.Value.GarageStatus == i_carStatus)
                {
                    carPlatesWithGivenState.Add(car.Key);
                }
            }
            PrintGivenList(carPlatesWithGivenState);
        }
        public void PrintGivenList(List<string> i_givenList)
        {
            foreach (string value in i_givenList)
            {
                Console.WriteLine(value);
            }
        }
        public void ShowVehiceleDetails(string i_licensePlate)
        {
            Console.WriteLine(m_garageManager.GetDictionary()[i_licensePlate].ToString());
        }
    }
}

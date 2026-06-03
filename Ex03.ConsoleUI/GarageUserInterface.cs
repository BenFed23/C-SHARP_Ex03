using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class GarageUserInterface
    {
        private GarageManager m_GarageManager;

        public GarageUserInterface(GarageManager i_garageManager)
        {
            m_GarageManager = i_garageManager;
        }

        public void DisplayGarageMenu()
        {
            bool isExitPressed = false;

            while (!isExitPressed)
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
1. Load vehicle data from file
2. Add a new vehicle to the garage
3. Display license numbers of vehicles in the garage
4. Change a vehicle's status in garage
5. Inflate tires to maximum air pressure
6. Refuel a fuel-powered vehicle
7. Charge an electric vehicle
8. Display full vehicle information
9. Exit

Enter your choice: ";

            Console.Write(menuTemplate);
        }
        private void executeUserChoice(eMenuOptions i_UserMenuChoice, ref bool io_IsExitPressed)
        {
            try
            {
                Console.Clear();

                switch (i_UserMenuChoice)
                {
                    case eMenuOptions.LoadDataFromDBFile:
                        loadDataBaseIntoGarageData();
                        break;
                    case eMenuOptions.AddNewVehicleToGarage:
                        executeAddNewVehicle();
                        break;
                    case eMenuOptions.ShowListOfLicensePlateNumbers:
                        ManageVehicleListPresentation();
                        break;
                    case eMenuOptions.ChangeVehicleStateInGarage:
                        executeChangeVehicleState();
                        break;
                    case eMenuOptions.InflateTiresToMaxAirPressure:
                        executeInflateTiresToMax();
                        break;
                    case eMenuOptions.RefuelVehicle:
                        executeRefuelOption();
                        break;
                    case eMenuOptions.ChargeVehicle:
                        executeChargeOption();
                        break;
                    case eMenuOptions.ShowFullVehicleDetails:
                        ShowVehiceleDetails();
                        break;
                    case eMenuOptions.Exit:
                        io_IsExitPressed = true;
                        break;
                }
            }
            catch (ValueRangeException valueRangeException)
            {
                Console.WriteLine(valueRangeException.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }

        private void executeInflateTiresToMax()
        {
            Console.WriteLine("Please enter the vehicle's license plate number:");
            string licensePlate = Console.ReadLine();

            try
            {
                m_GarageManager.FillAirInVehicleTyresToMax(licensePlate);
                Console.WriteLine("All tires have been inflated to their maximum air pressure successfully!");
            }
            catch(ArgumentException argumentException)
            {
                Console.WriteLine("Error: {0}", argumentException.Message);
            }
        }


        private void executeChangeVehicleState()
        {
            try
            {
                getChangeStateValuesFromUser(out string vehicleLicenseNumber, out string newVehicleState);
                Enum.TryParse(newVehicleState, out eGarageStatus newGarageVehicleStatus);
                m_GarageManager.ChangeStateOfGarageVehicle(vehicleLicenseNumber, newGarageVehicleStatus);
                Console.WriteLine($"Vehicle status changed to {newGarageVehicleStatus} successfully!");
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine($"Error: {argumentException.Message}");
            }
        }

        private void getChangeStateValuesFromUser(out string o_VehicleLicenseNumber, out string o_NewVehicleState)
        {
            Console.WriteLine("Please enter license plate number:");
            o_VehicleLicenseNumber = Console.ReadLine();
            string stateOptions = string.Join(", ", Enum.GetNames(typeof(eGarageStatus)));
            Console.WriteLine("Please enter new vehicle state ({0}):", stateOptions);
            o_NewVehicleState = Console.ReadLine();
        }

        private void executeRefuelOption()
        {
            try
            {
                getRefuelValuesFromUser(out string vehicleLicenseNumber, out string stringFuelType, out string stringAmountOfFuelToAdd);
                Enum.TryParse(stringFuelType, out eFuelType fuelType);
                float.TryParse(stringAmountOfFuelToAdd, out float amountOfFuelToAdd);
                m_GarageManager.RefuelVehicle(vehicleLicenseNumber, fuelType, amountOfFuelToAdd);
                Console.WriteLine($"Added {amountOfFuelToAdd} amount of fuel");
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine($"Error: {argumentException.Message}");
            }
        }

        private void executeChargeOption()
        {
            try
            {
                getChargeValuesFromUser(out string vehicleLicenseNumber, out string stringAmountOfMinutesToAdd);
                float.TryParse(stringAmountOfMinutesToAdd, out float amountOfMinutesToAdd);
                m_GarageManager.ChargeVehicle(vehicleLicenseNumber, amountOfMinutesToAdd);
                Console.WriteLine($"Charged {amountOfMinutesToAdd} Minutes");
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine($"Error: {argumentException.Message}");
            }
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
            string fuelOptions = string.Join(", ", Enum.GetNames(typeof(eFuelType)));
            Console.WriteLine("Please enter fuel type ({0}):", fuelOptions);
            o_FuelType = Console.ReadLine();
            Console.WriteLine("Please enter amount of fuel to add:");
            o_AmountOfFuelToAdd = Console.ReadLine();
        }

        private void executeAddNewVehicle()
        {
            try
            {
                getNewVehicleFromUser();
                Console.WriteLine("Vehicle added to garage successfully!");
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine($"Error: {argumentException.Message}");
            }
        }

        private void getNewVehicleFromUser()
        {
            Console.WriteLine("Please enter the vehicle's license plate number");
            string userLicensePlateNumberInput = Console.ReadLine();

            if (m_GarageManager.CheckIfVehicleInGarage(userLicensePlateNumberInput))
            {
                Console.WriteLine($"Vehicle with license plate number: {userLicensePlateNumberInput} is already in Garage. Updated status to 'In Repair'.");
            }
            else
            {
                getVehicleDataFromUser(userLicensePlateNumberInput);
            }
        }

        private void getVehicleDataFromUser(string i_LicensePlateNumber)
        {
            string vehicleType = getValidatedVehicleType();
            Vehicle newVehicle = VehicleCreator.CreateVehicle(vehicleType, i_LicensePlateNumber, string.Empty);
            List<string> baseParameters = newVehicle.GetBaseVehicleParameters();
            List<string> baseUserAnswers = getVehicleParametersFromUser(baseParameters);
            newVehicle.SetBaseVehicleParameters(baseUserAnswers);
            List<string> specialParameters = newVehicle.GetSpecialPrameters(); 
            List<string> specialUserAnswers = getVehicleParametersFromUser(specialParameters);
            newVehicle.SetSpecialParameters(specialUserAnswers);
            getOwnerDetails(out string ownerName, out string ownerPhone);
            m_GarageManager.AddVehicleToGarage(newVehicle, ownerName, ownerPhone);
        }

        private string getValidatedVehicleType()
        {
            Console.WriteLine("Enter vehicle type ({0}):", string.Join(", ", VehicleCreator.SupportedTypes));
            string userVehicleType = Console.ReadLine();
            if (!VehicleCreator.SupportedTypes.Contains(userVehicleType))
            {
                throw new ArgumentException($"The vehicle type '{userVehicleType}' is not supported.");
            }

            return userVehicleType;
        }

        private List<string> getVehicleParametersFromUser(List<string> i_Questions)
        {
            List<string> userAnswers = new List<string>();

            foreach (string question in i_Questions)
            {
                Console.WriteLine($"Please enter {question}:");
                userAnswers.Add(Console.ReadLine());
            }

            return userAnswers;
        }

        private void getOwnerDetails(out string o_OwnerName, out string o_OwnerPhone)
        {
            Console.WriteLine("Please enter owner's name:");
            o_OwnerName = Console.ReadLine();

            Console.WriteLine("Please enter owner's phone number:");
            o_OwnerPhone = Console.ReadLine();
        }  
        
        public void ShowPlateList()
        {
            Dictionary<string, GarageVehicle> garageDictionary = m_GarageManager.GetDictionary();
            foreach (string plate in garageDictionary.Keys)
            {
                Console.WriteLine(plate);
            }
        }

        public void ShowPlateLicenseAccordingToState(eGarageStatus i_carStatus)
        {
            List<string> carPlatesWithGivenState = new List<string>();
            Dictionary<string, GarageVehicle> garageDictionary = m_GarageManager.GetDictionary();
            foreach (KeyValuePair<string, GarageVehicle> car in garageDictionary)
            {
                if (car.Value.GetVehicleStatus() == i_carStatus)
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

        public void ShowVehiceleDetails()
        {
            Console.WriteLine("Enter a liecense plate number");
            string licensePlate = Console.ReadLine();
            try
            {
                Console.WriteLine(m_GarageManager.GetDictionary()[licensePlate].ToString());
            }
            catch (KeyNotFoundException)

            {
                Console.WriteLine("The Liecense Plate is not in the System.");
            }
        }
           
        public void loadDataBaseIntoGarageData()
        {
            m_GarageManager.loadVehicleDataBase();
            Console.Clear();
            Console.WriteLine(m_GarageManager.GetDictionary().Count.ToString() + " " + "Vehicles" + " " + "were loaded to the System ");
        }

        public void ManageVehicleListPresentation() 
        {
            Console.Clear();
            Console.WriteLine("choose 0 to see full list or 1 to see the filtered list ");
            int userChoise = int.Parse(Console.ReadLine());
            switch (userChoise)
            {
                case (int) eFillterUserChoice.All:
                    Console.Clear();
                    ShowPlateList();
                    break;
                case (int)eFillterUserChoice.FilterByVehicileState:
                    Console.WriteLine("Write the car state to filter by: InRepair, Repaired, FullyPayed");
                    if (Enum.TryParse(Console.ReadLine(), out eGarageStatus statusFilter))
                    {
                        Console.Clear() ;
                        ShowPlateLicenseAccordingToState(statusFilter);
                    }
                    else
                    {
                        Console.WriteLine("Invalid state entered.");
                    }
                    break;
            }
        }      
    }
}

using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class GarageUserInterface
    {
        private GarageLogic.GarageManager garageManager;

        public void GarageMenu()
        {

        }

        private void getNewVehicleFromUser()
        {
            Console.WriteLine("Please enter the vehicle's license plate number");
            string userLicensePlateNumberInput = Console.ReadLine();

            if(garageManager.CheckIfVehicleInGarage(userLicensePlateNumberInput))
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
            List<string> currentVehicleParameters = garageManager.GetVehicleParameters(i_VehicleType);

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
    }
}

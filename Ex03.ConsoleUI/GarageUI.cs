
using Ex03.GarageLogic;
using System;
using System.Collections.Generic;


namespace Ex03.ConsoleUI
{
    internal class GarageUI
    {
        GarageManager m_garageManager;
        public GarageUI(GarageManager i_garageManager)
        {
            m_garageManager = i_garageManager;
        }
        public void  ShowPlateList()
        {
            Dictionary<string, GarageVehicle> garageDictionary = m_garageManager.GetDictionary();
            foreach(string plate in garageDictionary.Keys) 
            {
                Console.WriteLine(plate);
            }
        }
        public void ShowPlateLisAcourdingToState(eGarageStatus i_carStatus) 
        {
            List<string> carPlatesWithGivenState = new List<string>();
            Dictionary<string, GarageVehicle> garageDictionary = m_garageManager.GetDictionary();
            foreach (KeyValuePair< string, GarageVehicle > car  in garageDictionary)
            {
                if(car.Value.GarageStatus == i_carStatus)
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
    }
}

using System;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        public static void Main() 
        {
            Ex03.GarageLogic.GarageManager garageManager = new Ex03.GarageLogic.GarageManager();
            GarageUserInterface userInterface = new GarageUserInterface(garageManager);
            userInterface.DisplayGarageMenu();
        }
    }
}

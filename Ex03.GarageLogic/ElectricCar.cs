using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricCar: Car
    {
        protected ElectricSource m_ElectricSource;
        public ElectricCar(string i_idPlate, string i_ModelName): base( i_idPlate, i_ModelName)
        {
            m_ElectricSource = new ElectricSource(4.6f);
        }

        public override void Charge(float i_AmountOfMinutesToCharge)
        {
            m_ElectricSource.chargeElectricVehicle(i_AmountOfMinutesToCharge / 60f);
            m_energyPercentages = (m_ElectricSource.FuelAmount / m_ElectricSource.MaxFuelCapacity) * 100;
        }
        public override List<string> GetSpecialPrameters() 
        {
            List<string> specialParametes = new List<string>();
            specialParametes.Add("eCarColor carColor");
            specialParametes.Add("enumOfDors numOfDors");

            return specialParametes;
        }
    }
}

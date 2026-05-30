using System;


namespace Ex03.GarageLogic
{
    internal class ElectricCar: Car
    {
        protected ElectricSource m_ElectricSource;
        public ElectricCar(string i_idPlate, string i_ModelName)
        {

        }

        public override void Charge(float i_AmountOfMinutesToCharge)
        {
            m_ElectricSource.chargeElectricVehicle(i_AmountOfMinutesToCharge / 60f);
        }
    }
}

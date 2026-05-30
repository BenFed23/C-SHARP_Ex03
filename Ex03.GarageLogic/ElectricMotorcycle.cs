using System;
using System.Runtime.InteropServices;


namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle: Motorcycle
    {
        protected ElectricSource m_ElectricSource;

        public ElectricMotorcycle(string i_LicensePlateNumber, string i_ModelName): base(i_LicensePlateNumber, i_ModelName)
        {

        }

        public override void Charge(float i_AmountOfMinutesToCharge)
        {
            m_ElectricSource.chargeElectricVehicle(i_AmountOfMinutesToCharge / 60f);
        }
    }
}

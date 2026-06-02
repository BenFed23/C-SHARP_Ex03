using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle: Motorcycle
    {
        protected ElectricSource m_ElectricSource;

        public ElectricMotorcycle(string i_LicensePlateNumber, string i_ModelName): base(i_LicensePlateNumber, i_ModelName)
        {
            m_ElectricSource = new ElectricSource(3.0f);
        }

        public override void Charge(float i_AmountOfMinutesToCharge)
        {
            m_ElectricSource.chargeElectricVehicle(i_AmountOfMinutesToCharge / 60f);
        }
        public override List<string> GetSpecialPrameters() 
        {
            List<string> specialParameters = new List<string>();
            specialParameters.Add("eLiecenseType liecenseType");
            specialParameters.Add("float volum");

            return specialParameters;
        }
        public override string ToString()
        {
           string  details = base.ToString();
           details += m_ElectricSource.ToString();

            return details;
        }
    }
}

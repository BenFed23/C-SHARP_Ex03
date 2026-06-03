using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageVehicle
    {
        protected readonly Vehicle r_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eGarageStatus m_VehicleStatus;

        public GarageVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            r_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
            m_VehicleStatus = eGarageStatus.InRepair;
        }

        public void SetVehicleStatus(eGarageStatus i_NewVehicleStatus)
        {
            m_VehicleStatus = i_NewVehicleStatus;
        }

        public Vehicle GetVehicle()
        {
           return r_Vehicle;
        }

        public eGarageStatus GetVehicleStatus()
        {
            return m_VehicleStatus;
        }

        public override string ToString()
        {
            StringBuilder garageVehicleDetails = new StringBuilder();

            garageVehicleDetails.AppendLine("*** Garage Management Information ***");
            garageVehicleDetails.AppendLine(string.Format("Owner Name: {0}", m_OwnerName));
            garageVehicleDetails.AppendLine(string.Format("Owner Phone: {0}", m_OwnerPhone));
            garageVehicleDetails.AppendLine(string.Format("Vehicle Status: {0}", m_VehicleStatus));
            garageVehicleDetails.AppendLine();

            garageVehicleDetails.AppendLine("*** Technical Vehicle Details ***");
            garageVehicleDetails.Append(r_Vehicle.ToString());

            return garageVehicleDetails.ToString();
        }
    }
}

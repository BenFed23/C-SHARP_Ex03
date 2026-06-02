using System;   

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
            return r_Vehicle.ToString() + " " +  m_OwnerName + " " + m_VehicleStatus.ToString();
        }
    }
}

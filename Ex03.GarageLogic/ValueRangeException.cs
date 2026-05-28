using System;

namespace Ex03.GarageLogic
{
    public class ValueRangeException : Exception
    {
        public float m_MaxValue {  get; set; }
        public float m_MinValue { get; set; }

        public ValueRangeException(float i_MinValue, float i_MaxValue, string i_Message = null)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}

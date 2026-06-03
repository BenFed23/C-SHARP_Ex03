using System;

namespace Ex03.GarageLogic
{
    public class ValueRangeException : Exception
    {
        public float m_MaxValue {  get; set; }
        public float m_MinValue { get; set; }

        public ValueRangeException(float i_MinValue, float i_MaxValue, string i_Message = null) : base(getMessage(i_MinValue,i_MaxValue,i_Message))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        private static string getMessage(float i_MinValue, float i_MaxValue, string i_Message)
        {
            string messageToReturn;

            if(i_Message != null)
            {
                messageToReturn = i_Message;
            }
            else
            {
                messageToReturn = string.Format("Value out of range. Expected Value: {0} - {1}", i_MinValue, i_MaxValue);
            }

            return messageToReturn;
        }
    }
}

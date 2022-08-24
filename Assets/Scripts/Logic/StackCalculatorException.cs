using System;

namespace Logic
{
    public class CalculatorException : ApplicationException
    {
        public CalculatorException()
        {
        }

        public CalculatorException(string message) : base(message)
        {
        }

        public CalculatorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
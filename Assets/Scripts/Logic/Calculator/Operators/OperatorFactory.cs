using System;

namespace Logic.Calculator.Operators
{
    public static class OperatorFactory
    {
        public static IOperation GetOperation(OperatorType operatorType)
        {
            return operatorType switch
            {
                OperatorType.ADD => new OperationAdd(),
                OperatorType.SUB => new OperationSubtract(),
                OperatorType.MUL => new OperationMultiply(),
                OperatorType.DIV => new OperationDivide(),
                _ => throw new NotImplementedException("Operation not supported")
            };
        }
    }
}
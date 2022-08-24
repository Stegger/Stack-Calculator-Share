namespace Logic.Calculator.Operators
{
    public class OperationSubtract : IOperation
    {
        public double Operate(double left, double right)
        {
            return left - right;
        }
    }
}
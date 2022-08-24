namespace Logic.Calculator.Operators
{
    public class OperationMultiply : IOperation
    {
        public double Operate(double left, double right)
        {
            return left * right;
        }
    }
}
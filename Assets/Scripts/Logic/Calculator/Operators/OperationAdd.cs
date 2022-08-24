namespace Logic.Calculator.Operators
{
    public class OperationAdd : IOperation
    {
        public double Operate(double left, double right)
        {
            return left + right;
        }
    }
}
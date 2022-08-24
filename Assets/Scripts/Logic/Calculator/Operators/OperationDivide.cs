namespace Logic.Calculator.Operators
{
    public class OperationDivide : IOperation
    {
        public double Operate(double left, double right)
        {
            if (right == 0)
                throw new CalculatorException("Can't divide by zero");

            return left / right;
        }
    }
}
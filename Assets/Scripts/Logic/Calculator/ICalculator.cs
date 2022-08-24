using Logic.Calculator.Operators;

namespace Logic.Calculator
{
    public interface ICalculator
    {
        public void Input(int value);

        public void Operate(OperatorType operatorType);

        public double Equals();

        public void Clear();
    }
}
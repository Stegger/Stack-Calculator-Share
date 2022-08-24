using System;
using System.Collections.Generic;
using Logic.Calculator.Operators;

namespace Logic.Calculator
{
    public class StackBasedCalculator : ICalculator
    {
        private Stack<double> _operands;

        public StackBasedCalculator()
        {
            Reset();
        }

        public void Operate(OperatorType operatorType)
        {
            if (_operands.Count <= 1)
                throw new CalculatorException("The expression needs more operands");

            IOperation operation = OperatorFactory.GetOperation(operatorType);
            double right = _operands.Pop();
            double left = _operands.Pop();
            try
            {
                _operands.Push(operation.Operate(left, right));
            }
            catch (Exception e)
            {
                _operands.Push(left);
                _operands.Push(right);
                throw new CalculatorException("Illegal operation: " + e.Message, e);
            }
        }

        public void Input(int value)
        {
            _operands.Push(value);
        }

        public double Equals()
        {
            if (_operands.Count == 1)
                return _operands.Peek();

            throw new CalculatorException("The expression needs more operators");
        }

        public void Clear()
        {
            Reset();
        }

        private void Reset()
        {
            _operands = new Stack<double>();
        }
    }
}
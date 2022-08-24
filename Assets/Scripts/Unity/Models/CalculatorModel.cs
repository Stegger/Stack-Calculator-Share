using System.Text;
using Logic.Calculator;
using Logic.Calculator.Operators;

namespace Unity.Models
{
    public class CalculatorModel
    {
        private ICalculator _calculator;
        private StringBuilder _stringBuilder;

        public CalculatorModel(ICalculator calculator)
        {
            _calculator = calculator;
            _stringBuilder = new StringBuilder();
        }

        /// <summary>
        /// Provides a string of entered expression in its current state
        /// </summary>
        /// <returns>String of the expression</returns>
        public string GetExpression()
        {
            return _stringBuilder.ToString();
        }

        /// <summary>
        /// Add an operand to the expression
        /// </summary>
        /// <param name="operand"></param>
        public void Input(int operand)
        {
            _calculator.Input(operand);
            _stringBuilder.Append(operand + " ");
        }

        /// <summary>
        /// Add an operator to the expression
        /// </summary>
        /// <param name="operatorType"></param>
        /// <param name="display"></param>
        public void Operator(OperatorType operatorType, string display)
        {
            _calculator.Operate(operatorType);
            _stringBuilder.Append(display + " ");
        }

        /// <summary>
        /// Calculates the current expression.
        /// </summary>
        public void Calculate()
        {
            double result = _calculator.Equals();
            _stringBuilder.Clear();
            _stringBuilder.Append(result + " ");
        }

        /// <summary>
        /// Clear the CalculatorModels state
        /// </summary>
        public void Clear()
        {
            _calculator.Clear();
            _stringBuilder.Clear();
        }
    }
}
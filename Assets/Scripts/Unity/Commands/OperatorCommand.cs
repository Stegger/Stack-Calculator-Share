using Logic.Calculator.Operators;
using Unity.Models;

namespace Unity.Commands
{
    public class OperatorCommand : ICommand
    {
        private CalculatorModel _model;
        private OperatorType _operatorType;
        private string _display;

        public OperatorCommand(CalculatorModel model, OperatorType operatorType, string display)
        {
            _model = model;
            _operatorType = operatorType;
            _display = display;
        }


        public void Execute()
        {
            _model.Operator(_operatorType, _display);
        }
    }
}
using Unity.Models;

namespace Unity.Commands
{
    public class AddOperandCommand : ICommand
    {
        private CalculatorModel _model;
        private int _value;

        public AddOperandCommand(CalculatorModel model, int value)
        {
            _value = value;
            _model = model;
        }

        public void Execute()
        {
            _model.Input(_value);
        }
    }
}
using Unity.Models;

namespace Unity.Commands
{
    public class CalculateCommand : ICommand
    {
        private CalculatorModel _model;

        public CalculateCommand(CalculatorModel model)
        {
            _model = model;
        }

        public void Execute()
        {
            _model.Calculate();
        }
    }
}
using Unity.Models;

namespace Unity.Commands
{
    public class ClearCommand : ICommand
    {
        private readonly CalculatorModel _model;

        public ClearCommand(CalculatorModel model)
        {
            _model = model;
        }

        public void Execute()
        {
            _model.Clear();
        }
    }
}
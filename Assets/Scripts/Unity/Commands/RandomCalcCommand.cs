using Logic.RandomGen;
using Unity.Models;

namespace Unity.Commands
{
    public class RandomCalcCommand : ICommand
    {
        private readonly IRandomProvider _randomProvider;
        private readonly CalculatorModel _calculatorModel;

        public RandomCalcCommand(IRandomProvider randomProvider, CalculatorModel calculatorModel)
        {
            _randomProvider = randomProvider;
            _calculatorModel = calculatorModel;
        }

        public void Execute()
        {
            _calculatorModel.Clear();
            _calculatorModel.Input(_randomProvider.GetRandomNumber());
        }
    }
}
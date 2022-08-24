using Logic;
using Logic.Calculator;
using Logic.Calculator.Operators;
using NUnit.Framework;

namespace Tests
{
    public class StackCalculatorTest
    {
        [Test]
        public void SimpleAdditionTest()
        {
            ICalculator target = new StackBasedCalculator();

            target.Input(1);
            target.Input(2);
            target.Operate(OperatorType.ADD);
            double actual = target.Equals();

            double expected = 3.0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SimpleSubtractTest()
        {
            ICalculator target = new StackBasedCalculator();

            target.Input(3);
            target.Input(2);
            target.Operate(OperatorType.SUB);
            double actual = target.Equals();

            double expected = 1.0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SimpleMultiplyTest()
        {
            ICalculator target = new StackBasedCalculator();

            target.Input(3);
            target.Input(2);
            target.Operate(OperatorType.MUL);
            double actual = target.Equals();

            double expected = 6.0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SimpleDivideTest()
        {
            ICalculator target = new StackBasedCalculator();

            target.Input(6);
            target.Input(2);
            target.Operate(OperatorType.DIV);
            double actual = target.Equals();

            double expected = 3.0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DivisionByZeroTest()
        {
            ICalculator target = new StackBasedCalculator();

            target.Input(6);
            target.Input(0);

            Assert.Throws<CalculatorException>(() =>
                target.Operate(OperatorType.DIV));
        }

        [Test]
        public void SimpleAdditionMultipleTest()
        {
            ICalculator target = new StackBasedCalculator();

            target.Input(1);
            target.Input(2);
            target.Input(3);
            target.Operate(OperatorType.ADD);
            target.Operate(OperatorType.ADD);
            double actual = target.Equals();

            double expected = 6.0;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void MultipleOperatorsTest()
        {
            ICalculator target = new StackBasedCalculator();

            target.Input(1);
            target.Input(2);
            target.Input(3);
            target.Operate(OperatorType.ADD);
            target.Input(4);
            target.Input(5);
            target.Operate(OperatorType.MUL);
            target.Operate(OperatorType.MUL);
            target.Operate(OperatorType.ADD);
            double actual = target.Equals();

            double expected = 101.0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SimpleAdditionUnderflowTest()
        {
            ICalculator target = new StackBasedCalculator();

            target.Input(1);
            target.Input(2);
            target.Input(3);
            target.Operate(OperatorType.ADD);

            Assert.Throws<CalculatorException>(() => target.Equals());
        }

        [Test]
        public void SimpleOverflowTest()
        {
            ICalculator target = new StackBasedCalculator();

            target.Input(1);
            target.Input(2);
            target.Operate(OperatorType.ADD);

            Assert.Throws<CalculatorException>(() => target.Operate(OperatorType.ADD));
        }
    }
}
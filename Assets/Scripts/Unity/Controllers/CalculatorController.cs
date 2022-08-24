using System;
using System.Collections.Generic;
using Logic.Calculator;
using Logic.Calculator.Operators;
using TMPro;
using Unity.Commands;
using Unity.Models;
using UnityEngine;

namespace Unity.Controllers
{
    public class CalculatorController : MonoBehaviour
    {
        public TMP_Text txtCalcOut;
        public int calcsBetweenRandom;
        public RandomController randomProvider;

        private CalculatorModel _model;
        private Stack<ICommand> _commands;
        private int _calcCount;

        private void Start()
        {
            _model = new CalculatorModel(new StackBasedCalculator());
            _commands = new Stack<ICommand>();
        }

        #region CommandHandling

        private void Invoke(ICommand command)
        {
            try
            {
                command.Execute();
                _commands.Push(command);
                txtCalcOut.text = _model.GetExpression();
            }
            catch (Exception e)
            {
                ErrorController.instance.DisplayErrorMessage(e.Message);
            }
        }

        public void Undo()
        {
            _commands.Pop();
            _model.Clear();
            ICommand[] tmp = _commands.ToArray();
            Array.Reverse(tmp);
            _commands = new Stack<ICommand>();
            foreach (ICommand command in tmp)
            {
                Invoke(command);
            }
        }

        #endregion

        #region EventHanling

        public void HandleClearAll()
        {
            ICommand command = new ClearCommand(_model);
            Invoke(command);
        }

        public void HandleOperandInput(int operand)
        {
            ICommand command = new AddOperandCommand(_model, operand);
            Invoke(command);
        }

        public void HandleCalculate()
        {
            _calcCount++;
            ICommand command = (_calcCount % calcsBetweenRandom == 0)
                ? new RandomCalcCommand(randomProvider, _model)
                : new CalculateCommand(_model);
            Invoke(command);
        }

        public void HandleOperatorInput(string operatorType)
        {
            ICommand command = operatorType switch
            {
                "+" => new OperatorCommand(_model, OperatorType.ADD, "+"),
                "-" => new OperatorCommand(_model, OperatorType.SUB, "-"),
                "*" => new OperatorCommand(_model, OperatorType.MUL, "*"),
                "/" => new OperatorCommand(_model, OperatorType.DIV, "/"),
                _ => null
            };
            if (command != null) Invoke(command);
        }

        #endregion
    }
}
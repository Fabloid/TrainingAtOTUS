using GuessTheNumber.Interfaces;
using GuessTheNumber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Presenters {
    public class ProgramPresenter : IWorkProgram {
        private IOutputInput _outputInput;
        public ProgramPresenter(IOutputInput outputInput) {
            _outputInput = outputInput;
            WorkProgram();
        }

        public void WorkProgram() {
            NumberGenerator generator = new();
            _outputInput.ShowMessage = $"Загадано число от {0} до {int.MaxValue}{Environment.NewLine}";
            int number;
            do {
                _outputInput.ShowMessage = "Введите число: ";
                number = _outputInput.GetEnterData.GetInt();
                Guesser guesser = new(generator.Number, number);
                _outputInput.ShowMessage = $"{guesser.Result} {Environment.NewLine}";
            } while (number != generator.Number);
            _outputInput.ShowMessage = $"Игра окончена {Environment.NewLine}";
        }
    }
}

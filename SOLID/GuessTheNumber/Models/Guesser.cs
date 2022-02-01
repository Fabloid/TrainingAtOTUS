using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Models {
    public class Guesser {
        private int _hiddenNumber;
        private int _enteredNumber;
        public Guesser(int hiddenNumber, int enteredNumber) {
            _hiddenNumber = hiddenNumber;
            _enteredNumber = enteredNumber;
        }

        public string Result { 
            get {
                if (_hiddenNumber == _enteredNumber) {
                    return "Победа";
                } else {
                    if (_hiddenNumber < _enteredNumber) {
                        return "Введенное число больше загаданного";
                    } else {
                        return "Введенное число меньше загаданного";
                    }
                }
            } 
        }
    }
}

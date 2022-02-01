using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Models {
    public class NewGuesser : Guesser {
        public NewGuesser(int hiddenNumber, int enteredNumber) : base(hiddenNumber, enteredNumber) {
        }

        public string Advice = ", попробуйте еще раз)";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Models {
    public class NumberGenerator {

        public int Number { get; init; }
        public NumberGenerator() {
            Random random = new();
            Number = random.Next(0, int.MaxValue);
        }
    }
}

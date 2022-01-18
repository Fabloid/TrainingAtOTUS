using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp9ConsoleApp {
    public partial /*NEW FEATURE 4*/record Calculator(double a, double b, ArithmeticOperations operation) {
        public /*NEW FEATURE 3*/partial string Calculate() {
            switch (operation) {
                case ArithmeticOperations.Addition: return $"{a} + {b} = {a + b}";
                case ArithmeticOperations.Subtraction: return $"{a} - {b} = {a - b}";
                case ArithmeticOperations.Multiplication: return $"{a} * {b} = {a * b}";
                case ArithmeticOperations.Division: return $"{a} / {b} = {a / b}";
                default: throw new MyException("Unknown operation.");
            }
        }
    }
}

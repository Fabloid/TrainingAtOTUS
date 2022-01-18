using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp9ConsoleApp {
    public static class Check {
        public static ArithmeticOperations CheckEnterOperation(char value) {
            switch (value) {
                case '+': return ArithmeticOperations.Addition;
                case '-': return ArithmeticOperations.Subtraction;
                case '*': return ArithmeticOperations.Multiplication;
                case '/': return ArithmeticOperations.Division;
                default: throw new MyException("Unknown operation.");
            }
        }

        public static bool ChechString(/*NEW FEATURE 2*/[NotNullWhen(returnValue: true)] this string str) {
            return !string.IsNullOrEmpty(value: str);
        }
    }
}

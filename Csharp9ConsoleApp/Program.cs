using System;

namespace Csharp9ConsoleApp {
    class Program {
        static void Main(string[] args) {
            /*NEW FEATURE 5*/_ = DateTime.Now;
            do {
                Console.Clear();
                try {
                    Console.Write("Введите первое целое число: ");
                    string strA = Console.ReadLine();
                    double a;
                    if (strA.ChechString()) {
                        a = Convert.ToDouble(strA);
                    } else {
                        throw new MyException("String = NULL");
                    }

                    Console.Write("Введите второе целое число: ");
                    string strB = Console.ReadLine();
                    double b;
                    if (strB.ChechString()) {
                        b = Convert.ToDouble(strB);
                    } else {
                        throw new MyException("String = NULL");
                    }

                    Console.Write("Операция (+, -, *, /): ");
                    ArithmeticOperations operation = Check.CheckEnterOperation(Console.ReadKey().KeyChar);
                    Calculator calculator = /*NEW FEATURE 1*/new(a, b, operation);

                    Console.WriteLine();
                    Console.WriteLine($"Ответ: {calculator.Calculate()}");
                } catch (Exception ex) {
                    Console.WriteLine();
                    Console.WriteLine($"Что-то пошло не так: {ex.Message}");
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

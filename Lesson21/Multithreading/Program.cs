using System;

namespace Multithreading {
    class Program {
        static void Main(string[] args) {
            int count = 0;
            do {
                try {
                    Console.Write("Введите колличество элементов массива, либо 0 для выхода: ");
                    count = Convert.ToInt32(Console.ReadLine());
                    Summator summator = new Summator(count);
                    Console.WriteLine($"Обычное суммирование {count} элементов за {summator.SumTime}мс. Сумму = {summator.Result}");
                    Console.WriteLine($"Параллельное суммирование {count} элементов за {summator.ThreadSumTime}мс. Сумму = {summator.Result}");
                    Console.WriteLine($"Параллельное с помощью LINQ суммирование {count} элементов за {summator.PLINQSumTime}мс. Сумму = {summator.Result}");
                } catch (Exception ex) {
                    Console.Write(ex.Message);
                }
            } while (count != 0);
        }
    }
}

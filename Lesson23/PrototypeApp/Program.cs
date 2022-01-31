using PrototypeApp.Models;
using System;

namespace PrototypeApp {
    class Program {
        static void Main(string[] args) {
            var car = new Car {
                Model = "BMW",
                Motor = 1800,
                CountDoors = 4
            };

            var carNew = car.Copy();

            Console.WriteLine("У клиентов совпадают значения полей, но разные ссылки: {0}", car.Equals(carNew) && !ReferenceEquals(car, carNew));
        }
    }
}

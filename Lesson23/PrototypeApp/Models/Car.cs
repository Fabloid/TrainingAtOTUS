using PrototypeApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp.Models {
    public class Car : Transport, IMyCloneable<Car> {
        public int CountDoors { get; set; }

        public override object Clone() {
            return Copy();
        }

        public Car Copy() {
            return new() {
                Model = Model,
                Motor = Motor,
                CountDoors = CountDoors
            };
        }

        public override string Information() {
            return $"Машина - {Model} с двигателем {Motor}, количество дверей - {CountDoors}";
        }


        public override bool Equals(object? o) {
            if (o is Car car and not null) {
                return car.Model == Model &&
                       car.Motor == Motor &&
                       car.CountDoors == CountDoors;
            }

            return false;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Model, Motor, CountDoors);
        }
    }
}

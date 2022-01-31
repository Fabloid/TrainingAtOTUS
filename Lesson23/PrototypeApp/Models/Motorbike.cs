using PrototypeApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp.Models {
    public class Motorbike : Transport, IMyCloneable<Motorbike> {
        public int CountWheels { get; set; }

        public override object Clone() {
            return Copy();
        }

        public Motorbike Copy() {
            return new() {
                Model = Model,
                Motor = Motor,
                CountWheels = CountWheels
            };
        }

        public override string Information() {
            return $"Мотоцикл - {Model} с двигателем {Motor}, количество колес - {CountWheels}";
        }

        public override bool Equals(object? o) {
            if (o is Motorbike motorbike and not null) {
                return motorbike.Model == Model &&
                       motorbike.Motor == Motor &&
                       motorbike.CountWheels == CountWheels;
            }

            return false;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Model, Motor, CountWheels);
        }
    }
}

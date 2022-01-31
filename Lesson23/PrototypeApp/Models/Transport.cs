using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp.Models {
    public abstract class Transport : ICloneable {
        public int Motor { get; set; }
        public string Model { get; set; }

        public abstract object Clone();
        public abstract string Information();
    }
}

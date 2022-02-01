using GuessTheNumber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Models {
    public class Junior : IEmployee {
        public string GetEmployeeDetails() {
            return "Мало опыта";
        }
    }
}

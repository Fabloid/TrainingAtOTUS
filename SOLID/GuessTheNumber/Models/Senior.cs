using GuessTheNumber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Models {
    public class Senior : IWork, IEmployee {
        public string GetEmployeeDetails() {
            return "Много опыта";
        }

        public string GetWorkDetails() {
            return "Информация о прошлых проектах";
        }
    }
}

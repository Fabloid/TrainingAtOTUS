using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Models {
    public static class Extensions {
        public static int GetInt(this string? value) {
            return Convert.ToInt32(value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsConsoleApp {
    public static class Extension {
        public static T GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter) where T : class {
            T max = default;
            foreach (var v in e) {
                var a = getParameter(max);
                var b = getParameter(v);
                max = a > b ? max : v;
            }
            return max;
        }
    }
}

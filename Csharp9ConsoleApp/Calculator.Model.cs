using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp9ConsoleApp {
    public partial record Calculator {
        public /*NEW FEATURE 3*/partial string Calculate();
    }
}

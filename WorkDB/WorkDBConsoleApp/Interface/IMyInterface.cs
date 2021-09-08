using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDBConsoleApp.Interface {
    public interface IMyInterface {
        string ShowMessage { set; }
        string GetEnterData { get; }
        void ClearWindow();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Interfaces {
    public interface IOutputInput {
        string ShowMessage { set; }
        string GetEnterData { get; }
    }
}

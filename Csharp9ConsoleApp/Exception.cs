using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp9ConsoleApp {
    public class MyException : Exception{
        public string _message;
        public override string Message { 
            get {
                return _message;
            } 
        }
        public MyException(string message) {
            _message = message;
        }
    }
}

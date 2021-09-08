using Data.Models;
using Data.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WorkDBConsoleApp.Interface;
using WorkDBConsoleApp.Presenter;

namespace WorkDBConsoleApp {
    class Program : IMyInterface {
        static void Main(string[] args) {
            ProgramPresenter presenter = new ProgramPresenter(new Program());
        }

        public void ClearWindow() {
            Console.Clear();
        }
        public string ShowMessage { set => Console.WriteLine(value); }

        public string GetEnterData => Console.ReadLine();
    }
}

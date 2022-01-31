using GuessTheNumber.Interfaces;
using GuessTheNumber.Presenters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GuessTheNumber {
    class Program : IOutputInput {
        public string ShowMessage { set => Console.Write(value); }

        public string GetEnterData => Console.ReadLine();

        static void Main(string[] args) {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IOutputInput, Program>()
                .AddSingleton<IWorkProgram, ProgramPresenter>()
                .BuildServiceProvider();
            var workProgram = serviceProvider.GetService<IWorkProgram>();
            workProgram.WorkProgram();
        }
    }
}

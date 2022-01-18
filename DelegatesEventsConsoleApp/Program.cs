using System;
using System.Collections.Generic;

namespace DelegatesEventsConsoleApp {
    class Program {
        private static readonly List<string> fileNames = new();
        private static void FileFound(object sender, FileArgs e) {
            fileNames.Add(e.FileName);
            Console.WriteLine(e.FileName);
        }

        static void Main(string[] args) {
            FileViewer fileViewer = new FileViewer("TestFolder");
            fileViewer.FileFound += FileFound;
            Console.WriteLine($"Самое длинное имя файла:{fileViewer.GetFiles().GetMax(s => string.IsNullOrEmpty(s) ? 0 : s.Length)}");
            Console.ReadLine();
        }
    }
}

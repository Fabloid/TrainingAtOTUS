﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsConsoleApp {
    public class FileArgs : EventArgs {
        public FileArgs(string fileName) {
            FileName = fileName;
        }
        public string FileName { get; private set; }

    }
}

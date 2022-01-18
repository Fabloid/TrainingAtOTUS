using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsConsoleApp {
    public class FileViewer {
        private string _directory;
        public FileViewer(string directory) {
            _directory = directory;
        }

        public event EventHandler<FileArgs> FileFound;

        public IEnumerable<string> GetFiles() {
            foreach (var file in Directory.GetFiles(_directory)) {
                FileFound?.Invoke(this, new FileArgs(file));
                yield return file;
            }
        }

    }
}

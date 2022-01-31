using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading {
    public class Summator {
        private int _length;
        private int[] _array;
        private Stopwatch _sp;

        public Summator(int length) {
            _length = length;
            Random random = new Random();
            _sp = new Stopwatch();
            _array = new int[_length];
            for (int i = 0; i < _length; i++) {
                _array[i] = random.Next(-10,10);
            }
        }

        private int Sum() {
            int sum = 0;
            foreach (var item in _array) {
                sum += item;
            }
            return sum;
        }

        private int ThreadSum(int threadCount) {
            int sum = 0;

            var count = _array.Length / threadCount;
            Task[] tasks = new Task[threadCount];
            for (int iThread = 0; iThread < threadCount; iThread++) {
                var localThread = iThread;
                tasks[localThread] = Task.Run(() => {
                    for (int j = localThread * count; j < (localThread + 1) * count; j++) {
                        Interlocked.Add(ref sum, _array[j]);
                    }
                });
            }

            Task.WaitAll(tasks);
            return sum;
        }

        private int PLINQSum() {
            return _array.AsParallel().Sum();
        }

        public int Result;

        public long SumTime {
            get {
                _sp.Reset();
                _sp.Start();
                Result = Sum();
                _sp.Stop();
                return _sp.ElapsedMilliseconds;
            }
        }

        public long ThreadSumTime {
            get {
                _sp.Reset();
                _sp.Start();
                Result = ThreadSum(4);
                _sp.Stop();
                return _sp.ElapsedMilliseconds;
            }
        }

        public long PLINQSumTime {
            get {
                _sp.Reset();
                _sp.Start();
                Result = PLINQSum();
                _sp.Stop();
                return _sp.ElapsedMilliseconds;
            }
        }
    }
}

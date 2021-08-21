using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace MySerializer {
    class Program {
        static void Main(string[] args) {
            TestClass testClass = new TestClass {
                i1 = 1,
                i2 = 2,
                i3 = 3,
                i4 = 4,
                i5 = 5
            };
            int iterations = 100000;

            Console.WriteLine("Время выполнения моей сериализации - " + MySerialization(testClass, iterations));
            Console.WriteLine("Время выполнения моей десериализации - " + MyDeserialization(testClass, iterations));
            Console.WriteLine();
            Console.WriteLine("Время выполнения Newtonsoft сериализации - " + NewtonsoftJsonSerialization(testClass, iterations));
            Console.WriteLine("Время выполнения Newtonsoft десериализации - " + NewtonsoftJsonDeserialization(testClass, iterations));
        }

        private static string MySerialization(TestClass testClass, int iterations) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++) {
                string csv = Serializer<TestClass>.Serialization(testClass);
            }
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            return string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
        }

        private static string MyDeserialization(TestClass testClass, int iterations) {
            string csv = Serializer<TestClass>.Serialization(testClass);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++) {
                TestClass deserializedClass = Serializer<TestClass>.Deserialization(csv);
            }
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            return string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
        }

        private static string NewtonsoftJsonSerialization(TestClass testClass, int iterations) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++) {
                string json = JsonConvert.SerializeObject(testClass);
            }
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            return string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
        }

        private static string NewtonsoftJsonDeserialization(TestClass testClass, int iterations) {
            string json = JsonConvert.SerializeObject(testClass);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++) {
                TestClass deserializedClass = JsonConvert.DeserializeObject<TestClass>(json);
            }
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            return string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
        }
    }

    public class TestClass {
        public int i1, i2, i3, i4, i5;
    }
}

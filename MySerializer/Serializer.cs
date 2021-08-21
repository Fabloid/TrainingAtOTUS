using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MySerializer {
    public static class Serializer<T> where T : new() {
        private const char Separator = ';';

        public static string Serialization(T obj) {
            var type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            FieldInfo[] fields = type.GetFields();


            var sb = new StringBuilder();
            var values = new List<string>();

            sb.AppendLine(GetHeader(properties, fields));

            foreach (var p in properties) {
                var raw = p.GetValue(obj);
                var value = raw == null ?
                    "" :
                    raw.ToString();
                values.Add(value);
            }

            foreach (var f in fields) {
                var raw = f.GetValue(obj);
                var value = raw == null ?
                    "" : raw.ToString();
                values.Add(value);
            }

            sb.AppendLine(string.Join(Separator.ToString(), values.ToArray()));

            return sb.ToString().Replace(Environment.NewLine, "`").Trim('`').Replace("`", Environment.NewLine);
        }

        private static string GetHeader(PropertyInfo[] _properties, FieldInfo[] _fields) {
            var properties = _properties.Select(a => a.Name).ToArray();
            var fields = _fields.Select(a => a.Name).ToArray();

            var header = string.Concat(properties.Any() ?
                string.Join(Separator.ToString(), properties) + ';' : string.Empty,
                fields.Any() ?
                string.Join(Separator.ToString(), fields) : string.Empty);
            return header;
        }

        public static T Deserialization(string csv) {
            List<string> csvLine = csv.Split(Environment.NewLine, StringSplitOptions.None).ToList();
            string[] columns = csvLine[0].Split(Separator);
            csvLine.RemoveAt(0);
            string[] rows = csvLine.ToArray();

            T data = new();

            var type = typeof(T);
            for (int row = 0; row < rows.Length; row++) {
                var line = rows[row];

                var parts = line.Split(Separator);
                for (int i = 0; i < parts.Length; i++) {
                    var value = parts[i];
                    var column = columns[i];

                    if (type.GetProperties().Any()) {
                        var p = type.GetProperties().FirstOrDefault(f => f.Name == column);
                        if (p != null) {
                            var converter = TypeDescriptor.GetConverter(p.PropertyType);
                            var convertedvalue = converter.ConvertFrom(value);

                            p.SetValue(data, convertedvalue);
                        }
                    }

                    if (type.GetFields().Any()) {
                        var f = type.GetFields().FirstOrDefault(f => f.Name == column);
                        if (f != null) {
                            var converter = TypeDescriptor.GetConverter(f.FieldType);
                            var convertedvalue = converter.ConvertFrom(value);

                            f.SetValue(data, convertedvalue);
                        }
                    }
                }
            }

            return data;
        }
    }
}
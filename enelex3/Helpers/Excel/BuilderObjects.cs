using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows;
using enelex3.View;

namespace enelex3.Helpers.Excel
{
    internal class BuilderObjects : IBuilderObjects
    {


        public IEnumerable<object> BuildObject(string data, Type type, bool showErrorMessages, bool cancelWithErrors)
        {
            var result = new List<object>();
           

            var lines = data.Split('\n').Where(a => !string.IsNullOrWhiteSpace(a)).ToList();

            foreach (var line in lines)
            {
                var lineDef = line;

                if (line.Last() == '\r') lineDef = line.Remove(line.Count() - 1);

                object resultObj = null;


                //     resultObj = BuildData(lineDef, type);
                var fields = line.Split('\t');

                var properties = type.GetProperties();

                var result1 = Activator.CreateInstance(type);

                for (int i = 0; i < fields.Count(); i++)
                {
                    var value = Converters.ConverterTo(fields[i], properties[i]);

                    properties[i].SetValue(result1, value);
                }
                result.Add(resultObj);
                
            }

            return result;
        }


        public object BuildData(string line, Type type)
        {
            var fields = line.Split('\t');

            var properties = type.GetProperties();

            var result = Activator.CreateInstance(type);

            for (int i = 0; i < fields.Count(); i++)
            {
                var value = Converters.ConverterTo(fields[i], properties[i]);

                properties[i].SetValue(result, value);
            }

            return result;
        }


    }
}

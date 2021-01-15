using System;
using System.Collections.Generic;

namespace enelex3.Helpers.Excel
{
    internal interface IBuilderObjects
    {
        object BuildData(string line, Type type);
        IEnumerable<object> BuildObject(string data, Type type, bool shwoErrorMessages, bool cancelWithErrors);
    }
}
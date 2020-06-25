using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.Helpers
{
   public static class CollectionHelper
    {
        public static ObservableCollection<T> ToObservable<T> (this IEnumerable<T> input)
        {
            var result = new ObservableCollection<T>();
            foreach(var x in input)
            {
                result.Add(x);
            }
            return result;
        }

    }
}

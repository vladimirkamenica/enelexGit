using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.ReturnIndex
{
    public static class GetIndex
    {
        public static int Index(Action Load, int Index)
        {
            List<int> index = new List<int>();
            if (Index == -1)
            {
                index.Add(0);
            }
            else
            {
                index.Add(Index);
            }
            Load?.Invoke();
            return index[0];
            index.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.Interfaces
{
    public interface IBasicData
    {
        long ID { get; set; }

        string Description { get; set; }

        string Comment { get; set; }

        bool Active { get; set; }
    }
}

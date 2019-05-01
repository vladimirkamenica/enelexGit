using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.Interfaces
{
    public interface IDates
    {
        long CreationUserID { get; set; }
        DateTime CreationDate { get; set; }

        long UpdateUserID { get; set; }
        DateTime UpdateDate { get; set; }
    }
}

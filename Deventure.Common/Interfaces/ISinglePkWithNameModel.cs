using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deventure.Common.Interfaces
{
    public interface ISinglePkWithNameModel : ISinglePkModel
    {
        string Name { get; set; }
    }
}

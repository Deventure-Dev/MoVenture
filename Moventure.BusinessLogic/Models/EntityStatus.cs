using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public enum EntityStatus
    {
       DELETED = -2,
       INACTIVE = -1,
       PENDING = 0,
       ACTIVE = 1,
    }
}

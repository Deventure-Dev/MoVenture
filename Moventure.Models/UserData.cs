using System;
using System.Collections;
using System.Collections.Generic;

namespace Moventure.Models
{
    public class UserData
    {
        public User User { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}

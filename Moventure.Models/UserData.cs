using System.Collections.Generic;

namespace Moventure.Models
{
    public class UserData
    {
        public User User { get; set; }

        public IList<CategoryModel> Categories { get; set; }
    }
}

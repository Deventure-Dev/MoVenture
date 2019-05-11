using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deventure.Common.Models
{
    public class UserData
    {
        //public List<Notification> Notifications { get; set; }
        public User User { get; set; }

        public bool ShouldForceUpdate { get; set; }

        public string UpdateLink { get; set; }

        public Version Version { get; set; }

        public int TranslationVersion { get; set; }

        public string Email { get; set; }

        public string School { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class DisplayPlaylist
    {
        public DisplayPlaylist()
        {
            Movies = new List<DisplayMovie>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }

        public ICollection<DisplayMovie> Movies { get; set; }
    }
}

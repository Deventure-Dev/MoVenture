using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class PlaylistModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime SavedAt { get; set; }
    }
}

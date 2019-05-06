using System;
using System.Collections.Generic;

namespace Moventure.DataLayer.Models
{
    public partial class Playlists
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public DateTime SavedAt { get; set; }

        public virtual Users User { get; set; }
    }
}

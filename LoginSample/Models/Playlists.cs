using System;
using System.Collections.Generic;

namespace LoginSample.Models
{
    public partial class Playlists
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public DateTime SavedAt { get; set; }

        public Users User { get; set; }
    }
}

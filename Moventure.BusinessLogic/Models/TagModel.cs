using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class PostTagModel
    {
        public string Name { get; set; }
    }
    public class TagModel : PostTagModel
    {
        public Guid Id { get; set; }
        public DateTime SavedAt { get; set; }
        public string SavedBy { get; set; }
    }
}

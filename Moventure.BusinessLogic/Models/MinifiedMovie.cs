using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class MinifiedMovie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PictureUrl { get; set; }
        public double Rating { get; set; }
        public int Length { get; set; }
        public string CreatedBy { get; set; }
        public List<TagModel> Tags { get; set; }
        public CategoryModel MainCategory { get; set; }
    }
}

using MedinovaMPA101.Models.Common;

namespace MedinovaMPA101.Models
{
    public class Team:BaseEntity
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public ICollection<Blog> Blogs { get; set; } = [];
    }
}


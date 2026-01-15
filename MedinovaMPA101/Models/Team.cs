using MedinovaMPA101.Models.Common;

namespace MedinovaMPA101.Models
{
    public class Team:BaseEntity
    {
        public string ImagePath { get; set; } = string.Empty;
        public string Name { get; set; }= string.Empty;
        public string Position { get; set; }= string.Empty;
        public string Description { get; set; }= string.Empty;
        public ICollection<Blog> Blogs { get; set; } = [];
    }
}


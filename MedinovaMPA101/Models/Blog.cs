using MedinovaMPA101.Models.Common;

namespace MedinovaMPA101.Models
{
    public class Blog:BaseEntity
    {
        public string ImagePath { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}

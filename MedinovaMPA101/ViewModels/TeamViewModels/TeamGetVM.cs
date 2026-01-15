using System.ComponentModel.DataAnnotations;

namespace MedinovaMPA101.ViewModels.TeamViewModels
{
    public class TeamGetVM
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

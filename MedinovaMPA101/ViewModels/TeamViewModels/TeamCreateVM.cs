using System.ComponentModel.DataAnnotations;

namespace MedinovaMPA101.ViewModels.TeamViewModels
{
    public class TeamCreateVM
    {
        [Required, MaxLength(256)]
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(256)]
        public string Position { get; set; } = string.Empty;
        [Required, MaxLength(1024)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public IFormFile Image { get; set; } 
    }
}

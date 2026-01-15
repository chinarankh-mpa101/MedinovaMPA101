using System.ComponentModel.DataAnnotations;

namespace MedinovaMPA101.ViewModels.BlogViewModels
{
    public class BlogUpdateVM
    {
        public int Id { get; set; }
        [Required, MaxLength(256)]
        public string Text { get; set; } = string.Empty;
        [Required, MaxLength(256)]
        public string Description { get; set; } = string.Empty;
        public int TeamId { get; set; } 

        [Required]
        public IFormFile Image { get; set; } = null!;
    }
}

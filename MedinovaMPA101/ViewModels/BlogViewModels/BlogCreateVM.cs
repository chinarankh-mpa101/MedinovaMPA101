using System.ComponentModel.DataAnnotations;

namespace MedinovaMPA101.ViewModels.BlogViewModels
{
    public class BlogCreateVM
    {
       
       
        public string Text { get; set; }
        public string Description { get; set; }

        [Required]
        public int TeamId { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}

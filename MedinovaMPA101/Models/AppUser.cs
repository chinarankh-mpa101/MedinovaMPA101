using Microsoft.AspNetCore.Identity;

namespace MedinovaMPA101.Models
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
    }
}

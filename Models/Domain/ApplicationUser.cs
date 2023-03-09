using Microsoft.AspNetCore.Identity;

namespace LoginSystem.Models.Domain
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public virtual ICollection<Event> ?Events { get; set; }
    }
}


using Microsoft.AspNetCore.Identity;

namespace HomeworkDeliveryAPI.Models
{
    public class AppUser:IdentityUser<int>
    {
        public string AppUserNumber { get; set; }

        public List<AppUserAssignment> AppUserAssingnments { get; set; }
    }
}

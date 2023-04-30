using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Models
{
    public class CustomIdentityUser : IdentityUser
    {
        public string PersonalId{ get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

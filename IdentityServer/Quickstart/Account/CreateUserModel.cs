using Microsoft.EntityFrameworkCore.Metadata;

namespace IdentityServer.Quickstart.Account
{
    public class CreateUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace Algan.WebUi.Identity
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }

    }
}
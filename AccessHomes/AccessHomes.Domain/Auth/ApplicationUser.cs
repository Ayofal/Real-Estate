using AccessHomes.Domain.Entities;
using AccessHomes.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AccessHomes.Domain.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
        public List<Properties> Properties { get; set; }

        public UserType UserType { get; set; }
    }
}
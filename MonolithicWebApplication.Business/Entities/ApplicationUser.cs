using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonolithicWebApplication.Business.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        [NotMapped]
        public string Password { get; set; }
        public DateTime DateBirthday { get; set; }

        public string City { get; set; }

        public string StreetAddress { get; set; }
    }
}

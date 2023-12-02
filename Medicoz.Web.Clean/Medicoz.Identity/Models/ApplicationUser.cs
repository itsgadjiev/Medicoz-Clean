﻿using Microsoft.AspNetCore.Identity;

namespace Medicoz.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstRoleName { get; set; }
    }
}


using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Data
{
    public class ApplicationUser : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public String AdminType { get; set; }




    }
}

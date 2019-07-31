using Microsoft.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Data
{
    public class Mentoree
    {
        [Key]
        public string MentoreeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public string Company { get; set; }

        public string Career { get; set; }
    }
}

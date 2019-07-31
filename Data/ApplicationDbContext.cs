using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PortfolioProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Vids> Videos { get; set; }
        public DbSet<Mentoree> Mentoree { get; set; }
        public DbSet<Mentors> Mentors { get; set; }
        public DbSet<Connection> Connections { get; set; }

 


    }
}

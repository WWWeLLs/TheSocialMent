using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;

namespace PortfolioProject.Pages.ProjectVideos
{
    public class IndexModel : PageModel
    {
        private readonly PortfolioProject.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(PortfolioProject.Data.ApplicationDbContext context,

                             UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IList<Vids> Vids { get;set; }

        public ApplicationUser CurrentUser { get; set; }
        public async Task OnGetAsync()
        {
            Vids = await _context.Videos.ToListAsync();

            CurrentUser = await _userManager.GetUserAsync(User);
        }
    }
}

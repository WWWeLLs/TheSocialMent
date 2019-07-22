using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;

namespace PortfolioProject.Pages.ProjectMentors
{
    public class DetailsModel : PageModel
    {
        private readonly PortfolioProject.Data.ApplicationDbContext _context;

        public DetailsModel(PortfolioProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Mentors Mentors { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mentors = await _context.Mentors.FirstOrDefaultAsync(m => m.MentorsId == id);

            if (Mentors == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

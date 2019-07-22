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
    public class DeleteModel : PageModel
    {
        private readonly PortfolioProject.Data.ApplicationDbContext _context;

        public DeleteModel(PortfolioProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mentors Mentors { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await NewMethod(id);

            if (Mentors == null)
            {
                return NotFound();
            }
            return Page();
        }

        private async Task NewMethod(string id)
        {
            Mentors = await _context.Mentors.FirstOrDefaultAsync(m => m.MentorsId == id);
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mentors = await _context.Mentors.FindAsync(id);

            if (Mentors != null)
            {
                _context.Mentors.Remove(Mentors);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

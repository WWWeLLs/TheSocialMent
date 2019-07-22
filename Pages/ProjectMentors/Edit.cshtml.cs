using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;

namespace PortfolioProject.Pages.ProjectMentors
{
    public class EditModel : PageModel
    {
        private readonly PortfolioProject.Data.ApplicationDbContext _context;

        public EditModel(PortfolioProject.Data.ApplicationDbContext context)
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

            Mentors = await _context.Mentors.FirstOrDefaultAsync(m => m.MentorsId == id);

            if (Mentors == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Mentors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MentorsExists(Mentors.MentorsId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MentorsExists(string id)
        {
            return _context.Mentors.Any(e => e.MentorsId == id);
        }
    }
}

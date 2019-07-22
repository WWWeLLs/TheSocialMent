using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;

namespace PortfolioProject.Pages.ProjectMentoree
{
    public class EditModel : PageModel
    {
        private readonly PortfolioProject.Data.ApplicationDbContext _context;

        public EditModel(PortfolioProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mentoree Mentoree { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mentoree = await _context.Mentoree.FirstOrDefaultAsync(m => m.MentoreeId == id);

            if (Mentoree == null)
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

            _context.Attach(Mentoree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MentoreeExists(Mentoree.MentoreeId))
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

        private bool MentoreeExists(string id)
        {
            return _context.Mentoree.Any(e => e.MentoreeId == id);
        }
    }
}

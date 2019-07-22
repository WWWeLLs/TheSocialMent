using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;

namespace PortfolioProject.Pages.ProjectMentoree
{
    public class DeleteModel : PageModel
    {
        private readonly PortfolioProject.Data.ApplicationDbContext _context;

        public DeleteModel(PortfolioProject.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mentoree = await _context.Mentoree.FindAsync(id);

            if (Mentoree != null)
            {
                _context.Mentoree.Remove(Mentoree);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

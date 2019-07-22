using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;

namespace PortfolioProject.Pages.ProjectVideos
{
    public class DeleteModel : PageModel
    {
        private readonly PortfolioProject.Data.ApplicationDbContext _context;

        public DeleteModel(PortfolioProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vids Vids { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vids = await _context.Videos.FirstOrDefaultAsync(m => m.VideoId == id);

            if (Vids == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vids = await _context.Videos.FindAsync(id);

            if (Vids != null)
            {
                _context.Videos.Remove(Vids);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

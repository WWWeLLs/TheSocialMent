using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortfolioProject.Data;

namespace PortfolioProject.Pages.ProjectConnection
{
    public class CreateModel : PageModel
    {
        private readonly PortfolioProject.Data.ApplicationDbContext _context;

        public CreateModel(PortfolioProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Connection Connection { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Connections.Add(Connection);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
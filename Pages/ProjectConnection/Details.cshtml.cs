using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;

namespace PortfolioProject.Pages.ProjectConnection
{
    public class DetailsModel : PageModel
    {
        private readonly PortfolioProject.Data.ApplicationDbContext _context;

        public DetailsModel(PortfolioProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Connection Connection { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Connection = await _context.Connections.FirstOrDefaultAsync(m => m.ConnectionId == id);

            if (Connection == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

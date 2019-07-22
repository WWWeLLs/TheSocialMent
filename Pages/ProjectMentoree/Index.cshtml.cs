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
    public class IndexModel : PageModel
    {
        private readonly PortfolioProject.Data.ApplicationDbContext _context;

        public IndexModel(PortfolioProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Mentoree> Mentoree { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MentoreeSearch { get; set; }
     
        public async Task OnGetAsync( )
        {
            var theMentoreeSearch = from m in _context.Mentoree select m;
                if(!string.IsNullOrEmpty(MentoreeSearch))
            {
               theMentoreeSearch = theMentoreeSearch.Where(s =>
                s.FirstName.Contains(MentoreeSearch));
            }

            
            Mentoree = await _context.Mentoree.ToListAsync();

       
        }

            
    }
}

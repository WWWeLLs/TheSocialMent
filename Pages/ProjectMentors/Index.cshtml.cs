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
    public class IndexModel : PageModel
    {
        private readonly PortfolioProject.Data.ApplicationDbContext _context;

        public IndexModel(PortfolioProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Mentors> Mentors { get;set; }

        [BindProperty(SupportsGet = true)]
        public string MentorSearch { get; set; }

        public async Task OnGetAsync()
        {
                var theMentorSearch = from m in _context.Mentors select m;
                if (!string.IsNullOrEmpty(MentorSearch))
                {
                    theMentorSearch = theMentorSearch.Where(s =>
                     s.FirstName.Contains(MentorSearch));
                }


                Mentors = await _context.Mentors.ToListAsync();
        }
    }
}

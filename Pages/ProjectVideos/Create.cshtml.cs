using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortfolioProject.Data;

namespace PortfolioProject.Pages.ProjectVideos
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
        public Vids Vids { get; set; }
        public byte[] FileBytes { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //added notes
            // gives you the ability to grab multiple files at once from file input
            var files = HttpContext.Request.Form.Files;

            // checks to see if there are any files. the data type can be a boolean, because this function is a true/false statement

            var containsFiles = files.Any();

            if (containsFiles)
            {
                System.Diagnostics.Debug.WriteLine(files[0].FileName);
                //converting img into memory stream
                using (var ms = new System.IO.MemoryStream())
                {
                    files[0].CopyTo(ms);
                    var filesBytes = ms.ToArray();
                    string s = Convert.ToBase64String(FileBytes);
                    Vids.YouTubeCode = s;
                }

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Did not work");
            }

            _context.Videos.Add(Vids);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
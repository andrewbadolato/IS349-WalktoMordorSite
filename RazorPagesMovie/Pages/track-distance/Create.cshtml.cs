using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.track_distance
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Models.TrackerContext _context;

        public CreateModel(RazorPagesMovie.Models.TrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tracker Tracker { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tracker.Add(Tracker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.track_distance
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMovie.Models.TrackerContext _context;

        public EditModel(RazorPagesMovie.Models.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tracker Tracker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tracker = await _context.Tracker.SingleOrDefaultAsync(m => m.ID == id);

            if (Tracker == null)
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

            _context.Attach(Tracker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackerExists(Tracker.ID))
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

        private bool TrackerExists(int id)
        {
            return _context.Tracker.Any(e => e.ID == id);
        }
    }
}

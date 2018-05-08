using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WalktoMordor.Models;

namespace WalktoMordor.Pages.track_distance
{
    public class DeleteModel : PageModel
    {
        private readonly WalktoMordor.Models.TrackerContext _context;

        public DeleteModel(WalktoMordor.Models.TrackerContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tracker = await _context.Tracker.FindAsync(id);

            if (Tracker != null)
            {
                _context.Tracker.Remove(Tracker);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

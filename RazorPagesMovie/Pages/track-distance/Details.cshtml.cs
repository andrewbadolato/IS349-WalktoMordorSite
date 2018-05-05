using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.track_distance
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie.Models.TrackerContext _context;

        public DetailsModel(RazorPagesMovie.Models.TrackerContext context)
        {
            _context = context;
        }

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
    }
}

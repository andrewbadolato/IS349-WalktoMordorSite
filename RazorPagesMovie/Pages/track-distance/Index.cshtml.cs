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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.TrackerContext _context;

        public IndexModel(RazorPagesMovie.Models.TrackerContext context)
        {
            _context = context;
        }

        public IList<Tracker> Tracker { get;set; }

        public async Task OnGetAsync()
        {
            Tracker = await _context.Tracker.ToListAsync();
        }
    }
}

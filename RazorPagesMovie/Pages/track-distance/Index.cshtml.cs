using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
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

        public IList<Tracker> Tracker { get; set; }

        //public async Task OnGetAsync()
        //{
        //    Tracker = await _context.Tracker.ToListAsync();
        //}


        public async Task OnGetAsync()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var entries = from t in _context.Tracker
                          select t;

            entries = entries.Where(t => t.OwnerID.Equals(currentUserID));

            Tracker = await entries.ToListAsync();
        }



        // Use LINQ to get list of genres.
        //IQueryable<string> genreQuery = from m in _context.Tracker
        //                                select m.user;


        //var movies = from m in _context.Tracker
        //             select m;

        //if (!String.IsNullOrEmpty(userID))
        //{
        //    movies = movies.Where(x => x.OwnerID == currentUserID;
        //}
        //Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
        //Movie = await movies.ToListAsync();
        //}
    }
}
   

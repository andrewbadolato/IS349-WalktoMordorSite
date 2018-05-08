using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WalktoMordor.Models;


namespace WalktoMordor.Pages.track_distance
{
    public class IndexModel : PageModel
    {
        private readonly WalktoMordor.Models.TrackerContext _context;
        private String currentUserID;
        private decimal distTotal;

        public IndexModel(WalktoMordor.Models.TrackerContext context)
        {
            _context = context;
        }

        public IList<Tracker> Tracker { get; set; }
        public IList<Location> Location { get; set; }


        public async Task OnGetAsync()
        {

            //this if...else statement does not prevent NullReferenceException when user not logged in - must fix
            if (User.Identity.IsAuthenticated)
            {
                ClaimsPrincipal currentUser = User;
                currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();

                var entries = from t in _context.Tracker
                              select t;

                entries = entries.Where(t => t.OwnerID.Equals(currentUserID));

                Tracker = await entries.ToListAsync();


            //Calculates current entry count and total distance
            IEnumerable<Tracker> data =
            from Tracker in Tracker
            group Tracker by Tracker into distGroup
            select new Tracker()
            {
                DistCount = distGroup.Count(),
                DistTotal = distGroup.Sum(s => s.Distance)
            };

                

            }


            else
            {
                RedirectToPage("/Account/Login");
            }

        }
    }
}


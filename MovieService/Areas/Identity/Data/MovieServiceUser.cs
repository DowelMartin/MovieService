using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MovieService.Models;

namespace MovieService.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MovieServiceUser class
    public class MovieServiceUser : IdentityUser
    {
        public List<Watchlist> Watchlists {get; set; }
    }
}

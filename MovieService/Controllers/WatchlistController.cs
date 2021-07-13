using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieService.Areas.Identity.Data;
using MovieService.Models;
using MovieService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Controllers
{
    public class WatchlistController : Controller
    {
        private UserManager<MovieServiceUser> _userManager;
        private IWatchlistRepository _watchlistRepository;
        public WatchlistController(IWatchlistRepository watchlistRepository,
            UserManager<MovieServiceUser> userManager)
        {
            _watchlistRepository = watchlistRepository;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userID = _userManager.GetUserId(HttpContext.User);
            var watchlists = _watchlistRepository.GetUserWatchlist(userID);

            return View(watchlists);
        }
        public IActionResult New(int movieID)
        {
            var userID = _userManager.GetUserId(HttpContext.User);

            var watchlist = new Watchlist
            {
                MovieID = movieID,
                UserID = userID
            };

            _watchlistRepository.Create(watchlist);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int ID)
        {
            var watchlist = _watchlistRepository.GetWatchlist(ID);

            _watchlistRepository.Remove(watchlist);

            return RedirectToAction(nameof(Index));
        }
    }
}

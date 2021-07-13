using Microsoft.EntityFrameworkCore;
using MovieService.Data;
using MovieService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Repositories
{
    public class WatchlistRepository : IWatchlistRepository
    {
        private MovieServiceContext _context;
        public WatchlistRepository(MovieServiceContext context)
        {
            _context = context;
        }

        public bool CheckIfAlreadyExists(string userID, int movieID)
        {
            return _context.Watchlists.Any(w => w.UserID.Equals(userID) && w.MovieID == movieID);
        }

        public void Create(Watchlist watchlist)
        {
            _context.Watchlists.Add(watchlist);
            _context.SaveChanges();
        }

        public List<Watchlist> GetUserWatchlist(string userID)
        {
            return _context.Watchlists
                .Include(w => w.Movie)
                .Where(w => w.UserID.Equals(userID))
                .ToList();
        }

        public Watchlist GetWatchlist(int ID)
        {
            return _context.Watchlists.FirstOrDefault(w => w.ID == ID);
        }

        public void Remove(Watchlist watchlist)
        {
            _context.Watchlists.Remove(watchlist);
            _context.SaveChanges();
        }
    }
}
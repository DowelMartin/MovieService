using MovieService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Repositories
{
    public interface IWatchlistRepository
    {
        Watchlist GetWatchlist(int ID);
        void Create(Watchlist watchlist);
        List<Watchlist> GetUserWatchlist(string userID);
        void Remove(Watchlist watchlist);

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieService.Areas.Identity.Data;
using MovieService.Models;

namespace MovieService.Data
{
    public class MovieServiceContext : IdentityDbContext<MovieServiceUser>
    {
        public MovieServiceContext(DbContextOptions<MovieServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieComment> MovieComments { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>()
                .HasMany(w => w.Watchlists)
                .WithOne(m => m.Movie)
                .IsRequired();

            builder.Entity<MovieServiceUser>()
                .HasMany(w => w.Watchlists)
                .WithOne(u => u.User)
                .IsRequired();

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

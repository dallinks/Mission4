using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mission4.Models
{
    public class NewMovieContext : DbContext
    {
        public NewMovieContext (DbContextOptions<NewMovieContext> options) : base (options)
        {
            
        }
        public DbSet<ApplicationResponse> responses { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    MovieID = 1,
                    Category = "Action",
                    Title = "Interstellar",
                    Year = 2015,
                    Director = "John Smith",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    MovieID = 2,
                    Category = "Romance",
                    Title = "16 Candles",
                    Year = 1994,
                    Director = "Jenny Smith",
                    Rating = "G",
                    Edited = false,
                    LentTo = "",
                    Notes = "This one's weird"
                },
                new ApplicationResponse
                {
                    MovieID = 3,
                    Category = "Horror",
                    Title = "The Watcher",
                    Year = 2010,
                    Director = "Whitney White",
                    Rating = "R",
                    Edited = true,
                    LentTo = "My dad",
                    Notes = "Spooky"
                }
                );
        }
    }
}

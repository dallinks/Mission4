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
        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName="Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy"},
                new Category { CategoryID = 3, CategoryName = "Drama" },
                new Category { CategoryID = 4, CategoryName = "Family" },
                new Category { CategoryID = 5, CategoryName = "Comedy" },
                new Category { CategoryID = 6, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 7, CategoryName = "Comedy" },
                new Category { CategoryID = 8, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 9, CategoryName = "Television" },
                new Category { CategoryID = 10, CategoryName = "VHS" }
            );
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    MovieID = 1,
                    CategoryID = 1,
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
                    CategoryID = 2,
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
                    CategoryID = 3,
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

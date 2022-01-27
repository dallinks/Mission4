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
                    Title = "Naruto",
                    Year = 1994,
                    Director = "John Smith",
                    Rating = "G",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
                );
        }
    }
}

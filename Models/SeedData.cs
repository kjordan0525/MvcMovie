using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {

                // look for any movies
                if (context.Movie.Any())
                    return;

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Mad Max: Fury Road",
                        ReleaseDate = DateTime.Parse("2015-5-15"),
                        Genre = "Action",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "The Thing",
                        ReleaseDate = DateTime.Parse("1982-7-5"),
                        Genre = "Horror",
                        Price = 5.99M
                    },

                    new Movie
                    {
                        Title = "The Incredibles",
                        ReleaseDate = DateTime.Parse("2004-11-5"),
                        Genre = "Family",
                        Price = 6.99M
                    },

                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 4.99M
                    }

                );

                context.SaveChanges();
            }
        }
    }
}

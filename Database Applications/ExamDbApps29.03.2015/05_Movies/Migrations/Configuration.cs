using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using _05_Movies.Models;

namespace _05_Movies.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MoviesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "_05_Movies.MoviesContext";
        }

        protected override void Seed(MoviesContext context)
        {
            ImportCountries(context);
            ImportMovies(context);
            ImportUsers(context);
            ImportUsersAndFavouriteMovies(context);
        }

        private static void ImportCountries(MoviesContext context)
        {
            if (!context.Countries.Any())
            {
                var json = File.ReadAllText("../../data/countries.json");
                var jsSerializer = new JavaScriptSerializer();
                var parsedCountry = jsSerializer.Deserialize<IEnumerable<Country>>(json);

                foreach (var country in parsedCountry)
                {
                    try
                    {
                        context.Countries.Add(new Country()
                        {
                            Name = country.Name
                        });

                        context.SaveChanges();
                        Console.WriteLine("Country \"{0}\" imported", country.Name);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                    }
                }
            }
        }

        private static void ImportMovies(MoviesContext context)
        {
            if (!context.Movies.Any())
            {
                var json = File.ReadAllText("../../data/movies.json");
                var jsSerializer = new JavaScriptSerializer();
                var parsedMovie = jsSerializer.Deserialize<IEnumerable<Movie>>(json);

                foreach (var movie in parsedMovie)
                {
                    try
                    {
                        context.Movies.Add(new Movie()
                        {
                            Title = movie.Title,
                            Isbn = movie.Isbn,
                            AgeRestriction = movie.AgeRestriction
                        });
                        context.SaveChanges();
                        Console.WriteLine("Movie \"{0}\" imported", movie.Title);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                    }
                }
            }
        }

        private static void ImportUsers(MoviesContext context)
        {
            if (!context.Users.Any())
            {
                var json = File.ReadAllText("../../data/users.json");
                var jsSerializer = new JavaScriptSerializer();
                var parsedUsers = jsSerializer.Deserialize<IEnumerable<UserDTO>>(json);

                foreach (var userDto in parsedUsers)
                {
                    try
                    {
                        var user = new User()
                        {
                            Username = userDto.Username,
                            Email = userDto.Email,

                        };

                        if (userDto.Age != null)
                        {
                            var age = int.Parse(userDto.Age);
                            user.Age = age;
                        }

                        if (userDto.Country != null)
                        {
                            var countryId = context.Countries.FirstOrDefault(c => c.Name == userDto.Country).Id;
                            user.CountryId = countryId;
                        }

                        context.Users.Add(user);
                        context.SaveChanges();
                        Console.WriteLine("User \"{0}\" imported", user.Username);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                    }
                }
            }
        }

        private static void ImportUsersAndFavouriteMovies(MoviesContext context)
        {
            var json = File.ReadAllText("../../data/users-and-favourite-movies.json");
            var jsSerializer = new JavaScriptSerializer();
            var movieUserDTOs = jsSerializer.Deserialize<IEnumerable<MovieUserDTO>>(json);

            foreach (var userMovies in movieUserDTOs)
            {
                try
                {
                    var user = context.Users.FirstOrDefault(u => u.Username == userMovies.Username);
                    foreach (var movieIsbn in userMovies.FavouriteMovies)
                    {
                        var movie = context.Movies.First(m => m.Isbn == movieIsbn);
                        if (user.FavouriteMovies.Any(m=> m.Isbn == movieIsbn))
                        {
                            continue;
                        }
                        user.FavouriteMovies.Add(movie);
                        Console.WriteLine("Movie-user pair imported. Movie: {0} User: {1}", user.Username, movie.Title  );
                    }
                    
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }
    }
}

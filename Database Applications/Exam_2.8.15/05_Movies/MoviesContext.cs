using System.Data.Entity;
using _05_Movies.Migrations;
using _05_Movies.Models;

namespace _05_Movies
{
    public class MoviesContext : DbContext
    {
        public MoviesContext()
            : base("name=Movies")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesContext, Configuration>());
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
            HasMany(u => u.FavouriteMovies).
            WithMany(m => m.LikedByUsers).
            Map(
                m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("MovieId");
                    m.ToTable("MovieUsers");
                });
        }
    }
}
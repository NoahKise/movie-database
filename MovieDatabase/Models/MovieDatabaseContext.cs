using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MovieDatabase.Models;

public class MovieDatabaseContext : DbContext
{
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<ActorFilm> ActorFilms { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public MovieDatabaseContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SeedGenres(modelBuilder);
    }

    public void SeedGenres(ModelBuilder modelBuilder)
    {
        var predefinedGenres = new List<Genre>
            {
            new Genre { Name = "Action", GenreId = 1 },
            new Genre { Name = "Adventure", GenreId = 2 },
            new Genre { Name = "Comedy", GenreId = 3 },
            new Genre { Name = "Crime", GenreId = 4 },
            new Genre { Name = "Drama", GenreId = 5 },
            new Genre { Name = "Fantasy", GenreId = 6 },
            new Genre { Name = "Historical", GenreId = 7 },
            new Genre { Name = "Horror", GenreId = 8  },
            new Genre { Name = "Romance", GenreId = 9 },
            new Genre { Name = "SciFi", GenreId = 10 },
        };
        modelBuilder.Entity<Genre>().HasData(predefinedGenres);
    }
}

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
            new Genre(1, "Action"),
            new Genre(2, "Adventure"),
            new Genre(3, "Comedy"),
            new Genre(4, "Crime"),
            new Genre(5, "Drama"),
            new Genre(6, "Fantasy"),
            new Genre(7, "Historical"),
            new Genre(8, "Horror"),
            new Genre(9, "Romance"),
            new Genre(10, "SciFi"),
        };
        modelBuilder.Entity<Genre>().HasData(predefinedGenres);
    }
}

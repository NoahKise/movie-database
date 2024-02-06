using Microsoft.EntityFrameworkCore;

namespace MovieDatabase.Models;

public class MovieDatabaseContext : DbContext
{
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<ActorFilm> ActorFilms { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public MovieDatabaseContext(DbContextOptions options) : base(options) { }
}
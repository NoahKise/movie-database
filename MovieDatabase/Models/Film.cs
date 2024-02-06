using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Models;

public class Film
{
    public int FilmId { get; set; }
    [Required(ErrorMessage = "The film needs a name!")]
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Rating { get; set; }
    public string MpaRating { get; set; }
    public string Director { get; set; }
    public string UrlImage { get; set; }
    public bool IsWatched { get; set; } = false;
    public List<Actor> Actors { get; set; }
    public List<ActorFilm> JoinEntities { get; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}
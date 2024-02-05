using System.Collections.Generic;

namespace MovieDatabase.Models;

public class Film
{
    public int FilmId { get; set; }
    public string Name { get; set; }
    public string ReleaseDate { get; set; }
    public int Rating { get; set; }
    public string Director { get; set; }
    public string UrlImage { get; set; }
    public List<Actor> Actors { get; set; }
    public List<ActorFilm> JoinEntities { get; }
}
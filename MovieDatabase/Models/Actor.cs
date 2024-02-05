using System.Collections.Generic;

namespace MovieDatabase.Models;

public class Actor
{
    public int ActorId { get; set; }
    public string Name { get; set; }
    public string UrlImage { get; set; }
    public List<ActorFilm> JoinEntities { get; }
}
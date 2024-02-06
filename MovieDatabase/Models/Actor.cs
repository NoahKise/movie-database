using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Models;

public class Actor
{
    public int ActorId { get; set; }
    [Required(ErrorMessage = "The actor must have a name!")]
    public string Name { get; set; }
    public string UrlImage { get; set; }
    public List<ActorFilm> JoinEntities { get; }
}
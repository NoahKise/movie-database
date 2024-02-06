using System.Collections.Generic;
using System;

namespace MovieDatabase.Models;

public class Genre
{
    public int GenreId { get; set; }
    public string Name { get; set; }
    public string SubGenre { get; set; }
    public List<Film> Films { get; set; }

    public Genre(int genreId, string name)
    {
        GenreId = genreId;
        Name = name;
    }
}




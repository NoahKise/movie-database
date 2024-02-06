using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace MovieDatabase.Controllers;

public class GenresController : Controller
{
    private readonly MovieDatabaseContext _db;
    public GenresController(MovieDatabaseContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Genre> genres = GenresController.GetAllGenres();
        return View(genres);
    }

    public static List<Genre> GetAllGenres()
    {
        return new List<Genre>
        {
            new Genre(1, "Action"),
            new Genre(2, "Adventure"),
            new Genre(3, "Comedy"),
            new Genre(4, "Crime"),
            new Genre(5, "Drama"),
            new Genre(6, "Fantacy"),
            new Genre(7, "Historical"),
            new Genre(8, "Horror"),
            new Genre(9, "Romance"),
            new Genre(10, "SciFi"),
        };
    }

    public ActionResult Details(int id)
    {
        Genre thisGenre = _db.Genres
        .Include(genre => genre.Films)
        .FirstOrDefault(genre => genre.GenreId == id);
        return View(thisGenre);
    }
}


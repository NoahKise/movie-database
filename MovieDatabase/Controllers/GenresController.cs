using System;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        List<Genre> genres = _db.Genres.ToList();
        return View(genres);
    }

    public ActionResult Details(int id)
    {
        Genre thisGenre = _db.Genres
        .Include(genre => genre.Films)
        .FirstOrDefault(genre => genre.GenreId == id);
        return View(thisGenre);
    }
}


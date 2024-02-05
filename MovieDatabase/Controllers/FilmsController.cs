using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieDatabase.Controllers;

public class FilmsController : Controller
{
    private readonly MovieDatabaseContext _db;
    public FilmsController(MovieDatabaseContext db)
    {
        _db = db;
    }
    public ActionResult Index()
    {
        List<Film> model = _db.Films.ToList();
        return View(model);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Film film)
    {
        _db.Films.Add(film);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
        Film thisFilm = _db.Films
        // .Include(film => film.Actors)
        // .ThenInclude(actor => actor.JoinEntities)
        // .ThenInclude(join => join.?ActorFilm?)
        .FirstOrDefault(film => film.FilmId == id);
        return View(thisFilm);
    }
}
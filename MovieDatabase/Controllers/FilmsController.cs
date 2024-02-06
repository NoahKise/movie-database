using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace MovieDatabase.Controllers;

public class FilmsController : Controller
{
    private readonly MovieDatabaseContext _db;
    public FilmsController(MovieDatabaseContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index(string searchString)
    {
        IQueryable<Film> model = from m in _db.Films
                                 select m;

        if (!String.IsNullOrEmpty(searchString))
        {
            model = model.Where(s => s.Name!.Contains(searchString));
        }
        return View(await model.OrderBy(e => e.Name).ToListAsync());
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Film film)
    {
        if (!ModelState.IsValid)
        {
            return View(film);
        }
        _db.Films.Add(film);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
        Film thisFilm = _db.Films
        .Include(film => film.JoinEntities)
        .ThenInclude(join => join.Actor)
        .FirstOrDefault(film => film.FilmId == id);
        return View(thisFilm);
    }
    public ActionResult Edit(int id)
    {
        Film thisFilm = _db.Films.FirstOrDefault(film => film.FilmId == id);
        return View(thisFilm);
    }
    [HttpPost]
    public ActionResult Edit(Film film)
    {
        _db.Films.Update(film);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
        Film thisFilm = _db.Films.FirstOrDefault(film => film.FilmId == id);
        return View(thisFilm);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Film thisFilm = _db.Films.FirstOrDefault(film => film.FilmId == id);
        _db.Films.Remove(thisFilm);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult AddActor(int id)
    {
        Film thisFilm = _db.Films.FirstOrDefault(films => films.FilmId == id);
        ViewBag.ActorId = new SelectList(_db.Actors, "ActorId", "Name");
        return View(thisFilm);
    }
    [HttpPost]
    public ActionResult AddActor(Film film, int actorId)
    {
#nullable enable
        ActorFilm? joinEntity = _db.ActorFilms.FirstOrDefault(join => (join.ActorId == actorId && join.FilmId == film.FilmId));
#nullable disable
        if (joinEntity == null && actorId != 0)
        {
            _db.ActorFilms.Add(new ActorFilm() { ActorId = actorId, FilmId = film.FilmId });
            _db.SaveChanges();
        }
        return RedirectToAction("Details", new { id = film.FilmId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
        ActorFilm joinEntry = _db.ActorFilms.FirstOrDefault(entry => entry.ActorFilmId == joinId);
        _db.ActorFilms.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult MarkAsWatched(int id)
    {
        Film thisFilm = _db.Films.FirstOrDefault(films => films.FilmId == id);
        thisFilm.IsWatched = true;
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = id });
    }
}
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieDatabase.Controllers;

public class ActorsController : Controller
{
    private readonly MovieDatabaseContext _db;
    public ActorsController(MovieDatabaseContext db)
    {
        _db = db;
    }
    public ActionResult Index()
    {
        List<Actor> model = _db.Actors.ToList();
        return View(model);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Actor actor)
    {
        _db.Actors.Add(actor);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        Actor thisActor = _db.Actors
        .Include(actor => actor.JoinEntities)
        .ThenInclude(join => join.Film)
       .FirstOrDefault(actor => actor.ActorId == id);
        return View(thisActor);
    }

    public ActionResult Edit(int id)
    {
        Actor thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
        return View(thisActor);
    }

    [HttpPost]
    public ActionResult Edit(Actor actor)
    {
        _db.Actors.Update(actor);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        Actor thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
        return View(thisActor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Actor thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
        _db.Actors.Remove(thisActor);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult AddFilm(int id)
    {
        Actor thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
        ViewBag.FilmId = new SelectList(_db.Films, "FilmId", "Name");
        return View(thisActor);
    }

    [HttpPost]
    public ActionResult AddFilm(Actor actor, int filmId)
    {
#nullable enable
        ActorFilm? joinEntity = _db.ActorFilms.FirstOrDefault(join => (join.FilmId == filmId && join.ActorId == actor.ActorId));
#nullable disable
        if (joinEntity == null && filmId != 0)
        {
            _db.ActorFilms.Add(new ActorFilm() { FilmId = filmId, ActorId = actor.ActorId });
            _db.SaveChanges();
        }
        return RedirectToAction("Details", new { id = actor.ActorId });
    }

}
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
}
// using System.Collections.Generic;
// using System;
// using Microsoft.AspNetCore.Mvc;
// using MovieDatabase.Models;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;

// namespace MovieDatabase.Controllers;

// public class ActorsController : Controller
// {
//     private readonly MovieDatabaseContext _db;
//     public ActorsController(MovieDatabaseContext db)
//     {
//         _db = db;
//     }
//     public ActionResult Index()
//     {
//         List<Actor> model = _db.Actors.ToList();
//         return View(model);
//     }
// }

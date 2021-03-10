using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;
    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Animal> model = _db.Animals.ToList();
      List<Animal> sortedName = model.OrderBy(animal => animal.Name).ToList();
      List<Animal> sortedDate = model.OrderBy(animal => animal.DateOfAdmittance).ToList();
      List<Animal> sortedType = model.OrderBy(animal => animal.Type).ToList();
      List<Animal> sortedBreed = model.OrderBy(animal => animal.Breed).ToList();
      return View(sortedName);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }
  }
}
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachineController : Controller
  {
    private readonly FactoryContext _db;

    public MachineController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Machines.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      if (machine.DateInstalled.Year == 0001)
      {
        machine.DateInstalled = DateTime.Now;
      }
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      return View(_db.Machines.FirstOrDefault(machine => machine.MachineId == id));
    }
        public ActionResult Delete(int id)
    {
      return View(_db.Machines.FirstOrDefault(machine => machine.MachineId == id));
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      _db.Machines.Remove(_db.Machines.FirstOrDefault(machine => machine.MachineId == id));
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
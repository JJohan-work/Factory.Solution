using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineerController : Controller
  {
    private readonly FactoryContext _db;
    
    public EngineerController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Engineers.ToList());
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      if (engineer.DateHired.Year == 0001)
      {
        engineer.DateHired = DateTime.Now;
      }

      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      return View(_db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id));
    }
    public ActionResult Delete(int id)
    {
      return View(_db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id));
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      _db.Engineers.Remove(_db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id));
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)  
    {
      return View(_db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id));
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddMachine(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int machineId)
    {
      var thisMachine = _db.Machines.FirstOrDefault(Machine => Machine.MachineId == machineId);
      if(machineId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { MachineId = machineId,  EngineerId = engineer.EngineerId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = engineer.EngineerId});
    }
    [HttpPost]
    public ActionResult DeleteMachine(int joinId)
    {
      var joinEntry = _db.EngineerMachines.FirstOrDefault(engineerMachine => engineerMachine.EngineerMachineId == joinId);
      int enginerId = joinEntry.Engineer.EngineerId;
      _db.EngineerMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = enginerId});
    }
  }
}
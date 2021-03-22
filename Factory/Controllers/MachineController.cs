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
    public ActionResult Edit(int id)  
    {
      return View(_db.Machines.FirstOrDefault(machine => machine.MachineId == id));
    }
    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }



    public ActionResult AddEngineer(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int engineerId)
    {
      // var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == engineerId);
      if(engineerId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { MachineId = machine.MachineId,  EngineerId = engineerId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = machine.MachineId});
    }
    [HttpPost]
    public ActionResult DeleteEngineer(int joinId)
    {
      var joinEntry = _db.EngineerMachines.FirstOrDefault(engineerMachine => engineerMachine.EngineerMachineId == joinId);
      int machineId = joinEntry.Machine.MachineId;
      _db.EngineerMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = machineId});
    }
  }
}
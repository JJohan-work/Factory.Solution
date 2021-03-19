using System;
using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.JoinEntities = new HashSet<EngineerMachine>();
    }

    public int MachineId { get; set; }
    public string Name { get; set; }
    public DateTime DateInstalled { get; set; }
    public string Notes { get; set; }
    public string Status { get; set; }
    public DateTime DateInspected { get; set; }

    public virtual ICollection<EngineerMachine> JoinEntities { get; }
  }
}
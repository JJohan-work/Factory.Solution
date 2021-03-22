using System;
using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.JoinEntities = new HashSet<EngineerMachine>();
    }

    public int EngineerId { get; set; }
    public string Name { get; set; }
    public DateTime DateHired { get; set; }
    public string Comments { get; set; }
    public string Status { get; set; }
    public virtual ICollection<EngineerMachine> JoinEntities { get; }
  }
}
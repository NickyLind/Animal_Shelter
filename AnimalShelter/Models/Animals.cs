using System;
using System.Linq;
using System.Collections;

namespace AnimalShelter.Models
{
  public class Animal 
  {
    public int AnimalId { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfAdmittance { get; set; }
    public string Breed { get; set; }
    public Animal()
    {
      this.DateOfAdmittance = DateTime.Now;
    }
  }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using LoginSystem.Models.Domain;
using System.Runtime.InteropServices;

namespace LoginSystem.Models;

public class Event
{
    [Key]
    public int? ID { get; set; }
   
    public string? EventName { get; set; }
}
  



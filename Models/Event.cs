using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using LoginSystem.Models.Domain;
using System.Runtime.InteropServices;

namespace LoginSystem.Models;

public class Event
{
    [Key]
    public int ?Id { get; set; }
   
    public string ?Name { get; set; }
    public string ?Description { get; set; }
    public DateTime ?StartTime { get; set; }
	public DateTime? EndTime { get; set; }

    //Relational Data 
    public virtual Location ?Location { get; set; }

}
  



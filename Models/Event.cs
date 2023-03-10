using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using LoginSystem.Models.Domain;
using System.Runtime.InteropServices;

namespace LoginSystem.Models;

public class Event
{
    [Key]
    public int ?ID { get; set; }
   
    public string ?Name { get; set; }
    public string ?Description { get; set; }
    public DateTime ?StartTime { get; set; }
    public DateTime ?EndTime { get; set; }
	
    public string? MyApplicationUserId { get; set; } // Add this property
    public ApplicationUser? ApplicationUser { get; set; } ///Foreign key

    //Relational Data 


}




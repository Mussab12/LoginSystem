using System.ComponentModel.DataAnnotations;


namespace LoginSystem.Models;

	public class Location
	{
	[Key]
	public int ?Id { get; set; }
	public string ?Name { get; set; }
	//Relational Data
	// Icollection for many relationship
	public virtual ICollection<Event> ?Events { get; set; }
	}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using LoginSystem.Models.Domain;
using System.Runtime.InteropServices;

namespace LoginSystem.Models;

    public class Event
    {
    public int? Eventid { get; set; }
    [Required]
    public string?Subject { get; set; }
    [Required]
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public string? Description { get; set; }

    public string? MyApplicationUserId { get; set; } // Add this property
    public ApplicationUser? ApplicationUser { get; set; } ///Foreign key
}


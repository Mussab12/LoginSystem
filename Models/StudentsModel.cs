using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using LoginSystem.Models.Domain;
using System.Runtime.InteropServices;

namespace LoginSystem.Models;
public class StudentsModel
{
    [Key]
    public int ?ID { get; set; }
    [Required]
    public string ?Name { get; set; }
    [Required]
    public string ?Program { get; set; }
    public int ?RollNo { get; set; }
    
    public string ?MyApplicationUserId { get; set; } // Add this property
    public ApplicationUser ?ApplicationUser { get; set; } ///Foreign key




}


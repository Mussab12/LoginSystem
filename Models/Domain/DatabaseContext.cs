using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace LoginSystem.Models.Domain
{

    public class DatabaseContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
       

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
      
      
        public DbSet<StudentsModel> ?MyStudents { get; set; }
        public DbSet<Event> Events { get; set; }
        

    }
}

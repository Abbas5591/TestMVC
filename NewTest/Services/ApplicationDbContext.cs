using Microsoft.EntityFrameworkCore;
using NewTest.Models;

namespace NewTest.Services
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
         
        }

        public DbSet<Units> Units { get; set; }

        //DbContext is a class in Entity Framework Core that acts as a bridge between your code and the database
    }
}

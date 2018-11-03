using Microsoft.EntityFrameworkCore;

namespace Assignment2_Bagga_Nishat
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Member> Members { get; set; }
    }   
}
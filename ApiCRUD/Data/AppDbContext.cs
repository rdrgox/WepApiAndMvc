namespace ApiCRUD.Data
{
    using ApiCRUD.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }

        public DbSet<Student> students { get; set; }
    }
}

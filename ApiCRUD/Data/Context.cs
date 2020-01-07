using System;
using ApiCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUD.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {
           
        }

        public DbSet<Student> students { get; set; }
    }
}

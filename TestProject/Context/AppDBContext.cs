using Microsoft.EntityFrameworkCore;
using TestProject.Models;
using TestProject.Models.v1;

namespace TestProject.Context
{
    //DB Context
    public class AppDBContext : DBContextBase<AppDBContext>
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}






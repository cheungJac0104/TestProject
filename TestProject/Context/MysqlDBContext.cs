using TestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Context
{
    //DB Context
    public class MysqlDBContext : DBContextBase<MysqlDBContext>
    {      
        

        public MysqlDBContext(DbContextOptions<MysqlDBContext> options) : base(options)
        {
        }


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






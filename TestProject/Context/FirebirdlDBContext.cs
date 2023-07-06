using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Context
{
    //DB Context

    //Connection String Sample
    //TCP/IP
    //    "firebirdConnection": "dialect=3;initial catalog=C:\\Users\\CMLHKREX\\Dropbox\\CMHK\\Source\\MedikareCleanDB\\CLINIC.DB;data source=192.168.1.79;user=sysdba;password=masterkey;port number=3050",
    //Localhost
    //    "firebirdConnection1": "initial catalog=C:\\Users\\CMLHKREX\\Dropbox\\CMHK\\Source\\MedikareCleanDB\\CLINIC.DB;data source=localhost;user=sysdba;password=masterkey"

    public class FirebirdlDBContext : DBContextBase<FirebirdlDBContext>
    {
		public FirebirdlDBContext(DbContextOptions<FirebirdlDBContext> options) : base(options)
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




 

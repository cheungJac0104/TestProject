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

    public class FirebirdlDicomDBContext : DbContext
    {
		static readonly ILoggerFactory _logger = LoggerFactory.Create(builder => { builder.AddConsole(); });
		readonly string _connectionString;

		//Tables

		public DbSet<MPatientFileBinDicom> MPatientFileBin { get; set; } // for medikare v1 existing file only 

		public FirebirdlDicomDBContext(string connectionString)
		{
			_connectionString = connectionString;
		}
		  
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder
				.UseLoggerFactory(_logger)
				.UseFirebird(_connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);  
		}

	}
}




 

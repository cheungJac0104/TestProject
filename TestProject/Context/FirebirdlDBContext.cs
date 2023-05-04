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

    public class FirebirdlDBContext : DbContext
    {
		static readonly ILoggerFactory _logger = LoggerFactory.Create(builder => { builder.AddConsole(); });
		readonly string _connectionString;

		//Tables
		public DbSet<MAppointment> MAppointment { get; set; }
    public DbSet<MCompany> MCompany { get; set; }
		
		public DbSet<MEvent> MEvent { get; set; }
		public DbSet<MFileHeader> MFileHeader { get; set; } 
    public DbSet<MInventory> MInventory { get; set; }
    public DbSet<MItem> MItem { get; set; }
		public DbSet<MPatientFile> MPatientFile { get; set; }
    public DbSet<MPatientFileBin> MPatientFileBin { get; set; }
    public DbSet<MPatientFileGroup> MPatientFileGroup { get; set; }

		public DbSet<MPatientFileLocate> MPatientFileLocate { get; set; } 
    public DbSet<MPatientFileType> MPatientFileType { get; set; }
		public DbSet<MPatientInfo> MPatientInfo { get; set; }
    public DbSet<MPaymentMethod> MPaymentMethod { get; set; }
    public DbSet<MStaff> MStaff { get; set; }
		
		public DbSet<SRecordIdx> SRecordIdx { get; set; }
		public DbSet<SDicomDB> SDicomDB { get; set; }

		public DbSet<TInventoryTrans> TInventoryTrans { get; set; }


		public FirebirdlDBContext(string connectionString)
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




 

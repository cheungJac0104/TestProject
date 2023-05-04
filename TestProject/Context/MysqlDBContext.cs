using TestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Context
{
    //DB Context
    public class MysqlDBContext : DbContext
    {
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
        


        
        

        readonly string _connectionString;


        public MysqlDBContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseMySql(_connectionString, MySqlServerVersion.LatestSupportedServerVersion);
        }


    }
}






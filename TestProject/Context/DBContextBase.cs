using System;
using Microsoft.EntityFrameworkCore;
using TestProject.Models;
using TestProject.Models.v1;

namespace TestProject.Context
{
	public class DBContextBase<T> : DbContext where T : DbContext
    {
        protected static readonly ILoggerFactory _logger = LoggerFactory.Create(builder => { builder.AddConsole(); });

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
        public DbSet<TVoucher> TVoucher { get; set; }


        // not involve in database

        public DbSet<InventoryItemSummaryModel> InventoryItemSummaryModel { get; set; }

        public DbSet<InventoryTransList> InventoryTansLists { get; set; }

        public DBContextBase(DbContextOptions<T> options) : base(options)
		{

		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
              .UseLoggerFactory(_logger);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<MPaymentMethod>();

            modelBuilder
              .Entity<MEvent>();

            modelBuilder
              .Entity<MStaff>();

            modelBuilder
              .Entity<MPatientFileBin>();

            modelBuilder
              .Entity<MCompany>();

            modelBuilder
              .Entity<MPatientFileGroup>();

            modelBuilder
              .Entity<MPatientFileType>();

            modelBuilder
              .Entity<MPatientFileLocate>();

            modelBuilder
              .Entity<MAppointment>();

            modelBuilder
              .Entity<MPatientFile>();

            modelBuilder
            .Entity<MPatientInfo>(
              b => {
                  b.Ignore(e => e.PAYMENT_METHOD_ENAME);
              }
            );

            modelBuilder.Entity<TVoucher>();



            // custom model that not exist in db
            modelBuilder.Entity<InventoryItemSummaryModel>().HasNoKey();

            modelBuilder.Entity<InventoryTransList>().HasNoKey();
        }

    }
}


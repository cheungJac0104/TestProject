using Microsoft.EntityFrameworkCore;
using TestProject.Models;
using TestProject.Models.v1;

namespace TestProject.Context
{
    //DB Context
    public class AppDBContext : DbContext
    {
        static readonly ILoggerFactory _logger = LoggerFactory.Create(builder => { builder.AddConsole(); });

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

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
              .UseLoggerFactory(_logger);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder
            .Entity<MPaymentMethod>(
              b => {
                b.Property(e => e.CREATEDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.MODIFYDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.DIS_SEQ).HasConversion(
                  v => Int16.Parse(v),
                  v => v.ToString()
                );
              }
            );

          modelBuilder
            .Entity<MEvent>(
              b => {
                b.Property(e => e.CREATEDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.MODIFYDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
              }
            );

          modelBuilder
            .Entity<MStaff>(
              b => {
                b.Property(e => e.CREATEDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.MODIFYDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
              }
            );

          modelBuilder
            .Entity<MPatientFileBin>(
              b => {
                b.Property(e => e.CREATEDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.MODIFYDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
              }
            );

          modelBuilder
            .Entity<MCompany>(
              b => {
                b.Property(e => e.CREATEDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.MODIFYDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
              }
            );
          
          modelBuilder
            .Entity<MPatientFileGroup>(
              b => {
                b.Property(e => e.CREATEDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.MODIFYDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
              }
            );

          modelBuilder
            .Entity<MPatientFileType>(
              b => {
                b.Property(e => e.CREATEDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.MODIFYDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
              }
            );

          modelBuilder
            .Entity<MPatientFileLocate>(
              b => {
                b.Property(e => e.CREATEDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.MODIFYDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                // b.Property(e => e.FILE_DATE).HasConversion(
                //   v => DateTime.Parse(v),
                //   v => v.ToString()
                // );
              }
            );

          modelBuilder
            .Entity<MAppointment>(
              b => {
                b.Property(e => e.CREATEDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.MODIFYDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                // b.Property(e => e.APP_DATETIME).HasConversion(
                //   v => DateTime.Parse(v),
                //   v => v.ToString()
                // );
                b.Property(e => e.ARR_DATETIME).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
              }
            );

          modelBuilder
            .Entity<MPatientFile>(
              b => {
                b.Property(e => e.CREATEDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.MODIFYDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.DATE_UPLOADED).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.DATE_MODIFIED).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
              }
            );

            modelBuilder
            .Entity<MPatientInfo>(
              b => {
                b.Property(e => e.CREATEDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.MODIFYDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.DOB).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.REG_DATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                  b.Ignore(e => e.PAYMENT_METHOD_ENAME);
              }
            );

            modelBuilder.Entity<TVoucher>(
              b =>{
                b.Property(e => e.CREATEDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.MODIFYDATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
                b.Property(e => e.VOUCHER_DATE).HasConversion(
                  v => DateTime.Parse(v),
                  v => v.ToString()
                );
              }
            );



            // custom model that not exist in db
            modelBuilder.Entity<InventoryItemSummaryModel>().HasNoKey();

            modelBuilder.Entity<InventoryTransList>().HasNoKey();


        }
    }
}






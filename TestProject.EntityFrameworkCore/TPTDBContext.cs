using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.EntityFrameworkCore.Domain;
using TestProject.Infrastructure;

namespace TestProject.EntityFrameworkCore
{
    public class TPTDBContext : DbContext
    {
        private AppSetting _appSetting;
        public TPTDBContext(DbContextOptions<TPTDBContext> options, IOptions<AppSetting> appSetting) : base(options)
        {
            _appSetting = appSetting.Value;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DataPrivilegeRule>()
            //    .HasKey(c => new { c.Id });
        }

        #region 日志

        public DbSet<ErrorLog> ErrorLogSet { get; set; }
        public DbSet<SysLog> SysLogSet { get; set; }
        #endregion
        #region Account, Permission
        public DbSet<LoginAccount> LoginAccountSet { get; set; }
        public DbSet<UserInfo> UserInfoSet { get; set; }
        #endregion


    }
}

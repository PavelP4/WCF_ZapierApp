using System;
using System.Collections.Generic;
using System.Data.Entity;
using ZapService.DataAccess.DataModel;

namespace ZapService.DataAccess
{
    public class DBZapService: DbContext
    {
        public DBZapService()
            : base("DBZapService")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DBZapService, ZapService.DataAccess.Migrations.Configuration>("DBZapService"));
        }

        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }        
    }
}

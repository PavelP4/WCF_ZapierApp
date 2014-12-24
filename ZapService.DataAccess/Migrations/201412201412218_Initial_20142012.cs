namespace ZapService.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_20142012 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Account_Name = c.String(nullable: false, maxLength: 100),
                        Target_URL = c.String(nullable: false, maxLength: 4000),
                        Event = c.String(nullable: false, maxLength: 50),
                        IsUnsubscribed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscribes");
        }
    }
}

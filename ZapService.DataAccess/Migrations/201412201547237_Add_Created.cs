namespace ZapService.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Created : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscribes", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscribes", "Created");
        }
    }
}

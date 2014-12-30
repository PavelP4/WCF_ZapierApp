namespace ZapService.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Subscribe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscribes", "Subscription_URL", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Subscribes", "Event", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscribes", "Event", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Subscribes", "Subscription_URL");
        }
    }
}

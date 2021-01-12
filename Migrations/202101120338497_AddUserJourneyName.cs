namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserJourneyName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserJourneys", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserJourneys", "Name");
        }
    }
}

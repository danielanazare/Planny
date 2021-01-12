namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescripionUSerJourney : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserJourneys", "Description", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserJourneys", "Description");
        }
    }
}

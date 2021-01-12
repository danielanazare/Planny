namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSprintName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sprints", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sprints", "Name");
        }
    }
}

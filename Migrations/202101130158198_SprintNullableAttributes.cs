namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintNullableAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sprints", "Effort", c => c.Int());
            AlterColumn("dbo.Sprints", "TimeSpent", c => c.Int());
            AlterColumn("dbo.Sprints", "Progress", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sprints", "Progress", c => c.Byte(nullable: false));
            AlterColumn("dbo.Sprints", "TimeSpent", c => c.Int(nullable: false));
            AlterColumn("dbo.Sprints", "Effort", c => c.Int(nullable: false));
        }
    }
}

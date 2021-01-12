namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaskName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectTasks", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectTasks", "Name");
        }
    }
}

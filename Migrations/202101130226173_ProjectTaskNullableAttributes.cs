namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectTaskNullableAttributes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectTasks", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.ProjectTasks", "StatusId", "dbo.Status");
            DropIndex("dbo.ProjectTasks", new[] { "StatusId" });
            DropIndex("dbo.ProjectTasks", new[] { "PriorityId" });
            AlterColumn("dbo.ProjectTasks", "StatusId", c => c.Int());
            AlterColumn("dbo.ProjectTasks", "PriorityId", c => c.Int());
            CreateIndex("dbo.ProjectTasks", "StatusId");
            CreateIndex("dbo.ProjectTasks", "PriorityId");
            AddForeignKey("dbo.ProjectTasks", "PriorityId", "dbo.Priorities", "Id");
            AddForeignKey("dbo.ProjectTasks", "StatusId", "dbo.Status", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTasks", "StatusId", "dbo.Status");
            DropForeignKey("dbo.ProjectTasks", "PriorityId", "dbo.Priorities");
            DropIndex("dbo.ProjectTasks", new[] { "PriorityId" });
            DropIndex("dbo.ProjectTasks", new[] { "StatusId" });
            AlterColumn("dbo.ProjectTasks", "PriorityId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProjectTasks", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectTasks", "PriorityId");
            CreateIndex("dbo.ProjectTasks", "StatusId");
            AddForeignKey("dbo.ProjectTasks", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProjectTasks", "PriorityId", "dbo.Priorities", "Id", cascadeDelete: true);
        }
    }
}

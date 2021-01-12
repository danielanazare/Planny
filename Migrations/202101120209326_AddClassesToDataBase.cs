namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassesToDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserJourneyId = c.Int(nullable: false),
                        Description = c.String(),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.UserJourneys", t => t.UserJourneyId, cascadeDelete: true)
                .Index(t => t.UserJourneyId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId);
            
            CreateTable(
                "dbo.UserJourneys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SprintId = c.Int(nullable: false),
                        Description = c.String(),
                        StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sprints", t => t.SprintId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.SprintId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Sprints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReleaseId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Effort = c.Int(nullable: false),
                        TimeSpent = c.Int(nullable: false),
                        Progress = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Releases", t => t.ReleaseId, cascadeDelete: true)
                .Index(t => t.ReleaseId);
            
            CreateTable(
                "dbo.Releases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Effort = c.Int(nullable: false),
                        TimeSpent = c.Int(nullable: false),
                        Progress = c.Byte(nullable: false),
                        ProjectId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId_Id)
                .Index(t => t.ProjectId_Id);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        TimeSpent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectTasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Times", "TaskId", "dbo.ProjectTasks");
            DropForeignKey("dbo.ProjectTasks", "UserJourneyId", "dbo.UserJourneys");
            DropForeignKey("dbo.UserJourneys", "StatusId", "dbo.Status");
            DropForeignKey("dbo.UserJourneys", "SprintId", "dbo.Sprints");
            DropForeignKey("dbo.Sprints", "ReleaseId", "dbo.Releases");
            DropForeignKey("dbo.Releases", "ProjectId_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectTasks", "StatusId", "dbo.Status");
            DropForeignKey("dbo.ProjectTasks", "PriorityId", "dbo.Priorities");
            DropIndex("dbo.Times", new[] { "TaskId" });
            DropIndex("dbo.Releases", new[] { "ProjectId_Id" });
            DropIndex("dbo.Sprints", new[] { "ReleaseId" });
            DropIndex("dbo.UserJourneys", new[] { "StatusId" });
            DropIndex("dbo.UserJourneys", new[] { "SprintId" });
            DropIndex("dbo.ProjectTasks", new[] { "PriorityId" });
            DropIndex("dbo.ProjectTasks", new[] { "StatusId" });
            DropIndex("dbo.ProjectTasks", new[] { "UserJourneyId" });
            DropTable("dbo.Times");
            DropTable("dbo.Releases");
            DropTable("dbo.Sprints");
            DropTable("dbo.UserJourneys");
            DropTable("dbo.ProjectTasks");
            DropTable("dbo.Priorities");
        }
    }
}

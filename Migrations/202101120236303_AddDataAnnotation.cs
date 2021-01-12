namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Releases", "ProjectId_Id", "dbo.Projects");
            DropIndex("dbo.Releases", new[] { "ProjectId_Id" });
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ProjectTasks", "Description", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Status", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Releases", "ProjectId_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Times", "Description", c => c.String(nullable: false, maxLength: 500));
            CreateIndex("dbo.Releases", "ProjectId_Id");
            AddForeignKey("dbo.Releases", "ProjectId_Id", "dbo.Projects", "Id", cascadeDelete: true);
            DropColumn("dbo.UserJourneys", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserJourneys", "Description", c => c.String());
            DropForeignKey("dbo.Releases", "ProjectId_Id", "dbo.Projects");
            DropIndex("dbo.Releases", new[] { "ProjectId_Id" });
            AlterColumn("dbo.Times", "Description", c => c.String());
            AlterColumn("dbo.Releases", "ProjectId_Id", c => c.Int());
            AlterColumn("dbo.Status", "Name", c => c.String());
            AlterColumn("dbo.ProjectTasks", "Description", c => c.String());
            AlterColumn("dbo.Projects", "Name", c => c.String());
            CreateIndex("dbo.Releases", "ProjectId_Id");
            AddForeignKey("dbo.Releases", "ProjectId_Id", "dbo.Projects", "Id");
        }
    }
}

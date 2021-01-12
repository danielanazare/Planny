namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassesToDataBase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserJourneys", "PriorityId", c => c.Int());
            CreateIndex("dbo.UserJourneys", "PriorityId");
            AddForeignKey("dbo.UserJourneys", "PriorityId", "dbo.Priorities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserJourneys", "PriorityId", "dbo.Priorities");
            DropIndex("dbo.UserJourneys", new[] { "PriorityId" });
            DropColumn("dbo.UserJourneys", "PriorityId");
        }
    }
}

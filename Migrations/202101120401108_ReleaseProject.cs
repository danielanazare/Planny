namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReleaseProject : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Releases", name: "ProjectId_Id", newName: "ProjectId");
            RenameIndex(table: "dbo.Releases", name: "IX_ProjectId_Id", newName: "IX_ProjectId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Releases", name: "IX_ProjectId", newName: "IX_ProjectId_Id");
            RenameColumn(table: "dbo.Releases", name: "ProjectId", newName: "ProjectId_Id");
        }
    }
}

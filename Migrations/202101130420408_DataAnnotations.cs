namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Priorities", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Status", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Status", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Priorities", "Name", c => c.String(nullable: false));
        }
    }
}

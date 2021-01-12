namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReleaseName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Releases", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Releases", "Name");
        }
    }
}

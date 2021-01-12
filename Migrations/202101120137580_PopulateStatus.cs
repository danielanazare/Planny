namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Status(Name) " +
                "Values('Open')," + 
                "('In Progress')," +
                "('Done')");
        }
        
        public override void Down()
        {
        }
    }
}

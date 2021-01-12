namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePriorities : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Priorities(Name)" +
                "VALUES('Low')," +
                "('Normal')," +
                "('High')");
        }
        
        public override void Down()
        {
        }
    }
}

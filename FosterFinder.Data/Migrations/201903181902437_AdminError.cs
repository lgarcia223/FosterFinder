namespace FosterFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminError : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Child", "ModifiedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Child", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
    }
}

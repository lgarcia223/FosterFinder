namespace FosterFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoUrlforChild : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Child", "PhotoUrl", c => c.String());
            AddColumn("dbo.Child", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Child", "ModifiedUtc");
            DropColumn("dbo.Child", "PhotoUrl");
        }
    }
}

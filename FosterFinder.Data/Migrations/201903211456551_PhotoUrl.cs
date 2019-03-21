namespace FosterFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FosterHome", "PhotoUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FosterHome", "PhotoUrl");
        }
    }
}

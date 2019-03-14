namespace FosterFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CaseworkerInfoAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Child", "CaseworkerName", c => c.String());
            AddColumn("dbo.Child", "CaseworkerContact", c => c.String());
            AddColumn("dbo.FosterHome", "Agency", c => c.String());
            AddColumn("dbo.FosterHome", "CaseworkerName", c => c.String());
            AddColumn("dbo.FosterHome", "CaseworkerContact", c => c.String());
            AlterColumn("dbo.FosterHome", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FosterHome", "Comments", c => c.String(maxLength: 200));
            DropColumn("dbo.FosterHome", "CaseworkerContact");
            DropColumn("dbo.FosterHome", "CaseworkerName");
            DropColumn("dbo.FosterHome", "Agency");
            DropColumn("dbo.Child", "CaseworkerContact");
            DropColumn("dbo.Child", "CaseworkerName");
        }
    }
}

namespace GearHunter.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsActivesoitispossibletodeactivatestuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Advertisements", "IsActive");
        }
    }
}

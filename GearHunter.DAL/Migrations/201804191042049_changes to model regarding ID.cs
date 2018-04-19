namespace GearHunter.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changestomodelregardingID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "isValidated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "isValidated", c => c.Boolean());
        }
    }
}

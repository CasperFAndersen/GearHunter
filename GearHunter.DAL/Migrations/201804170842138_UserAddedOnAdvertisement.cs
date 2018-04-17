namespace GearHunter.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddedOnAdvertisement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "User_Id", c => c.Int());
            CreateIndex("dbo.Advertisements", "User_Id");
            AddForeignKey("dbo.Advertisements", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertisements", "User_Id", "dbo.Users");
            DropIndex("dbo.Advertisements", new[] { "User_Id" });
            DropColumn("dbo.Advertisements", "User_Id");
        }
    }
}

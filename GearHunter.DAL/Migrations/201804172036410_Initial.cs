namespace GearHunter.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatchyHeader = c.String(),
                        Brand = c.String(),
                        Model = c.String(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        Address = c.String(),
                        Zip = c.String(),
                        City = c.String(),
                        IsDeliverable = c.Boolean(nullable: false),
                        IsRentable = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                        Category_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Filename = c.String(),
                        Advertisement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertisements", t => t.Advertisement_Id)
                .Index(t => t.Advertisement_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Zip = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CVR = c.String(),
                        IsValidated = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertisements", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Photos", "Advertisement_Id", "dbo.Advertisements");
            DropForeignKey("dbo.Advertisements", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Photos", new[] { "Advertisement_Id" });
            DropIndex("dbo.Advertisements", new[] { "User_Id" });
            DropIndex("dbo.Advertisements", new[] { "Category_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Photos");
            DropTable("dbo.Categories");
            DropTable("dbo.Advertisements");
        }
    }
}

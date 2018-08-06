namespace BuynSell.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inheritance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 200),
                        Image = c.Binary(),
                        PostedDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        ClientID = c.Guid(nullable: false),
                        IsSold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        EmployeeNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "ID", "dbo.Users");
            DropForeignKey("dbo.Admins", "ID", "dbo.Users");
            DropForeignKey("dbo.Items", "ClientID", "dbo.Clients");
            DropIndex("dbo.Clients", new[] { "ID" });
            DropIndex("dbo.Admins", new[] { "ID" });
            DropIndex("dbo.Items", new[] { "ClientID" });
            DropTable("dbo.Clients");
            DropTable("dbo.Admins");
            DropTable("dbo.Items");
            DropTable("dbo.Users");
        }
    }
}

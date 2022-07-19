namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Customer_Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Watch_Show_Id = c.Byte(),
                        Watching_Show_Id = c.Byte(),
                        WishList_Show_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Customer_Id)
                .ForeignKey("dbo.Watcheds", t => t.Watch_Show_Id)
                .ForeignKey("dbo.Watchings", t => t.Watching_Show_Id)
                .ForeignKey("dbo.WhishLists", t => t.WishList_Show_Id)
                .Index(t => t.Watch_Show_Id)
                .Index(t => t.Watching_Show_Id)
                .Index(t => t.WishList_Show_Id);
            
            CreateTable(
                "dbo.Watcheds",
                c => new
                    {
                        Show_Id = c.Byte(nullable: false),
                        Customer_Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Duration = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Show_Id);
            
            CreateTable(
                "dbo.Watchings",
                c => new
                    {
                        Show_Id = c.Byte(nullable: false),
                        Customer_Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Duration = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Show_Id);
            
            CreateTable(
                "dbo.WhishLists",
                c => new
                    {
                        Show_Id = c.Byte(nullable: false),
                        Customer_Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Duration = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Show_Id);
            
            CreateTable(
                "dbo.TvShows",
                c => new
                    {
                        Show_Id = c.Byte(nullable: false),
                        Customer_id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Show_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "WishList_Show_Id", "dbo.WhishLists");
            DropForeignKey("dbo.Customers", "Watching_Show_Id", "dbo.Watchings");
            DropForeignKey("dbo.Customers", "Watch_Show_Id", "dbo.Watcheds");
            DropIndex("dbo.Customers", new[] { "WishList_Show_Id" });
            DropIndex("dbo.Customers", new[] { "Watching_Show_Id" });
            DropIndex("dbo.Customers", new[] { "Watch_Show_Id" });
            DropTable("dbo.TvShows");
            DropTable("dbo.WhishLists");
            DropTable("dbo.Watchings");
            DropTable("dbo.Watcheds");
            DropTable("dbo.Customers");
        }
    }
}

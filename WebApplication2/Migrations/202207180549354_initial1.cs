namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TvShows", "Customer_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TvShows", "Customer_id", c => c.Byte(nullable: false));
        }
    }
}

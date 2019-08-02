namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserIdInCarModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Cars", new[] { "CustomerId" });
            AddColumn("dbo.Cars", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cars", "UserId");
            AddForeignKey("dbo.Cars", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Cars", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cars", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cars", new[] { "UserId" });
            DropColumn("dbo.Cars", "UserId");
            CreateIndex("dbo.Cars", "CustomerId");
            AddForeignKey("dbo.Cars", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}

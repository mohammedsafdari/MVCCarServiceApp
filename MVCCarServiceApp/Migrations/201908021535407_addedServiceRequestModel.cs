namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedServiceRequestModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Miles = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Details = c.String(nullable: false),
                        ServiceType = c.String(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRequests", "CarId", "dbo.Cars");
            DropIndex("dbo.ServiceRequests", new[] { "CarId" });
            DropTable("dbo.ServiceRequests");
        }
    }
}

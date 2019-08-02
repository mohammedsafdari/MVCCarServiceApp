namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedCarServiceModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarServices", "ServiceTypeId", "dbo.ServiceTypes");
            DropIndex("dbo.CarServices", new[] { "ServiceTypeId" });
            AddColumn("dbo.CarServices", "ServiceType", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false));
            DropColumn("dbo.CarServices", "ServiceTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarServices", "ServiceTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "City", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 20));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 20));
            DropColumn("dbo.CarServices", "ServiceType");
            CreateIndex("dbo.CarServices", "ServiceTypeId");
            AddForeignKey("dbo.CarServices", "ServiceTypeId", "dbo.ServiceTypes", "Id", cascadeDelete: true);
        }
    }
}

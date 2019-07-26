namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedServiceTypeForeignKeyToCarServiceModel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CarServices", "ServiceTypeId");
            AddForeignKey("dbo.CarServices", "ServiceTypeId", "dbo.ServiceTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarServices", "ServiceTypeId", "dbo.ServiceTypes");
            DropIndex("dbo.CarServices", new[] { "ServiceTypeId" });
        }
    }
}

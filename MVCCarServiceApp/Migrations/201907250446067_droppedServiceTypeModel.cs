namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droppedServiceTypeModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarServices", "ServiceTypeId", "dbo.ServiceTypes");
            DropIndex("dbo.CarServices", new[] { "ServiceTypeId" });
            DropTable("dbo.ServiceTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.CarServices", "ServiceTypeId");
            AddForeignKey("dbo.CarServices", "ServiceTypeId", "dbo.ServiceTypes", "Id", cascadeDelete: true);
        }
    }
}

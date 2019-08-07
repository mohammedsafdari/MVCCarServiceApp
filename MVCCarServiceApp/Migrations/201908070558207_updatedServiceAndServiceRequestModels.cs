namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedServiceAndServiceRequestModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarServices", "ServiceDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ServiceRequests", "ServiceDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceRequests", "ServiceDate");
            DropColumn("dbo.CarServices", "ServiceDate");
        }
    }
}

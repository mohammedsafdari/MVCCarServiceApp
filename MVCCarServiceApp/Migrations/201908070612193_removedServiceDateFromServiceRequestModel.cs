namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedServiceDateFromServiceRequestModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ServiceRequests", "ServiceDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceRequests", "ServiceDate", c => c.DateTime(nullable: false));
        }
    }
}

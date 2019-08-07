namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRejectionMessageToServiceRequestModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRequests", "RejectionMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceRequests", "RejectionMessage");
        }
    }
}

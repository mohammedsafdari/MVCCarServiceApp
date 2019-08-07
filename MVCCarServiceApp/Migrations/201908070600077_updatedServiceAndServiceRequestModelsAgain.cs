namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedServiceAndServiceRequestModelsAgain : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CarServices", "ServiceDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarServices", "ServiceDate", c => c.DateTime(nullable: false));
        }
    }
}

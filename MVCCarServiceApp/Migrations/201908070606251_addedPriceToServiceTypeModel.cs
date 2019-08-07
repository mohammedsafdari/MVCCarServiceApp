namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPriceToServiceTypeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceTypes", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceTypes", "Price");
        }
    }
}

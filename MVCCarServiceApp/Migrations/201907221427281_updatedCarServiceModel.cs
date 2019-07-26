namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedCarServiceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarServices", "ServiceType", c => c.Int(nullable: false));
            DropColumn("dbo.CarServices", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarServices", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.CarServices", "ServiceType");
        }
    }
}

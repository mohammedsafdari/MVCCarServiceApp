namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropServiceTypeColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CarServices", "ServiceType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarServices", "ServiceType", c => c.Int(nullable: false));
        }
    }
}

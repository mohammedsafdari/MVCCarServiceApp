namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedCarServiceModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarServices", "ServiceTypeId", c => c.Int(nullable: false));
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarServices", "ServiceTypeId");
        }
    }
}

namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedServiceTypeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceTypes", "Description", c => c.String(nullable: false));
            AddColumn("dbo.ServiceTypes", "Keyword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceTypes", "Keyword");
            DropColumn("dbo.ServiceTypes", "Description");
        }
    }
}

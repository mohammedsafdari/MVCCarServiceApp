namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarMakes", "Make", c => c.String(nullable: false));
            //AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            //AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.CarServices", "ServiceType", c => c.String(nullable: false));
            AlterColumn("dbo.CarStyles", "Style", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceTypes", "ServiceName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceTypes", "ServiceName", c => c.String());
            AlterColumn("dbo.CarStyles", "Style", c => c.String());
            AlterColumn("dbo.CarServices", "ServiceType", c => c.String());
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.CarMakes", "Make", c => c.String());
        }
    }
}

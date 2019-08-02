namespace MVCCarServiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMakeAndStyleModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarMakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarStyles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Style = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Cars", "Make", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Style", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Style", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Make", c => c.Int(nullable: false));
            DropTable("dbo.CarStyles");
            DropTable("dbo.CarMakes");
        }
    }
}

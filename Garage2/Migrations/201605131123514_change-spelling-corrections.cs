namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changespellingcorrections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "VehicleType", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String(nullable: false));
            DropColumn("dbo.Vehicles", "VehicleTypes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "VehicleTypes", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String());
            DropColumn("dbo.Vehicles", "VehicleType");
        }
    }
}

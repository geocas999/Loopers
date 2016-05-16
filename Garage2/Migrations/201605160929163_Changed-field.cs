namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedfield : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "TotalTime", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "TotalTime", c => c.DateTime());
        }
    }
}

namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewfieldtodbTotalTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "TotalTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "TotalTime");
        }
    }
}

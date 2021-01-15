namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateCalibration_Type : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeCalibrations", "DateCalibration", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeCalibrations", "DateCalibration");
        }
    }
}

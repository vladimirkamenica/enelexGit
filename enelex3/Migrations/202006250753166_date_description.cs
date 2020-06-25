namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date_description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaveMeasures", "Description", c => c.String());
            AddColumn("dbo.SaveMeasures", "DateOfCalibration", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SaveMeasures", "DateOfCalibration");
            DropColumn("dbo.SaveMeasures", "Description");
        }
    }
}

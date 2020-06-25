namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_Name : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Calibrations", newName: "NewCalibrations");
            RenameTable(name: "dbo.CalibrationThrees", newName: "ValueOfProportions");
            RenameTable(name: "dbo.CalibrationTwoes", newName: "CalibrationAbsoluteShiftings");
            RenameTable(name: "dbo.CalibratonOnes", newName: "CalibrationProportionShiftings");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CalibrationProportionShiftings", newName: "CalibratonOnes");
            RenameTable(name: "dbo.CalibrationAbsoluteShiftings", newName: "CalibrationTwoes");
            RenameTable(name: "dbo.ValueOfProportions", newName: "CalibrationThrees");
            RenameTable(name: "dbo.NewCalibrations", newName: "Calibrations");
        }
    }
}

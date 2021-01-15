namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_date_number : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainTables", "DateRecords", c => c.DateTime(nullable: false));
            AddColumn("dbo.TrainTables", "NumberTrain", c => c.Int(nullable: false));
            DropColumn("dbo.TrainTables", "DateResords");
            DropColumn("dbo.TrainTables", "NumberTraun");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrainTables", "NumberTraun", c => c.Int(nullable: false));
            AddColumn("dbo.TrainTables", "DateResords", c => c.DateTime(nullable: false));
            DropColumn("dbo.TrainTables", "NumberTrain");
            DropColumn("dbo.TrainTables", "DateRecords");
        }
    }
}

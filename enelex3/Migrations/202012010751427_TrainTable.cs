namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrainTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateResords = c.DateTime(nullable: false),
                        NumberTraun = c.Int(nullable: false),
                        MoistureLabTam = c.Double(nullable: false),
                        MoistureLabTent = c.Double(nullable: false),
                        Moisture = c.Double(nullable: false),
                        AshLabTam = c.Double(nullable: false),
                        AshLabTent = c.Double(nullable: false),
                        AshGE = c.Double(nullable: false),
                        CalorificLabTam = c.Double(nullable: false),
                        CalorificLabTent = c.Double(nullable: false),
                        CalorificGE = c.Double(nullable: false),
                        ShiftWork = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrainTables");
        }
    }
}

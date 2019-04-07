namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kalibracija_cetvrta_ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalibrationThrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberAThree = c.Double(nullable: false),
                        NumberBThree = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CalibrationThrees");
        }
    }
}

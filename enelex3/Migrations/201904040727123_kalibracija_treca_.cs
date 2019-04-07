namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kalibracija_treca_ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalibrationTwoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberATwo = c.Double(nullable: false),
                        NumberBTwo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CalibrationTwoes");
        }
    }
}

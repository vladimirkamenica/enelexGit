namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kalibracija_procenat_ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Percentages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberP = c.Double(nullable: false),
                        PercentageN = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Percentages");
        }
    }
}

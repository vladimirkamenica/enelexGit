namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _kalibracija_prva_ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calibrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberA = c.Double(nullable: false),
                        NumberB = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Calibrations");
        }
    }
}

namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _druga_kalibracija : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalibratonOnes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        L = c.Double(nullable: false),
                        P = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CalibratonOnes");
        }
    }
}

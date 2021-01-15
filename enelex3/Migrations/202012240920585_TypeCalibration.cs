namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeCalibration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeCalibrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                        ValueA = c.Double(nullable: false),
                        ValueB = c.Double(nullable: false),
                        ValueW = c.Double(nullable: false),
                        ValueP1 = c.Double(nullable: false),
                        ValueQ1 = c.Double(nullable: false),
                        ValueR1 = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        LastOnUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TypeCalibrations");
        }
    }
}

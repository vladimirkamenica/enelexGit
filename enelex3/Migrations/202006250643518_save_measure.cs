namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class save_measure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaveMeasures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ge = c.Double(nullable: false),
                        Lab = c.Double(nullable: false),
                        W = c.Double(nullable: false),
                        Save = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SaveMeasures");
        }
    }
}

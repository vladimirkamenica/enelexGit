namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class measureUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Measures",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        IdSort = c.Int(nullable: false),
                        Ge = c.Double(nullable: false),
                        Lab = c.Double(nullable: false),
                        IndexId = c.Double(nullable: false),
                        P = c.Double(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);            
        }
        
        public override void Down()
        {        
           
            DropTable("dbo.Measures");
        }
    }
}

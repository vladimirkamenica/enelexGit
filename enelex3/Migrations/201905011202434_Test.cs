namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Measures", "CreationUserID", c => c.Long(nullable: false));
            AddColumn("dbo.Measures", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Measures", "UpdateUserID", c => c.Long(nullable: false));
            AddColumn("dbo.Measures", "UpdateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Measures", "UpdateDate");
            DropColumn("dbo.Measures", "UpdateUserID");
            DropColumn("dbo.Measures", "CreationDate");
            DropColumn("dbo.Measures", "CreationUserID");
        }
    }
}

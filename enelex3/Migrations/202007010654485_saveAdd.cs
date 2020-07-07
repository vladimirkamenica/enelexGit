namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saveAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaveMeasures", "P", c => c.Double(nullable: false));
            AddColumn("dbo.SaveMeasures", "Q", c => c.Double(nullable: false));
            AddColumn("dbo.SaveMeasures", "Shifting", c => c.Double(nullable: false));
            AddColumn("dbo.SaveMeasures", "ShiftingProportionP", c => c.Double(nullable: false));
            AddColumn("dbo.SaveMeasures", "ShiftingProportionQ", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SaveMeasures", "ShiftingProportionQ");
            DropColumn("dbo.SaveMeasures", "ShiftingProportionP");
            DropColumn("dbo.SaveMeasures", "Shifting");
            DropColumn("dbo.SaveMeasures", "Q");
            DropColumn("dbo.SaveMeasures", "P");
        }
    }
}

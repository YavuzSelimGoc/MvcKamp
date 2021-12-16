namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addskill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkilID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SkillPercentage = c.String(),
                    })
                .PrimaryKey(t => t.SkilID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
        }
    }
}

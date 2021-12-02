namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Concents", "WriterID", c => c.Int());
            CreateIndex("dbo.Concents", "WriterID");
            AddForeignKey("dbo.Concents", "WriterID", "dbo.Writers", "WriterID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Concents", "WriterID", "dbo.Writers");
            DropIndex("dbo.Concents", new[] { "WriterID" });
            DropColumn("dbo.Concents", "WriterID");
        }
    }
}

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.User", "Email", unique: true);
            CreateIndex("dbo.User", "AadharNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "AadharNumber" });
            DropIndex("dbo.User", new[] { "Email" });
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
        }
    }
}

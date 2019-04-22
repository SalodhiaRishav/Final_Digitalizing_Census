namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HouseMember",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        RelationToHead = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        OccupationStatus = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                        AgeAtMarriage = c.Int(),
                        OccupationNature = c.Int(nullable: false),
                        VolunteerId = c.Int(nullable: false),
                        HouseId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.House", t => t.HouseId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.VolunteerId, cascadeDelete: true)
                .Index(t => t.VolunteerId)
                .Index(t => t.HouseId);
            
            CreateTable(
                "dbo.House",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BuildingNumber = c.String(nullable: false),
                        StreetName = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        HeadName = c.String(nullable: false),
                        OwnershipStatus = c.Int(nullable: false),
                        NumberOfRooms = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ProfileImage = c.String(nullable: false),
                        AadharNumber = c.String(nullable: false, maxLength: 12),
                        IsApprover = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserCurrentRequestStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserRequestType = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCurrentRequestStatus", "UserId", "dbo.User");
            DropForeignKey("dbo.HouseMember", "VolunteerId", "dbo.User");
            DropForeignKey("dbo.HouseMember", "HouseId", "dbo.House");
            DropIndex("dbo.UserCurrentRequestStatus", new[] { "UserId" });
            DropIndex("dbo.HouseMember", new[] { "HouseId" });
            DropIndex("dbo.HouseMember", new[] { "VolunteerId" });
            DropTable("dbo.UserCurrentRequestStatus");
            DropTable("dbo.User");
            DropTable("dbo.House");
            DropTable("dbo.HouseMember");
        }
    }
}

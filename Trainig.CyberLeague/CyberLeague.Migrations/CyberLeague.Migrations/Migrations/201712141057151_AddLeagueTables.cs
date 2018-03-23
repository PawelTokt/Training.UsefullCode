namespace CyberLeague.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeagueTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "League.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Nickname = c.String(),
                        Surname = c.String(),
                        PositionEntityId = c.Int(nullable: false),
                        TeamEntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("League.Positions", t => t.PositionEntityId, cascadeDelete: true)
                .ForeignKey("League.Teams", t => t.TeamEntityId, cascadeDelete: true)
                .Index(t => t.PositionEntityId)
                .Index(t => t.TeamEntityId);
            
            CreateTable(
                "League.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        KillСoefficient = c.Int(nullable: false),
                        AssistlСoefficient = c.Int(nullable: false),
                        DeathlСoefficient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "League.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Region = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("League.Players", "TeamEntityId", "League.Teams");
            DropForeignKey("League.Players", "PositionEntityId", "League.Positions");
            DropIndex("League.Players", new[] { "TeamEntityId" });
            DropIndex("League.Players", new[] { "PositionEntityId" });
            DropTable("League.Teams");
            DropTable("League.Positions");
            DropTable("League.Players");
        }
    }
}

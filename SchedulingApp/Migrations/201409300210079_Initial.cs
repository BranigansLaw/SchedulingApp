namespace App.SchedulingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        AccessCode = c.String(),
                        ForEvent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.ForEvent_Id)
                .Index(t => t.ForEvent_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.String(),
                        CommentBy_Id = c.Guid(),
                        ForEvent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attendees", t => t.CommentBy_Id)
                .ForeignKey("dbo.Events", t => t.ForEvent_Id)
                .Index(t => t.CommentBy_Id)
                .Index(t => t.ForEvent_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Selected = c.Boolean(nullable: false),
                        ForEvent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.ForEvent_Id)
                .Index(t => t.ForEvent_Id);
            
            CreateTable(
                "dbo.LocationVotes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VotedOn_Id = c.Guid(),
                        Voter_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.VotedOn_Id)
                .ForeignKey("dbo.Attendees", t => t.Voter_Id)
                .Index(t => t.VotedOn_Id)
                .Index(t => t.Voter_Id);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.DateTime(nullable: false),
                        Selected = c.Boolean(nullable: false),
                        ForEvent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.ForEvent_Id)
                .Index(t => t.ForEvent_Id);
            
            CreateTable(
                "dbo.TimeVotes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VotedOn_Id = c.Guid(),
                        Voter_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Times", t => t.VotedOn_Id)
                .ForeignKey("dbo.Attendees", t => t.Voter_Id)
                .Index(t => t.VotedOn_Id)
                .Index(t => t.Voter_Id);
            
            DropTable("dbo.Schedules");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.TimeVotes", "Voter_Id", "dbo.Attendees");
            DropForeignKey("dbo.TimeVotes", "VotedOn_Id", "dbo.Times");
            DropForeignKey("dbo.Times", "ForEvent_Id", "dbo.Events");
            DropForeignKey("dbo.LocationVotes", "Voter_Id", "dbo.Attendees");
            DropForeignKey("dbo.LocationVotes", "VotedOn_Id", "dbo.Locations");
            DropForeignKey("dbo.Locations", "ForEvent_Id", "dbo.Events");
            DropForeignKey("dbo.Comments", "ForEvent_Id", "dbo.Events");
            DropForeignKey("dbo.Comments", "CommentBy_Id", "dbo.Attendees");
            DropForeignKey("dbo.Attendees", "ForEvent_Id", "dbo.Events");
            DropIndex("dbo.TimeVotes", new[] { "Voter_Id" });
            DropIndex("dbo.TimeVotes", new[] { "VotedOn_Id" });
            DropIndex("dbo.Times", new[] { "ForEvent_Id" });
            DropIndex("dbo.LocationVotes", new[] { "Voter_Id" });
            DropIndex("dbo.LocationVotes", new[] { "VotedOn_Id" });
            DropIndex("dbo.Locations", new[] { "ForEvent_Id" });
            DropIndex("dbo.Comments", new[] { "ForEvent_Id" });
            DropIndex("dbo.Comments", new[] { "CommentBy_Id" });
            DropIndex("dbo.Attendees", new[] { "ForEvent_Id" });
            DropTable("dbo.TimeVotes");
            DropTable("dbo.Times");
            DropTable("dbo.LocationVotes");
            DropTable("dbo.Locations");
            DropTable("dbo.Comments");
            DropTable("dbo.Attendees");
            DropTable("dbo.Events");
        }
    }
}

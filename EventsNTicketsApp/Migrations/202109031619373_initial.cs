namespace EventsNTicketsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Price = c.Single(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Artist_ArtistId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistId)
                .Index(t => t.Artist_ArtistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Artist_ArtistId", "dbo.Artists");
            DropIndex("dbo.Events", new[] { "Artist_ArtistId" });
            DropTable("dbo.Events");
            DropTable("dbo.Artists");
        }
    }
}

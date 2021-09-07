namespace EventsNTicketsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedArtistId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Artist_ArtistId", "dbo.Artists");
            DropIndex("dbo.Events", new[] { "Artist_ArtistId" });
            RenameColumn(table: "dbo.Events", name: "Artist_ArtistId", newName: "ArtistId");
            AlterColumn("dbo.Events", "ArtistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "ArtistId");
            AddForeignKey("dbo.Events", "ArtistId", "dbo.Artists", "ArtistId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Events", new[] { "ArtistId" });
            AlterColumn("dbo.Events", "ArtistId", c => c.Int());
            RenameColumn(table: "dbo.Events", name: "ArtistId", newName: "Artist_ArtistId");
            CreateIndex("dbo.Events", "Artist_ArtistId");
            AddForeignKey("dbo.Events", "Artist_ArtistId", "dbo.Artists", "ArtistId");
        }
    }
}

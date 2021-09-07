namespace EventsNTicketsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedInArtist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "VideoId", c => c.String());
            AddColumn("dbo.Artists", "Bio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Bio");
            DropColumn("dbo.Artists", "VideoId");
        }
    }
}

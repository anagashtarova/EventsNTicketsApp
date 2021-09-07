namespace EventsNTicketsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTicketSeats : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Tickets", new[] { "Event_EventId" });
            RenameColumn(table: "dbo.Tickets", name: "Event_EventId", newName: "EventId");
            AlterColumn("dbo.Tickets", "EventId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "EventId");
            AddForeignKey("dbo.Tickets", "EventId", "dbo.Events", "EventId", cascadeDelete: true);
            DropColumn("dbo.Tickets", "Price");
            DropColumn("dbo.Tickets", "Row");
            DropColumn("dbo.Tickets", "SeatNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "SeatNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Row", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Price", c => c.Single(nullable: false));
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropIndex("dbo.Tickets", new[] { "EventId" });
            AlterColumn("dbo.Tickets", "EventId", c => c.Int());
            RenameColumn(table: "dbo.Tickets", name: "EventId", newName: "Event_EventId");
            CreateIndex("dbo.Tickets", "Event_EventId");
            AddForeignKey("dbo.Tickets", "Event_EventId", "dbo.Events", "EventId");
        }
    }
}

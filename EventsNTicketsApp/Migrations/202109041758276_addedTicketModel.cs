namespace EventsNTicketsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTicketModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Type = c.String(),
                        Block = c.String(),
                        Row = c.Int(nullable: false),
                        SeatNumber = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .Index(t => t.Event_EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Tickets", new[] { "Event_EventId" });
            DropTable("dbo.Tickets");
        }
    }
}

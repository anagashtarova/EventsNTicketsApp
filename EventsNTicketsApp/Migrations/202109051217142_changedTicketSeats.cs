namespace EventsNTicketsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedTicketSeats : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketSeats",
                c => new
                    {
                        TicketSeatId = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        Row = c.String(),
                        SeatNumber = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.TicketSeatId)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketSeats", "TicketId", "dbo.Tickets");
            DropIndex("dbo.TicketSeats", new[] { "TicketId" });
            DropTable("dbo.TicketSeats");
        }
    }
}

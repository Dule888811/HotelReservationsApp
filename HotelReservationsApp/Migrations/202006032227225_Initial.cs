namespace HotelReservationsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Result = c.String(),
                        StartDate = c.Int(nullable: false),
                        EndDate = c.Int(nullable: false),
                        Room_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Rooms", t => t.Room_id)
                .Index(t => t.Room_id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Room_id", "dbo.Rooms");
            DropIndex("dbo.Bookings", new[] { "Room_id" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Bookings");
        }
    }
}

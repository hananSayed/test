namespace softZoneRestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.city",
                c => new
                    {
                        cityId = c.Int(nullable: false, identity: true),
                        cityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.cityId);
            
            CreateTable(
                "dbo.restInfo",
                c => new
                    {
                        restId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        description = c.String(nullable: false),
                        image = c.String(nullable: false),
                        cityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.restId)
                .ForeignKey("dbo.city", t => t.cityId, cascadeDelete: true)
                .Index(t => t.cityId);
            
            CreateTable(
                "dbo.item",
                c => new
                    {
                        itemId = c.Int(nullable: false, identity: true),
                        itemName = c.String(),
                        desription = c.String(),
                        price = c.Int(nullable: false),
                        image = c.String(),
                        restId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.itemId)
                .ForeignKey("dbo.restInfo", t => t.restId, cascadeDelete: true)
                .Index(t => t.restId);
            
            CreateTable(
                "dbo.order",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        itemCount = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.orderId)
                .ForeignKey("dbo.item", t => t.itemId, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.userId, cascadeDelete: true)
                .Index(t => t.itemId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        phone = c.String(),
                        email = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.order", "userId", "dbo.user");
            DropForeignKey("dbo.order", "itemId", "dbo.item");
            DropForeignKey("dbo.item", "restId", "dbo.restInfo");
            DropForeignKey("dbo.restInfo", "cityId", "dbo.city");
            DropIndex("dbo.order", new[] { "userId" });
            DropIndex("dbo.order", new[] { "itemId" });
            DropIndex("dbo.item", new[] { "restId" });
            DropIndex("dbo.restInfo", new[] { "cityId" });
            DropTable("dbo.user");
            DropTable("dbo.order");
            DropTable("dbo.item");
            DropTable("dbo.restInfo");
            DropTable("dbo.city");
        }
    }
}

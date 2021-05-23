namespace softZoneRestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.restInfo", "cityId", "dbo.city");
            DropPrimaryKey("dbo.city");
            AlterColumn("dbo.city", "cityId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.city", "cityId");
            AddForeignKey("dbo.restInfo", "cityId", "dbo.city", "cityId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.restInfo", "cityId", "dbo.city");
            DropPrimaryKey("dbo.city");
            AlterColumn("dbo.city", "cityId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.city", "cityId");
            AddForeignKey("dbo.restInfo", "cityId", "dbo.city", "cityId", cascadeDelete: true);
        }
    }
}

namespace softZoneRestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.user", "username", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.user", "phone", c => c.String(nullable: false));
            AlterColumn("dbo.user", "address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.user", "address", c => c.String());
            AlterColumn("dbo.user", "phone", c => c.String());
            AlterColumn("dbo.user", "username", c => c.String());
        }
    }
}

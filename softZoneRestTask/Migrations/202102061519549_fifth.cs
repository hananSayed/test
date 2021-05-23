namespace softZoneRestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.user", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.user", "email", c => c.String());
        }
    }
}

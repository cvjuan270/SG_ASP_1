namespace SG_ASP_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class condatos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Discriminator");
        }
    }
}

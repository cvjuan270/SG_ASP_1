namespace SG_ASP_1.SGMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOmiinteconsulta : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Auditoria", "OmiInt", c => c.Byte(nullable: false));
            //AddColumn("dbo.Auditoria", "OmiInt1", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
        }
    }
}

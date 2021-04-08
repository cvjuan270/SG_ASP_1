namespace SG_ASP_1.SGMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterColumn : DbMigration
    {
        public override void Up()
        {

            //AlterColumn("dbo.Auditoria", "OmiInt", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}

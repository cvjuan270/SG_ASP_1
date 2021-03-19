namespace SG_ASP_1.SGMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Med_Audi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auditoria", "Medico", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
        }
    }
}

namespace SG_ASP_1.SGMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterExaMed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExaMedicoes", "Examen", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExaMedicoes", "Examen", c => c.Int(nullable: false));
        }
    }
}

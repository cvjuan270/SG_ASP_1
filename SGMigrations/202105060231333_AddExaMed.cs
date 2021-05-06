namespace SG_ASP_1.SGMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExaMed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExaMedicoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Examen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExaMedicoAuditorias",
                c => new
                    {
                        ExaMedico_Id = c.Int(nullable: false),
                        Auditoria_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExaMedico_Id, t.Auditoria_Id })
                .ForeignKey("dbo.ExaMedicoes", t => t.ExaMedico_Id, cascadeDelete: true)
                .ForeignKey("dbo.Auditoria", t => t.Auditoria_Id, cascadeDelete: true)
                .Index(t => t.ExaMedico_Id)
                .Index(t => t.Auditoria_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExaMedicoAuditorias", "Auditoria_Id", "dbo.Auditoria");
            DropForeignKey("dbo.ExaMedicoAuditorias", "ExaMedico_Id", "dbo.ExaMedicoes");
            DropIndex("dbo.ExaMedicoAuditorias", new[] { "Auditoria_Id" });
            DropIndex("dbo.ExaMedicoAuditorias", new[] { "ExaMedico_Id" });
            DropTable("dbo.ExaMedicoAuditorias");
            DropTable("dbo.ExaMedicoes");
        }
    }
}

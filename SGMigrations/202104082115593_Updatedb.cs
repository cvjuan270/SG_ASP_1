namespace SG_ASP_1.SGMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnfermeriaViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomApe = c.String(),
                        DocIde = c.String(),
                        Empres = c.String(),
                        AtenId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Interconsulta", "EnfermeriaViewModel_Id", c => c.Int());
            CreateIndex("dbo.Interconsulta", "EnfermeriaViewModel_Id");
            AddForeignKey("dbo.Interconsulta", "EnfermeriaViewModel_Id", "dbo.EnfermeriaViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interconsulta", "EnfermeriaViewModel_Id", "dbo.EnfermeriaViewModels");
            DropIndex("dbo.Interconsulta", new[] { "EnfermeriaViewModel_Id" });
            DropColumn("dbo.Interconsulta", "EnfermeriaViewModel_Id");
            DropTable("dbo.EnfermeriaViewModels");
        }
    }
}

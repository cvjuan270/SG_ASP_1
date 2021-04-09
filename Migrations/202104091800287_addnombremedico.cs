namespace SG_ASP_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnombremedico : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Medico", c => c.String());
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Nombre");
            DropColumn("dbo.AspNetUsers", "Medico");
        }
    }
}

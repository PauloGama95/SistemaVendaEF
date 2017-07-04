namespace AprendendoEF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionar_Campo_Sobrenome_Cliente : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Clientes");
            DropColumn("dbo.Clientes", "ClienteId");

            AddColumn("dbo.Clientes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Clientes", "Id");

            AddColumn("dbo.Clientes", "Sobrenome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Sobrenome");

            DropPrimaryKey("dbo.Clientes");
            DropColumn("dbo.Clientes", "Id");

            AddColumn("dbo.Clientes", "ClienteId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Clientes", "ClienteId");
        }
    }
}

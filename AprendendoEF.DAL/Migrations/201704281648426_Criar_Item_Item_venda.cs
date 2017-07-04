namespace AprendendoEF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criar_Item_Item_venda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemVenda", "Ordem", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemVenda", "Ordem");
        }
    }
}

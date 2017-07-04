namespace AprendendoEF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refazer_Foreign_Key_Venda_ItemVenda : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemVenda", "Venda_Id1", "dbo.Vendas");
            //DropIndex("dbo.ItemVenda", new[] { "Venda_Id" });
            DropIndex("dbo.ItemVenda", new[] { "Venda_Id1" });
            DropColumn("dbo.ItemVenda", "Venda_Id1");
            //RenameColumn(table: "dbo.ItemVenda", name: "Venda_Id1", newName: "Venda_Id");
            //AlterColumn("dbo.ItemVenda", "Venda_Id", c => c.Int(nullable: false));
            //CreateIndex("dbo.ItemVenda", "Venda_Id");
            //AddForeignKey("dbo.ItemVenda", "Venda_Id", "dbo.Vendas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVenda", "Venda_Id", "dbo.Vendas");
            DropIndex("dbo.ItemVenda", new[] { "Venda_Id" });
            AlterColumn("dbo.ItemVenda", "Venda_Id", c => c.Int());
            RenameColumn(table: "dbo.ItemVenda", name: "Venda_Id", newName: "Venda_Id1");
            AddColumn("dbo.ItemVenda", "Venda_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemVenda", "Venda_Id1");
            CreateIndex("dbo.ItemVenda", "Venda_Id");
            AddForeignKey("dbo.ItemVenda", "Venda_Id1", "dbo.Vendas", "Id");
        }
    }
}

namespace AprendendoEF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionado_Vendas_e_ItensVendas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemVenda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Produto_Id = c.Int(nullable: false),
                        Quantidade = c.Double(nullable: false),
                        ValorUnitario = c.Double(nullable: false),
                        ValorTotal = c.Double(nullable: false),
                        Venda_Id = c.Int(nullable: false),
                        Venda_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtos", t => t.Produto_Id)
                .ForeignKey("dbo.Vendas", t => t.Venda_Id1)
                .ForeignKey("dbo.Vendas", t => t.Venda_Id, cascadeDelete: true)
                .Index(t => t.Produto_Id)
                .Index(t => t.Venda_Id)
                .Index(t => t.Venda_Id1);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Cliente_Id = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVenda", "Venda_Id", "dbo.Vendas");
            DropForeignKey("dbo.ItemVenda", "Venda_Id1", "dbo.Vendas");
            DropForeignKey("dbo.Vendas", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.ItemVenda", "Produto_Id", "dbo.Produtos");
            DropIndex("dbo.Vendas", new[] { "Cliente_Id" });
            DropIndex("dbo.ItemVenda", new[] { "Venda_Id1" });
            DropIndex("dbo.ItemVenda", new[] { "Venda_Id" });
            DropIndex("dbo.ItemVenda", new[] { "Produto_Id" });
            DropTable("dbo.Vendas");
            DropTable("dbo.ItemVenda");
        }
    }
}

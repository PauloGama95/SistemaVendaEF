namespace AprendendoEF.DAL
{
    using Configurations;
    using System;
    using System.Data.Entity;
    using System.Linq;


    //DataContext é o Banco
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new GrupoProdutoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new VendaConfig());
            modelBuilder.Configurations.Add(new ItemVendaConfig());


        }

        //DbSet é as tabelas
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<GrupoProduto> GruposProdutos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<ItemVenda> ItensVendas { get; set; }
        public virtual DbSet<Email> Email { get; set; }
    }
}
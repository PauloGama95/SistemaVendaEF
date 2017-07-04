using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.DAL.Configurations
{
   public class ItemVendaConfig : EntityTypeConfiguration<ItemVenda>
    {
        public ItemVendaConfig()
        {
            ToTable("ItemVenda");

            //Mapeamento da ForeignKey
            HasRequired(p => p.Produto)//um ItemVenda obrigatoriomente tem que ter um produto
                .WithMany() //um item pode ter varios produtos
                .HasForeignKey(x => x.Produto_Id); // essa obrigatoriedade tem uma forenkey

            HasRequired(i => i.Venda)
                .WithMany(v => v.Itens) 
                .HasForeignKey(x => x.Venda_Id); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.DAL.Configurations
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            //Renomeia a tabela criada pelo entity
            ToTable("Produtos");

            //Mapeamento da ForeignKey
            HasRequired(p => p.GrupoProduto)//um produto obrigatoriomente tem que ter um grupo
                .WithMany() //um grupo obrigtoriamente tem varios produtos
                .HasForeignKey(x => x.GrupoProduto_Id); // essa obrigatoriedade tem uma forenkey
        }
    }
}

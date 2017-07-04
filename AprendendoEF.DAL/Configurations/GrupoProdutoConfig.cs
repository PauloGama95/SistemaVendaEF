using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.DAL.Configurations
{
   public class GrupoProdutoConfig : EntityTypeConfiguration<GrupoProduto>
    {
        public GrupoProdutoConfig()
        {
            ToTable("GruposProdutos");
        }
    }
}

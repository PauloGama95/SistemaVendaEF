using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.DAL.Configurations
{
    public class VendaConfig : EntityTypeConfiguration<Venda>
    {
        public VendaConfig()
        {
            ToTable("Vendas");

            //Mapeamento da ForeignKey
            HasRequired(c => c.Cliente)//uma venda obrigatoriomente tem que ter um cliente
                .WithMany() //um cliente pode ter varias vendas
                .HasForeignKey(x => x.Cliente_Id); // essa obrigatoriedade tem uma forenkey
        }
    }
}

using AprendendoEF.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF
{
    [Serializable]
    public class ItemVenda : BaseEntidade
    {
        public Produto Produto { get; set; }

        public int Produto_Id { get; set; }

        public int Ordem { get; set; }
        
        public double Quantidade { get; set; }

        public double ValorUnitario { get; set; }

        public double ValorTotal { get; set; }

        public Venda Venda { get; set; }

        public int Venda_Id { get; set; }

        public ItemVenda()
        {

        }

    }
}

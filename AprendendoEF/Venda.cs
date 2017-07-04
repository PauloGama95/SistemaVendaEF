using AprendendoEF.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF
{
    [Serializable]
    public class Venda : BaseEntidade
    {
        public DateTime Data { get; set; }

        public Cliente Cliente { get; set; }

        public int Cliente_Id { get; set; }

        public double Valor { get; set; }

        public List<ItemVenda> Itens { get; set; }

        public Venda()
        {

        }
    }
}

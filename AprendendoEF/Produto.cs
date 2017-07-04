using AprendendoEF.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF
{
    [Serializable]
    public class Produto : BaseEntidade
    {
        public string Nome { get; set; }

        public double Valor { get; set; }

        //Cardinalidade
        public GrupoProduto GrupoProduto { get; private set; }

        //ForeignKey
        public int GrupoProduto_Id { get; set; }

        public override string ToString()
        {
            return Nome;
        }

        public Produto()
        {

        }
    }
}

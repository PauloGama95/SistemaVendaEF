using AprendendoEF.Base;
using AprendendoEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF
{
    [Serializable]
    public class Cliente : BaseEntidade
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Nome} {Sobrenome}";
        }

        public Cliente()
        {

        }
    }


}

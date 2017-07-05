using AprendendoEF.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF
{
    [Serializable]
    public class Usuario : BaseEntidade
    {
        public string Login { get; set; }

        public string Senhas { get; set; }

        public Usuario()
        {

        }
    }
}

using AprendendoEF.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF
{
    public class Email : BaseEntidade
    {
        public string Smtp { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public bool Ssl { get; set; }

        public int Porta { get; set; }


        
    }
}

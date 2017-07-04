using AprendendoEF.BLL.Base;
using AprendendoEF.DAL;
using AprendendoEF.DAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.BLL
{
    public class EmailBO : BaseBO<Email, EmailDAO>
    {
        public override void Salvar(Email entidade)
        {

            try
            {
                if (string.IsNullOrEmpty(entidade.Usuario) || string.IsNullOrEmpty(entidade.Smtp))

                    throw new ArgumentNullException();

                base.Salvar(entidade);

            }
            catch (Exception)
            {

                throw;
            }





        }
    }
}

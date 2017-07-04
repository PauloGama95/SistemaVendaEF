using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.BLL
{
    public class LoginBO
    {
        public bool Logar(Usuario usuario)
        {
            var usuarioBo = new UsuarioBO();
            var usuarioBd = usuarioBo.Encontrar(usuario.Login);

            if (usuarioBd == null)
            {

                return false;

            }

            if (usuario.Senha != usuarioBd.Senha)
            {

                return false;

            }

            return true;
        }
    }
}

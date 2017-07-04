using AprendendoEF.BLL.Base;
using AprendendoEF.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.BLL
{
    public class UsuarioBO : BaseBO<Usuario, UsuarioDAO>
    {

        public override void Salvar(Usuario entidade)
        {

            try
            {


                if ((string.IsNullOrEmpty(entidade.Login) || string.IsNullOrEmpty(entidade.Senha)))
                    throw new ArgumentNullException("Usuario ou senha em brancos");


                var usuario = new UsuarioBO();
                var usuarioBd = usuario.Encontrar(entidade.Login);


                if (usuarioBd == null)
                {
                    base.Salvar(entidade);
                }
                else
                    throw new ArgumentException("Favor utilize outro usuario, este usuario ja possui cadastro");

                if (usuarioBd != null)
                {
                    base.Editar(entidade);
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
        public Usuario Encontrar(string login)
        {
            try
            {
                var usuarioDAO = new UsuarioDAO();
                return usuarioDAO.Encontrar(login);
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}

using AprendendoEF.DAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.DAL
{
    public class UsuarioDAO : BaseDAO<Usuario>
    {
        public Usuario Encontrar(string login)
        {
            using (var _context = new DataContext())
            {

                // capturar o dbset
                return _context.Usuarios.FirstOrDefault(x => x.Login == login);
            }
        }
    }
}

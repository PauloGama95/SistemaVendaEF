using AprendendoEF.DAL.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.DAL
{
    public class ClienteDAO : BaseDAO<Cliente>
    {
        public List<Cliente> Encontrar(string valor)
        {
            using (var _context = new DataContext())
            {

                // capturar o dbset
                return _context.Clientes.Where(x => x.Nome.Contains(valor)).ToList();
            }
        }
    }
}


using AprendendoEF.DAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace AprendendoEF.DAL
{
    public class VendaDAO : BaseDAO<Venda>
    {
        public override List<Venda> Listar()
        {
            using (var _context = new DataContext())
            {
                return _context.Vendas.Include(x => x.Cliente).ToList();
            }

        }
        public override Venda Encontrar(int id)
        {
            using (var _context = new DataContext())
            {
                return _context.Vendas
                        .Include(x => x.Cliente)
                        .Include(x => x.Itens)
                        .Include(x => x.Itens.Select(i => i.Produto))
                        .FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
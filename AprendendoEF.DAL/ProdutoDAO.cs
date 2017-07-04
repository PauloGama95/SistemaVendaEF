using AprendendoEF.DAL.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.DAL
{
    public class ProdutoDAO : BaseDAO<Produto>
    {
        public override List<Produto> Listar()
        {
            using (var _context = new DataContext())
            {
                var produtos = _context
                                    .Produtos
                                    .Include(x => x.GrupoProduto)
                                    .ToList();

                return produtos;
            }
        }

        public override Produto Encontrar(int id)
        {
            using (var _context = new DataContext())
            {
                var produto = _context
                                      .Produtos
                                      .Include(x => x.GrupoProduto)
                                      .FirstOrDefault(x => x.Id == id);

                return produto;
            }


        }

        public List<Produto> Encontrar(string valor)
        {
            using (var _context = new DataContext())
            {
                return _context.Produtos.Where(x => x.Nome.Contains(valor)).ToList();
            }
        }
    }
}


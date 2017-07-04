using AprendendoEF.BLL.Base;
using AprendendoEF.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.BLL
{
    public class ProdutoBO : BaseBO<Produto, ProdutoDAO>
    {
        public override void Salvar(Produto entidade)
        {

            try
            {
                if ((string.IsNullOrEmpty(entidade.Nome)))
                    throw new ArgumentNullException();

                base.Salvar(entidade);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Produto> Encontrar(string valor)
        {
            try
            {
                var produto = new ProdutoDAO();
                return produto.Encontrar(valor).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

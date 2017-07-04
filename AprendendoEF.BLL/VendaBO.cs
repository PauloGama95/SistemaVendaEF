using AprendendoEF.BLL.Base;
using AprendendoEF.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.BLL
{
    public class VendaBO : BaseBO<Venda, VendaDAO>
    {
        protected override void Inserir(Venda entidade)
        {
            //Fazer backup dos itens
            var itens = entidade.Itens;

            //Anular as entidades filhas
            entidade.Itens = null;

            //Salvar venda
            base.Inserir(entidade);

            var itemBo = new ItemVendaBO();
            foreach (var item in itens)
            {
                //Preencher o id da venda
                item.Venda_Id = entidade.Id;

                //Anular as entidades filhas
                item.Produto = null;

                //Salvar o item
                itemBo.Salvar(item);
            }
        }

        protected override void Editar(Venda entidade)
        {
            //Fazer backup dos itens
            var itens = entidade.Itens;

            //Anular as entidades filhas
            entidade.Itens = null;

            //Editar a venda
            base.Editar(entidade);

            //Encontrar itens do banco de dados
            var vendaBD = Encontrar(entidade.Id);
            var itensVendaBD = vendaBD.Itens;

            //Filtrar itens adicionados
            var itensVendaAdicionados = itens.Where(x => x.Id == 0).ToList();

            //quais itens foram mantidos e quais itens foram removidos
            var itensVendaRemovidos = new List<ItemVenda>();
            foreach (var itemBD in itensVendaBD)
            {
                //Filtrar o item mantido
                var itemMantidoOuRemovido = itens.FirstOrDefault(x => x.Id == itemBD.Id);

                //Caso o item mantido for nulo quer dizer que ele nao foi mantido, mas sim REMOVIDO
                if (itemMantidoOuRemovido == null)
                {
                    itensVendaRemovidos.Add(itemMantidoOuRemovido);
                }
            }

            var itemBo = new ItemVendaBO();

            //Inserir os itens adicionados ao banco de dados
            foreach (var itemAdd in itensVendaAdicionados)
            {
                //Preencher o id da venda
                itemAdd.Venda_Id = entidade.Id;

                //Anular as entidades filhas
                itemAdd.Produto = null;

                //Salvar o item
                itemBo.Salvar(itemAdd);
            }

            //Remover os itens no banco de dados
            foreach (var itemRemovido in itensVendaRemovidos)
            {
                //Remover o item
                itemBo.Remover(itemRemovido.Id);
            }
        }

        public override void Salvar(Venda entidade)
        {
            //Anular as entidades filhas
            entidade.Cliente = null;

            //Salvar a venda
            base.Salvar(entidade);
        }

    }
}

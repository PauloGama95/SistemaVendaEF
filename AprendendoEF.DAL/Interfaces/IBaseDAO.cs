using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.DAL.Interfaces
{
    public interface IBaseDAO<T>
    {

        List<T> Listar();

        T Encontrar(int id);

        void Inserir(T entidade);

        void Editar(T entidade);

        void Remover(int id);
    }
}

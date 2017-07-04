using AprendendoEF.DAL.Interfaces;
using AprendendoEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.DAL.Base
{

    /// <summary>
    /// Classe resposavel pela conexao com o banco de dados de uma entidade do tipo T
    /// </summary>
    /// <typeparam name="T">Tipo da ENTIDADE</typeparam>
    public abstract class BaseDAO<T> : IBaseDAO<T>
        where T : class, IBaseEntidade
    {
        public virtual List<T> Listar()
        {
            //Quando passa pela ultima chave mata o objeto, limpa a memoria
            using (var _context = new DataContext())
            {
                // capturar o dbset
                var dbset = _context.Set<T>();
                return dbset.ToList();
            }
        }

        public virtual T Encontrar(int id)
        {
            using (var _context = new DataContext())
            {

                // capturar o dbset
                var dbset = _context.Set<T>();
                return dbset.FirstOrDefault(x => x.Id == id);
            }

        }


        public virtual void Inserir(T entidade)
        {
            using (var _context = new DataContext())
            {

                // capturar o dbset
                var dbset = _context.Set<T>();
                dbset.Add(entidade);
                _context.SaveChanges();
            }
        }

        public virtual void Editar(T entidade)
        {
            using (var _context = new DataContext())
            {

                // capturar o dbset
                var dbset = _context.Set<T>();
                dbset.Attach(entidade);
                _context.Entry(entidade).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public virtual void Remover(int id)
        {
            using (var _context = new DataContext())
            {
                var entidade = Encontrar(id);

                // capturar o dbset
                var dbset = _context.Set<T>();
                dbset.Attach(entidade);
                dbset.Remove(entidade);
                _context.SaveChanges();
            }
        }
    }
}

using AprendendoEF.DAL.Interfaces;
using AprendendoEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.BLL.Base
{
    /// <summary>
    /// Classe que Retorna uma Instancia de Lógica de Negocio do Tipo T
    /// </summary>
    /// <typeparam name="T">Tipo da ENTIDADE</typeparam>
    /// <typeparam name="TDAO">Tipo do ACESSO A DADOS(Nome da ENTIDADE + Sufixo DAO )</typeparam>
    public class BaseBO<T, TDAO>
        where T : class, IBaseEntidade
        where TDAO : class, IBaseDAO<T>, new()
    {
        TDAO dao;

        public BaseBO()
        {
            dao = new TDAO();
        }

        protected virtual void Inserir(T entidade)
        {
            try
            {
                dao.Inserir(entidade);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected virtual void Editar(T entidade)
        {
            try
            {
                dao.Editar(entidade);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public virtual void Salvar(T entidade)
        {
            try
            {
                if (entidade.Id == 0)
                    Inserir(entidade);
                else
                    Editar(entidade);


            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual T Encontrar(int id)
        {
            try
            {
                return dao.Encontrar(id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual List<T> Listar()
        {
            try
            {
                return dao.Listar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual void Remover(int id)
        {

            try
            {
                dao.Remover(id);

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public class GenericRepository<T> where T : class
    {
        /// <summary>
        ///     Contexto de acceso a la base de datos
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        ///     Logger de la aplicación
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        ///     DbSet del modelo
        /// </summary>
        private DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _logger = logger;
        }

        #region Métodos públicos

        /// <summary>
        ///     Obtiene un objeto "T" de base de datos a través de su Id
        /// </summary>
        /// <param name="id">Id del objeto que se va a obtener</param>
        /// <returns></returns>
        public T Get(object id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        ///     Obtiene el primer elemento que cumple el filtro de la expresión
        /// </summary>
        /// <param name="filter">Expresión que define el filtro a aplicar</param>
        /// <param name="includes">Listado de funciones con los includes que se desean aplicar</param>
        /// <returns></returns>
        public virtual T GetFirst(Expression<Func<T, bool>> filter, Expression<Func<T, object>>[] includes = null)
        {
            try
            {
                if (includes == null)
                    return _dbSet.FirstOrDefault(filter);
                else
                {
                    var objects = _dbSet.Where(filter);
                    ApplyIncludes(ref objects, includes);

                    return objects.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        ///     Obtiene una lista completa
        /// </summary>
        /// <param name="includes">Listado de funciones con los includes que se desean aplicar</param>
        /// <returns></returns>
        public IQueryable<T> GetAll(Expression<Func<T, object>>[] includes = null)
        {
            try
            {
                var objects = _dbSet.AsQueryable();

                if(includes != null)
                    ApplyIncludes(ref objects, includes);

                return objects;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        ///     Obtiene el primer elemento que cumple el filtro de la expresión.
        /// </summary>
        /// <param name="filter">Expresión que define el filtro a aplicar</param>
        /// <param name="includes">Listado de funciones con los includes que se desean aplicar</param>
        /// <returns></returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter, Expression<Func<T, object>>[] includes = null)
        {
            try
            {
                if (includes == null)
                {
                    if (filter != null)
                        return _dbSet.Where(filter);
                    else
                        return _dbSet;
                }
                else
                {
                    if (filter != null)
                    {
                        var objects = _dbSet.Where(filter);
                        ApplyIncludes(ref objects, includes);
                        return objects;
                    }
                    else
                    {
                        var objects = _dbSet.AsNoTracking();
                        ApplyIncludes(ref objects, includes);
                        return objects;
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        ///     Obtiene el número de elementos que cumplen la funcion recibida
        /// </summary>
        /// <param name="filter">Expresión del filtro</param>
        /// <returns></returns>
        public int Count(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                if (filter != null)
                    return _dbSet.Count(filter);
                else
                    return _dbSet.Count();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        ///     Comprueba si existe algún elemento que cumpla con el filtro
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                if (filter != null)
                    return _dbSet.Any(filter);
                else
                    return _dbSet.Any();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        ///     Añade un elemento a la base de datos
        /// </summary>
        /// <param name="entity">Entidad a añadir</param>
        public void Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        ///     Actualiza un elemento de la base de datos
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        ///     Elimina un elemento de la base de datos
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        #endregion

        #region Métodos privados

        /// <summary>
        ///     Método que aplica los includes pasados como parámetro al listado de elementos pasado como referencia
        /// </summary>
        /// <param name="source">Listado de elementos</param>
        /// <param name="includes">Includes a aplicar</param>
        /// <returns></returns>
        private IQueryable<T> ApplyIncludes(ref IQueryable<T> source, Expression<Func<T, object>>[] includes)
        {
            try
            {
                foreach (var include in includes)
                {
                    source = source.Include(include);
                }
                return source;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


    }
}

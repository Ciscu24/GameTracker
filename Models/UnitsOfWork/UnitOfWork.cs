using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Models;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.UnitsOfWork
{
    public class UnitOfWork
    {

        #region Miembros Privados

        /// <summary>
        ///     Contexto de la base de datos
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        ///     Logger de la aplicación
        /// </summary>
        private readonly ILogger _logger;

        #endregion

        #region Repositorios

        public GenericRepository<UserModel> UsersRepository { get; set; }

        #endregion

        #region Constructores

        public UnitOfWork(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;

            // Inicialización de los repositorios
            UsersRepository = new GenericRepository<UserModel>(_context, _logger);
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        ///     Guarda los cambios pendientes en los contextos de bases de datos
        /// </summary>
        /// <returns></returns>
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}

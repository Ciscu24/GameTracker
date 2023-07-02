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

        public GenericRepository<GameModel> GamesRepository { get; set; }

        public GenericRepository<PlayerGameStatusModel> PlayerGameStatusRepository { get; set; }

        public GenericRepository<CollectionModel> CollectionsRepository { get; set; }

        public GenericRepository<CommentModel> CommentsRepository { get; set; }

        public GenericRepository<ConsoleModel> ConsolesRepository { get; set; }

        public GenericRepository<GenreModel> GenresRepository { get; set; }

        #endregion

        #region Constructores

        public UnitOfWork(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;

            #region Inicialización de los repositorios

            UsersRepository = new GenericRepository<UserModel>(_context, _logger);
            GamesRepository = new GenericRepository<GameModel>(_context, _logger);
            PlayerGameStatusRepository = new GenericRepository<PlayerGameStatusModel>(_context, _logger);
            CollectionsRepository = new GenericRepository<CollectionModel>(_context, _logger);
            CommentsRepository = new GenericRepository<CommentModel>(_context, _logger);
            ConsolesRepository = new GenericRepository<ConsoleModel>(_context, _logger);
            GenresRepository = new GenericRepository<GenreModel>(_context, _logger);

            #endregion
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

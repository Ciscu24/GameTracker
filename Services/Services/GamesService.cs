using Common.Dtos;
using Microsoft.Extensions.Logging;
using Models.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IGamesService
    {
        /// <summary>
        ///     Método que obtiene todos los videojuegos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GameDto>> GetAll();
    }

    public sealed class GamesService : BaseService, IGamesService
    {
        #region Constructores

        public GamesService(UnitOfWork unitOfWork, ILogger logger) : base(unitOfWork, logger) { }

        #endregion

        #region Implementación de métodos interfaz

        /// <summary>
        ///     Método que obtiene todos los videojuegos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GameDto>> GetAll()
        {
            try
            {
                var response = await Task.FromResult(_unitOfWork.GamesRepository.GetAll());
                return response.Select(s => s.ToDto(false));
            }
            catch (Exception ex)
            {
                _logger.LogError("Excepción obteniendo todos los videojuegos", ex);
                throw;
            }
        }

        #endregion

        #region Métodos privados

        #endregion

    }
}

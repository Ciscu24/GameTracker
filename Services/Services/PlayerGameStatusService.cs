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
    public interface IPlayerGameStatusService
    {
        /// <summary>
        ///     Método que obtiene todos los estados de los videojuegos del usuario
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PlayerGameStatusDto>> GetAll();
    }

    public sealed class PlayerGameStatusService : BaseService, IPlayerGameStatusService
    {
        #region Constructores

        public PlayerGameStatusService(UnitOfWork unitOfWork, ILogger logger) : base(unitOfWork, logger) { }

        #endregion

        #region Implementación de métodos interfaz

        /// <summary>
        ///     Método que obtiene todos los estados de los videojuegos del usuario
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PlayerGameStatusDto>> GetAll()
        {
            try
            {
                var response = await Task.FromResult(_unitOfWork.PlayerGameStatusRepository.GetAll());
                return response.Select(s => s.ToDto(false));
            }
            catch (Exception ex)
            {
                _logger.LogError("Excepción obteniendo todos los estados de los videojuegos del usuario", ex);
                throw;
            }
        }

        #endregion

        #region Métodos privados

        #endregion

    }
}

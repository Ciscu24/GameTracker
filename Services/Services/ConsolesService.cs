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
    public interface IConsolesService
    {
        /// <summary>
        ///     Método que obtiene todas las consolas
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ConsoleDto>> GetAll();
    }

    public sealed class ConsolesService : BaseService, IConsolesService
    {
        #region Constructores

        public ConsolesService(UnitOfWork unitOfWork, ILogger logger) : base(unitOfWork, logger) { }

        #endregion

        #region Implementación de métodos interfaz

        /// <summary>
        ///     Método que obtiene todas las consolas
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ConsoleDto>> GetAll()
        {
            try
            {
                var response = await Task.FromResult(_unitOfWork.ConsolesRepository.GetAll());
                return response.Select(s => s.ToDto(false));
            }
            catch (Exception ex)
            {
                _logger.LogError("Excepción obteniendo todas las consolas", ex);
                throw;
            }
        }

        #endregion

        #region Métodos privados

        #endregion

    }
}

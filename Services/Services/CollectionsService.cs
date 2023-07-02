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

    public interface ICollectionsService
    {
        /// <summary>
        ///     Método que obtiene todas las colecciones
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CollectionDto>> GetAll();
    }

    public sealed class CollectionsService : BaseService, ICollectionsService
    {
        #region Constructores

        public CollectionsService(UnitOfWork unitOfWork, ILogger logger) : base(unitOfWork, logger) { }

        #endregion

        #region Implementación de métodos interfaz

        /// <summary>
        ///     Método que obtiene todas las colecciones
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CollectionDto>> GetAll()
        {
            try
            {
                var response = await Task.FromResult(_unitOfWork.CollectionsRepository.GetAll());
                return response.Select(s => s.ToDto(false));
            }
            catch (Exception ex)
            {
                _logger.LogError("Excepción obteniendo todas las colecciones", ex);
                throw;
            }
        }

        #endregion

        #region Métodos privados

        #endregion

    }
}

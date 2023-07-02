using Common.Dtos;
using Microsoft.Extensions.Logging;
using Models.Models;
using Models.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IGenresService
    {
        /// <summary>
        ///     Método que obtiene todos los géneros
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GenreDto>> GetAll();
    }

    public sealed class GenresService: BaseService, IGenresService
    {
        #region Constructores

        public GenresService(UnitOfWork unitOfWork, ILogger logger) : base(unitOfWork, logger) { }

        #endregion

        #region Implementación de métodos interfaz

        /// <summary>
        ///     Método que obtiene todos los géneros
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GenreDto>> GetAll()
        {
            try
            {
                var response = await Task.FromResult(_unitOfWork.GenresRepository.GetAll());
                return response.Select(s => s.ToDto(false));
            }
            catch (Exception ex)
            {
                _logger.LogError("Excepción obteniendo todos los géneros", ex);
                throw;
            }
        }

        #endregion

        #region Métodos privados

        #endregion

    }
}

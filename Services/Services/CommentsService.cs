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
    public interface ICommentsService
    {
        /// <summary>
        ///     Método que obtiene todos los comentarios
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CommentDto>> GetAll();
    }

    public sealed class CommentsService : BaseService, ICommentsService
    {
        #region Constructores

        public CommentsService(UnitOfWork unitOfWork, ILogger logger) : base(unitOfWork, logger) { }

        #endregion

        #region Implementación de métodos interfaz

        /// <summary>
        ///     Método que obtiene todos los comentarios
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CommentDto>> GetAll()
        {
            try
            {
                var response = await Task.FromResult(_unitOfWork.CommentsRepository.GetAll());
                return response.Select(s => s.ToDto(false));
            }
            catch (Exception ex)
            {
                _logger.LogError("Excepción obteniendo todos los comentarios", ex);
                throw;
            }
        }

        #endregion

        #region Métodos privados

        #endregion

    }
}

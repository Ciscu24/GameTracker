using Microsoft.Extensions.Logging;
using Models.Models;
using Models.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUsersService
    {
        /// <summary>
        ///     Método que obtiene todos los usuarios
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserModel>> GetAll();
    }

    public sealed class UsersService : BaseService, IUsersService
    {
        #region Constructores

        public UsersService(UnitOfWork unitOfWork, ILogger logger) : base(unitOfWork, logger) { }

        #endregion

        #region Implementación de métodos interfaz

        /// <summary>
        ///     Método que obtiene todos los usuarios
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserModel>> GetAll()
        {
            try
            {
                return await Task.FromResult(_unitOfWork.UsersRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError("Excepción obteniendo todos los usuarios", ex);
                throw;
            }
        }

        #endregion

        #region Métodos privados

        #endregion

    }
}

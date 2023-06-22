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
    public interface IUsersService
    {
        /// <summary>
        ///     Método que obtiene todos los usuarios
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserDto>> GetAll();

        /// <summary>
        ///     Método que obtiene un usuario por UserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<UserDto> GetByUserName(string userName);
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
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            try
            {
                var response = await Task.FromResult(_unitOfWork.UsersRepository.GetAll(new Expression<Func<UserModel, object>>[] { u => u.Following, u => u.Followers }));
                return response.Select(s => s.ToDto(true));
            }
            catch (Exception ex)
            {
                _logger.LogError("Excepción obteniendo todos los usuarios", ex);
                throw;
            }
        }

        public async Task<UserDto> GetByUserName(string userName)
        {
            try
            {
                var user = await Task.FromResult(_unitOfWork.UsersRepository.GetFirst(f => f.UserName == userName));
                return user.ToDto();
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

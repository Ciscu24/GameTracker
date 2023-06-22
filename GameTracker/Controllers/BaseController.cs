using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace GameTracker.Controllers
{
    public class BaseController: ControllerBase
    {
        #region Miembros privados

        private readonly IServiceProvider _serviceProvider;

        #endregion

        #region Miembros internos

        internal ILogger Logger;

        internal IUsersService UsersService;

        #endregion

        #region Constructores

        public BaseController(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            Logger = (ILogger)serviceProvider.GetService(typeof(ILogger));
            UsersService = (IUsersService)serviceProvider.GetService(typeof(IUsersService));
        }
        
        #endregion
    }
}

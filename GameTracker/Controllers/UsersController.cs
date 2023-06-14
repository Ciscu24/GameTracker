using Common.Dtos.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : BaseController
    {
        #region Constructores

        public UsersController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        #endregion

        [Route("getall")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = new GenericResponseDto();
            try
            {
                response.Data = await UsersService.GetAll();
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al obtener todos los usuarios", ex);
                response.Success = false;
                response.ErrorMessage = "Error al obtener todos los usuarios";
                return new JsonResult(response);
            }
        }
    }
}

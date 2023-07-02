using Common.Dtos.Login;
using Common.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : BaseController
    {
        #region Miembros privados

        private readonly string _secretKey = "gameTrackerProject";

        #endregion

        #region Constructores

        public AccountController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        #endregion

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto login)
        {
            try
            {
                var user = await UsersService.GetByUserName(login.UserName);
                if (user == null)
                    return BadRequest(new ResponseLoginDto() { Success = false, Error = "Usuario no encontrado" });

                if (user.Password != login.Password)
                    return BadRequest(new ResponseLoginDto() { Success = false, Error = "Error al logearse" });

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secretKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(Literals.Claim_UserId, user.Id),
                        new Claim(Literals.Claim_UserName, user.UserName),
                        new Claim(Literals.Claim_FullName, user.FullName)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new ResponseLoginDto()
                {
                    Success = true,
                    UserId = user.Id,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Token = tokenString
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseLoginDto()
                {
                    Success = false,
                    Error = ex.Message
                });
            }
        }
    }
}

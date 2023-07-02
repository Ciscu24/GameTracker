using Common.Dtos;
using Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("Users")]
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<UserModel> Followers { get; set; }

        public virtual ICollection<UserModel> Following { get; set; }

        public virtual ICollection<CollectionModel> Collections { get; set; }

        public virtual ICollection<CommentModel> Comments { get; set; }

        public virtual ICollection<PlayerGameStatusModel> PlayerGameStatus { get; set; }

        public UserDto ToDto(bool includes = false)
        {
            var user = InitializeDto();

            if (includes)
            {
                if (this.Followers != null)
                    user.Followers = this.Followers.Select(s => s.ToDto());
                    
                if(this.Following != null)
                    user.Following = this.Following.Select(s => s.ToDto());

                if(this.PlayerGameStatus != null)
                    user.PlayerGameStatus = this.PlayerGameStatus.Select(s => s.ToDto());
            }

            return user;
        }

        private UserDto InitializeDto()
        {
            return new UserDto()
            {
                Id = this.Id,
                UserName = this.UserName,
                FullName = this.FullName,
                Email = this.Email,
                Password = this.Password
            };
        }
    }

    /// <summary>
    ///     Clase estática que extiende métodos al usuario logueado (IPrincipal), 
    ///     que obtienen datos de los Claims que se le han asigando al usuario.
    /// </summary>
    public static class UserExtended
    {
        /// <summary>
        ///     Obtiene el Id del usuario logeado
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetUserId(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst(Literals.Claim_UserId);
            return claim?.Value;
        }

        /// <summary>
        ///     Obtiene el nombre de usuario del usuario logeado
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetUserName(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst(Literals.Claim_UserName);
            return claim?.Value;
        }

        /// <summary>
        ///     Obtiene el nombre completo del usuario logeado
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetFullName(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst(Literals.Claim_FullName);
            return claim?.Value;
        }
    }
}

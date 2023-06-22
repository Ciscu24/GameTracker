using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos.Login
{
    public class ResponseLoginDto
    {
        /// <summary>
        ///     Variable para saber si han habido errores
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        ///     Variable para que contiene el mensaje de error
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        ///     Token de acceso
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        ///     Usermane del usuario logeado
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     Identificador del usuario logeado
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///     Nombre completo del usuario logeado
        /// </summary>
        public string FullName { get; set; }

    }
}

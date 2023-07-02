using Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class PlayerGameStatusDto
    {
        public string UserId { get; set; }

        public virtual UserDto User { get; set; }

        public long GameId { get; set; }

        public virtual GameDto Game { get; set; }

        /// <summary>
        ///     Mejor tiempo en el que ha completado el juego
        /// </summary>
        public TimeSpan? BestCompletionTime { get; set; }

        /// <summary>
        ///     Veces que ha completado el juego
        /// </summary>
        public int TimesBeaten { get; set; }

        public PlayingStatus Status { get; set; }

        public DateTime InitDate { get; set; }

        public DateTime? FinishDate { get; set; }
    }
}

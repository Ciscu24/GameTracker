using Common.Dtos;
using Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("PlayerGameStatus")]
    public class PlayerGameStatusModel
    {
        [ForeignKey("Users")]
        public string UserId { get; set; }

        public virtual UserModel User { get; set; }

        [ForeignKey("Games")]
        public long GameId { get; set; }

        public virtual GameModel Game { get; set; }

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

        public PlayerGameStatusDto ToDto(bool includes = false)
        {
            var playerGameStatus = InitializeDto();

            if (includes)
            {
                if (this.User != null)
                    playerGameStatus.User = this.User.ToDto();

                if (this.Game != null)
                    playerGameStatus.Game = this.Game.ToDto();
            }

            return playerGameStatus;
        }

        private PlayerGameStatusDto InitializeDto()
        {
            return new PlayerGameStatusDto()
            {
                UserId = this.UserId,
                GameId = this.GameId,
                BestCompletionTime = this.BestCompletionTime,
                TimesBeaten = this.TimesBeaten,
                Status = this.Status,
                InitDate = this.InitDate,
                FinishDate = this.FinishDate
            };
        }
    }
}

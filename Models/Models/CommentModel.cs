using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utilities;
using Common.Dtos;

namespace Models.Models
{
    [Table("Comments")]
    public class CommentModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        /// <summary>
        ///     Texto del comentario
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Fecha en la que se realizó el comentario
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Booleano para saber si el usuario recomienda el juego o no
        /// </summary>
        public bool Recommended { get; set; }

        /// <summary>
        ///     Visibilidad del comentario
        /// </summary>
        public Visibility Visibility { get; set; }

        [ForeignKey("Games")]
        public long GameId { get; set; }

        /// <summary>
        ///     Videojuego al que va asignado el comentario
        /// </summary>
        public virtual GameModel Game { get; set; }

        public CommentDto ToDto(bool includes = false)
        {
            var comment = InitializeDto();

            if (includes)
                if (this.Game != null)
                    comment.Game = this.Game.ToDto();

            return comment;
        }

        private CommentDto InitializeDto()
        {
            return new CommentDto()
            {
                Id = this.Id,
                Text = this.Text,
                Date = this.Date,
                Recommended = this.Recommended,
                Visibility = this.Visibility,
                GameId = this.GameId
            };
        }
    }
}

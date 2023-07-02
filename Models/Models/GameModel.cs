using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dtos;

namespace Models.Models
{
    [Table("Games")]
    public class GameModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string? Image { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<GenreModel> Genres { get; set; }

        public virtual ICollection<ConsoleModel> Consoles { get; set; }

        public virtual ICollection<CommentModel> Comments { get; set; }

        public virtual ICollection<CollectionModel> Collections { get; set; }

        public virtual ICollection<PlayerGameStatusModel> PlayerGameStatus { get; set; }

        public GameDto ToDto(bool includes = false)
        {
            var game = InitializeDto();

            if (includes)
            {
                if(this.Genres != null)
                    game.Genres = this.Genres.Select(s => s.ToDto());

                if(this.Consoles != null)
                    game.Consoles = this.Consoles.Select(s => s.ToDto());

                if (this.Comments != null)
                    game.Comments = this.Comments.Select(s => s.ToDto());

                if (this.Collections != null)
                    game.Collections = this.Collections.Select(s => s.ToDto());

                if (this.PlayerGameStatus != null)
                    game.PlayerGameStatus = this.PlayerGameStatus.Select(s => s.ToDto());
            }

            return game;
        }

        private GameDto InitializeDto()
        {
            return new GameDto 
            { 
                Id = this.Id,
                Name = this.Name,
                Image = this.Image,
                ReleaseDate = this.ReleaseDate
            };
        }

    }
}

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
    [Table("Genres")]
    public class GenreModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<GameModel> Games { get; set; }

        public GenreDto ToDto(bool includes = false)
        {
            var genre = InitializeDto();

            if (includes)
                if(this.Games != null)
                    genre.Games = this.Games.Select(s => s.ToDto());

            return genre;
        }

        private GenreDto InitializeDto()
        {
            return new GenreDto 
            { 
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}

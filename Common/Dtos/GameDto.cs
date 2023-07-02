using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class GameDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string? Image { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual IEnumerable<GenreDto> Genres { get; set; }

        public virtual IEnumerable<ConsoleDto> Consoles { get; set; }

        public virtual IEnumerable<CommentDto> Comments { get; set; }

        public virtual IEnumerable<CollectionDto> Collections { get; set; }

        public virtual IEnumerable<PlayerGameStatusDto> PlayerGameStatus { get; set; }
    }
}

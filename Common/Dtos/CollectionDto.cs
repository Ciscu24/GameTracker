using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class CollectionDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string UserId { get; set; }

        public virtual UserDto User { get; set; }

        public virtual IEnumerable<GameDto> Games { get; set; }
    }
}

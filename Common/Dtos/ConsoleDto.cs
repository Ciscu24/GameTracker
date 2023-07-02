using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class ConsoleDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<GameDto> Games { get; set; }
    }
}

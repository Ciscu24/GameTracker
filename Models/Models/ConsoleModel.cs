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
    [Table("Consoles")]
    public class ConsoleModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<GameModel> Games { get; set; }

        public ConsoleDto ToDto(bool includes = false)
        {
            var console = InitializeDto();

            if (includes)
                if (this.Games != null)
                    console.Games = this.Games.Select(s => s.ToDto());

            return console;
        }

        private ConsoleDto InitializeDto()
        {
            return new ConsoleDto 
            { 
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Common.Dtos;

namespace Models.Models
{
    [Table("Collections")]
    public class CollectionModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        [ForeignKey("Users")]
        public string UserId { get; set; }

        public virtual UserModel User { get; set; }

        public virtual ICollection<GameModel> Games { get; set; }

        public CollectionDto ToDto(bool includes = false)
        {
            var collection = InitializeDto();

            if(includes)
            {
                if(this.User != null)
                    collection.User = this.User.ToDto();

                if(this.Games != null)
                    collection.Games = this.Games.Select(s => s.ToDto());
            }

            return collection;
        }

        private CollectionDto InitializeDto()
        {
            return new CollectionDto 
            { 
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                UserId = this.UserId
            };
        }

    }
}

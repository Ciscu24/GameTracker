using Common.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("Users")]
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<UserModel> Followers { get; set; }
        public virtual ICollection<UserModel> Following { get; set; }

        public UserDto ToDto(bool includes = false)
        {
            var followers = new List<UserDto>();
            var following = new List<UserDto>();
            var user = new UserDto() { 
                Id = this.Id,
                UserName = this.UserName,
                FullName = this.FullName,
                Email = this.Email,
                Password = this.Password,
                Followers = followers,
                Following = following 
            };
            if (includes)
            {
                if (this.Followers != null)
                {
                    followers = this.Followers.Select(s => s.ToDto()).ToList();
                    user.Followers = followers;
                }
                    
                if(this.Following != null)
                {
                    following = this.Following.Select(s => s.ToDto()).ToList();
                    user.Following = following;
                }
            }

            return user;
        }
    }
}

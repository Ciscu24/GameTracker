namespace Common.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public IEnumerable<UserDto> Followers { get; set; }

        public IEnumerable<UserDto> Following { get; set; }

        public IEnumerable<PlayerGameStatusDto> PlayerGameStatus { get; set; }
    }
}

namespace Common.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<UserDto> Followers { get; set; }
        public List<UserDto> Following { get; set; }
    }
}

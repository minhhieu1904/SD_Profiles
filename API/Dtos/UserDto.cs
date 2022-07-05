namespace API.Dtos
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDelete { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}
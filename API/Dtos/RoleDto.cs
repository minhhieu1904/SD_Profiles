namespace API.Dtos
{
    public class RoleDto
    {
        public string id {get;set;}
        public string name {get;set;}
        public bool isActive {get;set;}
    }
    public class RolesUserDto {
        public string userName {get;set;}
        public List<RoleDto> roles {get;set;}
    }
}
using Microsoft.AspNetCore.Identity;


namespace API.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public override string UserName { get; set; }
        public override string NormalizedUserName { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDelete { get; set; }
        public string Avatar { get; set; }
    }

}

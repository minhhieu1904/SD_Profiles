using Microsoft.AspNetCore.Identity;


namespace API.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public bool IsDelete { get; set; }
    }
}

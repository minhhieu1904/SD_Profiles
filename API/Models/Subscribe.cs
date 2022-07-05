using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class Subscribe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Email { get; set; }
    }
}
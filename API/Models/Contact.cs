using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public partial class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Subject { get; set; }
        [Required]
        [StringLength(250)]
        public string Email { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Phone { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        public string Message { get; set; }
        public bool? Status { get; set; }
        [StringLength(250)]
        public string Create_By { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Create_Time { get; set; }
        [StringLength(250)]
        public string Update_By { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Update_Time { get; set; }
    }
}
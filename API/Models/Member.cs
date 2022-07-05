using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public partial class Member
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Phone { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
        [StringLength(250)]
        public string Avatar { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [Column(TypeName = "ntext")]
        public string Skill { get; set; }
        public int? Position_Id { get; set; }
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
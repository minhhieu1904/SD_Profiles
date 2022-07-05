using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public partial class Position
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
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
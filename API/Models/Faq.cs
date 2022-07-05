using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public partial class Faq
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Title { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
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
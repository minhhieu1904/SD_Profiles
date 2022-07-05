using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public partial class Menu
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        [Unicode(false)]
        public string Path { get; set; }
        [StringLength(250)]
        public string Title { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Icon { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Type { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string BadgeType { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string BadgeValue { get; set; }
        public bool? Active { get; set; }
        public int? Sequent { get; set; }
        public bool? Bookmark { get; set; }
        public Guid? Role_Id { get; set; }
        public int? Parent_Id { get; set; }
    }
}
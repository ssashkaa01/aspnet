using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Entities
{
    [Table("photos")]
    public class Photo : BaseEntity<int>
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Image { get; set; }   
    }
}
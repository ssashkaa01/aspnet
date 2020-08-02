using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Entities
{
    [Table("posts")]
    public class Post : BaseEntity<int>
    {
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
            
        [Required, StringLength(255)]
        public string Title { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }   

        public virtual Category Category { get; set; }
    }
}
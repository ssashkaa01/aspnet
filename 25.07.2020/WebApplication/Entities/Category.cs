using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Entities
{
    [Table("categories")]
    public class Category : BaseEntity<int>
    {
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Entities
{
    [Table("products_categories")]
    public class ProductCategory : BaseEntity<int>
    {
        [Required, StringLength(255)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
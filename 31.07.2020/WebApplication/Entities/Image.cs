
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Entities
{
    public class Image : BaseEntity<int>
    {
        [Required, StringLength(255)]
        public string Url { get; set; }
    }
}
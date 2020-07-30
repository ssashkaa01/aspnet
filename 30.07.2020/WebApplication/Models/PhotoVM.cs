using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class PhotoVM
    {
        public int Id { get; set; }
        
        [Display(Name = "Назва фото")]
        public string Name { get; set; }

        [Display(Name = "Фото")]
        public string UrlLink { get; set; }
    }

    public class PhotoAddVM
    {
        [Display(Name = "Вкажіть назву фото")]
        [Required(ErrorMessage = "Вкажіть назву фото")]
        public string Name { get; set; }

        [Display(Name = "Оберіть фото")]
        [Required(ErrorMessage = "Оберіть фото")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
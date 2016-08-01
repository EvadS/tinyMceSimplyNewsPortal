using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimplyNewsPortal.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата публикации")]
        public DateTime PostedOn { get; set; }

        [Display(Name = "Теги")]
        public string Tags { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Содержание")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Content { get; set; }
    }
}
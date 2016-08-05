using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimplyNewsPortal.Models
{
    public class BlogPost
    {
        //TODO: убрать при реализации паттерна репозитарий 
        public BlogPost()
        {
            DateOfCreation = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Заголовок", Prompt = "Введите заголовок")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата публикации")]
        public DateTime PostedOn { get; set; }

        [Required]
        [Display(Name = "Теги")]
        public string Tags { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Содержание")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfCreation { get; set; }
    }


    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
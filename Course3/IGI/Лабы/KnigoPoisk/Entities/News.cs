using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class News
    {
        public int Id { get; set; }

        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Display(Name = "Фото")]
        public string Photo { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Текст")]
        public string Text { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CreateDate { get; set; }
    }
}

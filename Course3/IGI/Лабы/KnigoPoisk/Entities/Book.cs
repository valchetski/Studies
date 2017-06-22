using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Book
    {
        public Book()
        {
            Authors = new List<Author>();
        }
        public int Id { get; set; }

        [Display(Name = "Русское название")]
        [StringLength(100, ErrorMessage = "{0} не может быть более {1} символов.")]
        public string NameRus { get; set; }

        [Display(Name = "Оригинальное название")]
        [StringLength(100, ErrorMessage = "{0} не может быть более {1} символов.")]
        public string NameOriginal { get; set; }

        [Display(Name = "Фото")]
        [Required, FileExtensions(Extensions = "jpg, png",
             ErrorMessage = "Странная фотка. Найди другую")]
        public string Photo { get; set; }

        [Display(Name = "Год")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} год не может быть меньше {1}")]
        public int Year { get; set; }

        [Display(Name = "Автор")]
        public virtual ICollection<Author> Authors { get; set; }

        [NotMapped]
        [Display(Name = "Автор")]
        public string AuthorName { get; set; }

        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Display(Name = "Язык")]
        public string Language { get; set; }

        [Display(Name = "Экранизации")]
        public string Screenings { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}

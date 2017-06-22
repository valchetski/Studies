using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }
        public int Id { get; set; }

        [Display(Name = "Имя на русском")]
        public string NameRus { get; set; }

        [Display(Name = "Имя на иностранном")]
        public string NameOriginal { get; set; }

        [Display(Name = "Фото")]
        public string Photo { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Место рождения")]
        public string PlaceOfBirth { get; set; }

        [Display(Name = "Дата смерти")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? DeadDate { get; set; }

        [Display(Name = "Национальность")]
        public string Nationality { get; set; }

        public virtual ICollection<Book> Books { get; set; } 
    }
}

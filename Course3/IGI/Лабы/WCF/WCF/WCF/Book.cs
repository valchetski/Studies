namespace WCF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string NameRus { get; set; }

        [StringLength(100)]
        public string NameOriginal { get; set; }

        [Required]
        public string Photo { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public string Language { get; set; }

        public string Screenings { get; set; }

        public string Description { get; set; }
    }
}

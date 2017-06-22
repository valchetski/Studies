using System;

namespace KnigoPoisk.Models
{
    public class SearchModel
    {
        public int Id { get; set; }
        public string TitleRus { get; set; }
        public string TitleOriginal { get; set; }
        public Type EntityType { get; set; }
        public string Photo { get; set; }
    }
}
namespace WCF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KnigoPoiskModel : DbContext
    {
        public KnigoPoiskModel()
            : base("name=KnigoPoiskModel")
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

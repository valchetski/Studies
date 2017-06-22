using System.Data.Entity;

namespace GenealogicTree.Entities
{
    public class PersonContext :  DbContext 
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Relative> Relatives { get; set; }
        public DbSet<Me> Me { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(p => p.BirthDay)
                .HasColumnType("datetime2")
                .HasPrecision(0).IsOptional();

            modelBuilder.Entity<Person>()
                .Property(p => p.DeadDay)
                .HasColumnType("datetime2")
                .HasPrecision(0).IsOptional();

            modelBuilder.Entity<Relative>()
                .Property(p => p.PersonId).IsRequired();
            modelBuilder.Entity<Relative>()
                .Property(p => p.RelativeOfPersonId).IsRequired();

            modelBuilder.Entity<Relative>().HasRequired(r => r.Person).WithMany().WillCascadeOnDelete(false);
        }
    }
}

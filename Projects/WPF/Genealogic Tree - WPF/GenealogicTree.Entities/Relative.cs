namespace GenealogicTree.Entities
{
    public class Relative
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int RelativeOfPersonId { get; set; }
        public virtual Person RelativeOfPerson { get; set; }

        public string KindOfRelative { get; set; }
    }
}

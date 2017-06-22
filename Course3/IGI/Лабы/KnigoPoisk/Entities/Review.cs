using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Review
    {
        public int Id { get; set; }
        public DateTime? PublicationDate { get; set; }
        public bool IsPositive { get; set; }
        public Book Book { get; set; }
       // public User User { get; set; }
    }
}

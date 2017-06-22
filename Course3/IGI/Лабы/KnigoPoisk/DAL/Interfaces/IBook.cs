using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL.Interfaces
{
    public interface IBook
    {
        List<Book> GetAll(); 
        void Save(Book book);
        void Delete(Book book);
        Book Find(int? id);
    }
}

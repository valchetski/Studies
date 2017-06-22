using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IBookService
    {
        public List<Book> GetBooks()
        {
            List<Book> books;
            using (var knigoPoiskModel = new KnigoPoiskModel())
            {
                books = knigoPoiskModel.Books.ToList();
            }
            return books;
        }

        public void Save(Book book)
        {
            using (var knigoPoiskModel = new KnigoPoiskModel())
            {
                knigoPoiskModel.Books.AddOrUpdate(book);
                knigoPoiskModel.SaveChanges();
            }
        }

        public Book Find(int? id)
        {
            Book book;
            using (var knigoPoiskModel = new KnigoPoiskModel())
            {
                book = knigoPoiskModel.Books.Find(id);
            }
            return book;
        }

        public void Delete(Book book)
        {
            using (var knigoPoiskModel = new KnigoPoiskModel())
            {
                knigoPoiskModel.Books.Remove(knigoPoiskModel.Books.Find(book.Id));
                knigoPoiskModel.SaveChanges();
            }
        }
    }
}

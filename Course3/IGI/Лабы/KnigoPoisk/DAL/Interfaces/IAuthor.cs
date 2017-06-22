using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface IAuthor
    {
        List<Author> GetAll();
        void Save(Author author);
        void Delete(Author author);
        Author Find(int? id);
    }
}

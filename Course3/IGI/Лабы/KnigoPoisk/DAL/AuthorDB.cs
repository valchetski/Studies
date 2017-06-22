using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Interfaces;
using Entities;

namespace DAL
{
    public class AuthorDB : IAuthor
    {
        public List<Author> GetAll()
        {
            var authors = new List<Author>();
            using (var context = new KnigoPoiskContext())
            {
                authors = context.Authors.ToList();
            }
            return authors;
        }
        
        public Author Find(int? id)
        {
            using (var context = new KnigoPoiskContext())
            {
                return context.Authors.Find(id);
            }
        }


        public void Save(Author author)
        {
            using (var context = new KnigoPoiskContext())
            {
                context.Authors.AddOrUpdate(author);
                context.SaveChanges();
            }
        }
        public void Delete(Author author)
        {
            using (var context = new KnigoPoiskContext())
            {
                context.Authors.Remove(context.Authors.Find(author.Id));
                context.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using DAL.Interfaces;
using Entities;

namespace DAL
{
    public class BookDB : IBook
    {
        public List<Book> GetAll()
        {
            var books = new List<Book>();
            using (var context = new KnigoPoiskContext())
            {
                books = context.Books.ToList();
            }
            return books;
        }
        
        public Book Find(int? id)
        {
            Book book;
            using (var context = new KnigoPoiskContext())
            {
                context.Books.Include("Authors");
                book = context.Books.Find(id);
                List<Author> myList = book.Authors.ToList();
                book.Authors = new List<Author>();
                book.Authors = myList;
            }
            return book;
        }


        public void Save(Book book)
        {
            using (var context = new KnigoPoiskContext())
            {
                try
                {
                    context.Books.AddOrUpdate(book);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    var i = ex.EntityValidationErrors;
                }
                
            }
        }
        public void Delete(Book book)
        {
            using (var context = new KnigoPoiskContext())
            {
                context.Books.Remove(context.Books.Find(book.Id));
                context.SaveChanges();
            }
        }
    }
}

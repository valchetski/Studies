using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Entities;
using KnigoPoisk.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class BooksTest
    {
        private BooksController controller;
        private Book book;

        private void Initialize()
        {
            IBook bookDb = new BookDB();
            IAuthor authorDb = new AuthorDB();
            controller = new BooksController(bookDb, authorDb);
            book = new Book { NameRus = "apacha", NameOriginal = "cha", Photo = "monte-cristo.jpg" };
            controller.Create(book);
        }

        [TestMethod]
        public void AddBookTest()
        {
            Initialize();

            var viewResult = controller.Index() as ViewResult;
            List<Book> list = viewResult.ViewBag.Books;
            book.Id = list.Last().Id;

            Book newBook = list.LastOrDefault();
            controller.DeleteConfirmed(list.Last().Id);
            AssertAreEqual(book, newBook);
        }

        [TestMethod]
        public void DeleteBookTest()
        {
            Initialize();

            var viewResult = controller.Index() as ViewResult;
            List<Book> list = viewResult.ViewBag.Books;
            book.Id = list.Last().Id;

            controller.DeleteConfirmed(book.Id);
            viewResult = controller.Index() as ViewResult;
            list = viewResult.ViewBag.Books;
            if (list.Count != 0)
            {
                Assert.AreNotEqual(book.Id, list.Last().Id);
            }
        }

        [TestMethod]
        public void UpdateBookTest()
        {
            Initialize();

            var viewResult = controller.Index() as ViewResult;
            List<Book> list = viewResult.ViewBag.Books;

            var newBook = list.Last();
            newBook.NameRus = "changedApacha";
            controller.Edit(newBook);

            viewResult = controller.Index() as ViewResult;
            list = viewResult.ViewBag.Books;
            newBook = list.Last();

            controller.DeleteConfirmed(list.Last().Id);

            Assert.AreNotEqual(book.NameRus, newBook.NameRus);
        }

        private void AssertAreEqual(Book expected, Book actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.NameRus, actual.NameRus);
            Assert.AreEqual(expected.NameOriginal, actual.NameOriginal);
        }
    }
}

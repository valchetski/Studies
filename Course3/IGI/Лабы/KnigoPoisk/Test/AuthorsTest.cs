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
    public class AuthorsTest
    {
        private AuthorsController controller;
        private Author author;

        private void Initialize()
        {
            IAuthor authorDb = new AuthorDB();
            controller = new AuthorsController(authorDb);
            author = new Author { NameRus = "apacha", NameOriginal = "cha", Photo = "monte-cristo.jpg" };
            controller.Create(author);
        }

        [TestMethod]
        public void AddAuthorTest()
        {
            Initialize();

            var viewResult = controller.Index() as ViewResult;
            List<Author> list = viewResult.ViewBag.Authors;
            author.Id = list.Last().Id;

            Author newAuthor = list.LastOrDefault();
            controller.DeleteConfirmed(list.Last().Id);
            AssertAreEqual(author, newAuthor);
        }

        [TestMethod]
        public void DeleteAuthorTest()
        {
            Initialize();

            var viewResult = controller.Index() as ViewResult;
            List<Author> list = viewResult.ViewBag.Authors;
            author.Id = list.Last().Id;

            controller.DeleteConfirmed(author.Id);
            viewResult = controller.Index() as ViewResult;
            list = viewResult.ViewBag.Authors;
            if (list.Count != 0)
            {
                Assert.AreNotEqual(author.Id, list.Last().Id);
            }
        }

        [TestMethod]
        public void UpdateAuthorTest()
        {
            Initialize();

            var viewResult = controller.Index() as ViewResult;
            List<Author> list = viewResult.ViewBag.Authors;

            var newAuthor = list.Last();
            newAuthor.NameRus = "changedApacha";
            controller.Edit(newAuthor);

            viewResult = controller.Index() as ViewResult;
            list = viewResult.ViewBag.Authors;
            newAuthor = list.Last();

            controller.DeleteConfirmed(list.Last().Id);

            Assert.AreNotEqual(author.NameRus, newAuthor.NameRus);
        }

        private void AssertAreEqual(Author expected, Author actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.NameRus, actual.NameRus);
            Assert.AreEqual(expected.NameOriginal, actual.NameOriginal);
        }
    }
}

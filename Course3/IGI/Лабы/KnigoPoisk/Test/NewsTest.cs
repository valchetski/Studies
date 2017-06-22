using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Entities;
using KnigoPoisk.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class NewsTest
    {
        private NewsController controller;
        private News news;

        private void Initialize()
        {
            INews newsDb = new NewsDB();
            controller = new NewsController(newsDb);
            news = new News() { Title = "apacha", Text = "cha", Photo = "monte-cristo.jpg" };
            controller.Create(news);
        }

        [TestMethod]
        public void AddNewsTest()
        {
            Initialize();

            var viewResult = controller.Index() as ViewResult;
            List<News> list = viewResult.ViewBag.News;
            news.Id = list.Last().Id;

            News newNews = list.LastOrDefault();
            controller.DeleteConfirmed(list.Last().Id);
            AssertAreEqual(news, newNews);
        }

        [TestMethod]
        public void DeleteNewsTest()
        {
            Initialize();

            var viewResult = controller.Index() as ViewResult;
            List<News> list = viewResult.ViewBag.News;
            news.Id = list.Last().Id;

            controller.DeleteConfirmed(news.Id);
            viewResult = controller.Index() as ViewResult;
            list = viewResult.ViewBag.News;
            if (list.Count != 0)
            {
                Assert.AreNotEqual(news.Id, list.Last().Id);
            }
        }

        [TestMethod]
        public void UpdateNewsTest()
        {
            Initialize();

            string oldTitle = news.Title;

            var viewResult = controller.Index() as ViewResult;
            List<News> list = viewResult.ViewBag.News;

            News newNews = list.Last();
            newNews.Title = "changedApacha";
            controller.Edit(newNews);

            viewResult = controller.Index() as ViewResult;
            list = viewResult.ViewBag.News;
            newNews = list.Last();

            controller.DeleteConfirmed(list.Last().Id);

            Assert.AreNotEqual(oldTitle, newNews.Title);
        }

        private void AssertAreEqual(News expected, News actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Title, actual.Title);
            Assert.AreEqual(expected.Text, actual.Text);
        }
    }
}

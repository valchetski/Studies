using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAL.Interfaces;
using Entities;
using KnigoPoisk.Models;

namespace KnigoPoisk.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBook bookDB;
        private readonly IAuthor authorDB;
        public SearchController(IBook initBookDb, IAuthor initAuthorDb)
        {
            bookDB = initBookDb;
            authorDB = initAuthorDb;
        }

        public ActionResult Search(string title)
        {
            title = title.ToLower().Trim();
            var searchResult = new List<SearchModel>();

            if (title != "")
            {
                var books =
                    bookDB.GetAll()
                        .Where(book => book.NameRus.ToLower().Contains(title) || book.NameOriginal.ToLower().Contains(title));
                searchResult =
                    books.Select(
                        book =>
                            new SearchModel
                            {
                                TitleRus = book.NameRus,
                                Id = book.Id,
                                EntityType = typeof(Book),
                                Photo = book.Photo,
                                TitleOriginal = book.NameOriginal
                            })
                        .ToList();

                var authors =
                    authorDB.GetAll()
                        .Where(
                            author =>
                                author.NameRus.ToLower().Contains(title) || author.NameOriginal.ToLower().Contains(title));
                searchResult.AddRange(
                    authors.Select(
                        author =>
                            new SearchModel
                            {
                                TitleRus = author.NameRus,
                                Id = author.Id,
                                EntityType = typeof(Author),
                                Photo = author.Photo,
                                TitleOriginal = author.NameOriginal
                            }));
            }


            return PartialView("_Search", searchResult);
        }


        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string title)
        {
            Search(title);
            return View();
        }
    }
}
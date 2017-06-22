using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAL.Interfaces;
using Entities;
using KnigoPoisk.Models;

namespace KnigoPoisk.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBook booksDb;
        private readonly IAuthor authorsDb;
        private readonly INews newsDb;
        public HomeController(IBook initialBookDb, IAuthor initialAuthorDb, INews initialNewsDb)
        {
            booksDb = initialBookDb;
            authorsDb = initialAuthorDb;
            newsDb = initialNewsDb;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region NewBooksCarousel

        [HttpGet]
        public ActionResult NewBooksCarousel()
        {
            return PartialView("_Carousel", GetNewBooks());
        }

        private List<CarouselModel> GetNewBooks()
        {
            var allBooks = booksDb.GetAll();
            var newBooks = new List<CarouselModel>();
            foreach (var book in allBooks)
            {
                var carouselModel = new CarouselModel
                {
                    Id = book.Id,
                    Name = book.NameRus,
                    Photo = book.Photo,
                    ControllerName = "Books",
                    CarouselName = "Новые книги"
                };

                newBooks.Add(carouselModel);
            }
            return newBooks;
        }

        #endregion

        #region PopularBooksCarousel

        [HttpGet]
        public ActionResult PopularBooksCarousel()
        {
            return PartialView("_Carousel", GetPopularBooks());
        }

        private List<CarouselModel> GetPopularBooks()
        {
            var allBooks = booksDb.GetAll();
            var newBooks = new List<CarouselModel>();
            foreach (var book in allBooks)
            {
                var carouselModel = new CarouselModel
                {
                    Id = book.Id,
                    Name = book.NameRus,
                    Photo = book.Photo,
                    ControllerName = "Books",
                    CarouselName = "Популярные книги"
                };

                newBooks.Add(carouselModel);
            }
            return newBooks;
        }

        #endregion

        #region PopularAuthorsCarousel

        [HttpGet]
        public ActionResult PopularAuthorsCarousel()
        {
            return PartialView("_Carousel", GetPopularAuthors());
        }

        private List<CarouselModel> GetPopularAuthors()
        {
            var allAuthors = authorsDb.GetAll();
            var popularAuthors = new List<CarouselModel>();
            foreach (var author in allAuthors)
            {
                var carouselModel = new CarouselModel
                {
                    Id = author.Id,
                    Name = author.NameRus,
                    Photo = author.Photo,
                    ControllerName = "Authors",
                    CarouselName = "Популярные авторы"
                };

                popularAuthors.Add(carouselModel);
            }
            return popularAuthors;
        }

        #endregion

        #region NewsRegion

        [HttpGet]
        public ActionResult News()
        {
            return PartialView("_NewsOnHomePage", GetNews());
        }

        private List<News> GetNews()
        {
            var allNews = newsDb.Newses.ToList();
            return allNews;
        }

        #endregion

        #region Top250Region

        [HttpGet]
        public ActionResult Top250()
        {
            ViewBag.BookListName = "Top 250";
            return PartialView("_BookList", GetTop250());
        }

        private List<Book> GetTop250()
        {
            var allBooks = booksDb.GetAll();
            return allBooks;
        }

        #endregion
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
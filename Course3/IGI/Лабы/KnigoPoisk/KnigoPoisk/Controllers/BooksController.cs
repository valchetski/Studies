using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Entities;

namespace KnigoPoisk.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBook booksDb;
        private readonly IAuthor authorsDb;
        public BooksController(IBook initialBookDb, IAuthor initialAuthorDb)
        {
            booksDb = initialBookDb;
            authorsDb = initialAuthorDb;
        }

        public BooksController()
        {
            booksDb = new BookDB();
            authorsDb = new AuthorDB();
        }

        // GET: Books
        public ActionResult Index()
        {
            ViewBag.Books = booksDb.GetAll().ToList<Book>();
            return View(booksDb.GetAll().ToList<Book>());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = booksDb.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Create([Bind(Include = "Id,NameRus,NameOriginal,Photo,Year,AuthorName,Genre,Screenings,Language,Description")] Book book)
        {
            //book.Genre = GetGenre(book.Genre);
            book.Authors = GetAuthors(book.AuthorName);
            if (ModelState.IsValid)
            {
                booksDb.Save(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = booksDb.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Edit([Bind(Include = "Id,NameRus,NameOriginal,Photo,Year,Genre,Screenings,Language,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                booksDb.Save(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = booksDb.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = booksDb.Find(id);
            booksDb.Delete(book);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //bookDb.Dispose();
            }
            base.Dispose(disposing);
        }

        private List<string> GetGenre(string genres)
        {
            //разбиваем то, что ввели на список и удаляем повторяющиеся элементы
            return genres.Split(new []{", "}, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorName">может использовать и ID автора в БД</param>
        /// <returns></returns>
        private List<Author> GetAuthors(string authorName)
        {
            var cha = authorsDb.GetAll();
            var myAuthors = authorsDb.GetAll().Where(author => author.NameOriginal == authorName || author.NameRus == authorName).ToList();
            if (myAuthors.Count == 0)
            {
                int i;
                if (int.TryParse(authorName, out i))
                {
                    myAuthors = authorsDb.GetAll().Where(author => author.Id == Convert.ToInt32(authorName)).ToList();
                }
            }
            return myAuthors;
        }
    }
}

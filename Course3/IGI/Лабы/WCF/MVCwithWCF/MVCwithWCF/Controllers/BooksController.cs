using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCwithWCF.ServiceReferenceWCF;

namespace MVCwithWCF.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            using (var bookServiceClient = new BookServiceClient())
            {
                return View(bookServiceClient.GetBooks());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameRus,NameOriginal,Photo,Year,AuthorName,Genre,Screenings,Language,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                using (var bookServiceClient = new BookServiceClient())
                {
                    bookServiceClient.Save(book);
                    return RedirectToAction("Index");
                }
                
            }

            return View(book);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book;
            using (var bookServiceClient = new BookServiceClient())
            {
                book = bookServiceClient.Find(id);
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var bookServiceClient = new BookServiceClient())
            {
                Book book = bookServiceClient.Find(id);
                bookServiceClient.Delete(book);
            }
            
            return RedirectToAction("Index");
        }


    }
}
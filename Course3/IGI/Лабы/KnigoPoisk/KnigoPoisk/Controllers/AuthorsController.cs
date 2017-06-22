using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Entities;

namespace KnigoPoisk.Controllers
{
    public class AuthorsController : Controller
    {
        private IAuthor authorDB;
        public AuthorsController(IAuthor initialAuthorDb)
        {
            authorDB = initialAuthorDb;
        }

        // GET: Authors
        public ActionResult Index()
        {
            ViewBag.Authors = authorDB.GetAll();
            return View(authorDB.GetAll());
        }

        // GET: Authors/Details/5
        //[OutputCache(Duration = 3600, VaryByParam = "None")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = authorDB.Find(id);

            //использование WCF
            
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameRus,NameOriginal,Photo,BirthDate,PlaceOfBirth,DeadDate,Nationality")] Author author)
        {
            if (ModelState.IsValid)
            {
                authorDB.Save(author);
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = authorDB.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameRus,NameOriginal,Photo,BirthDate,PlaceOfBirth,DeadDate,Nationality")] Author author)
        {
            if (ModelState.IsValid)
            {
                authorDB.Save(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = authorDB.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = authorDB.Find(id);
            authorDB.Delete(author);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

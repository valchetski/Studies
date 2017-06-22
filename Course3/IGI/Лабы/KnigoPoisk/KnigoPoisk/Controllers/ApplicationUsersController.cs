using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KnigoPoisk.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace KnigoPoisk.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationUsers
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            for (int i = 0; i < users.Count; i++)
            {
                users[i].RolesNames = "";
                foreach (IdentityUserRole identityUserRole in users[i].Roles)
                {
                    users[i].RolesNames += db.Roles.FirstOrDefault(r => r.Id == identityUserRole.RoleId).Name + ", ";
                }
            }
            return View(users);
        }

        // GET: ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {
            TempData["Roles"] = db.Roles.Select(identityRole => identityRole.Name).ToList();
            TempData.Keep("Roles");
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RolesNames,Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            var rolesNames =
                applicationUser.RolesNames.Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Distinct()
                    .ToList();
            if (ModelState.IsValid)
            {
                foreach (var rolesName in rolesNames)
                {
                    var userRole = new IdentityUserRole
                    {
                        RoleId = (db.Roles.FirstOrDefault(role => role.Name == rolesName)).Id,
                        UserId = applicationUser.Id
                    };
                    applicationUser.Roles.Add(userRole);
                }
                db.Users.Add(applicationUser);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);

            if (applicationUser == null)
            {
                return HttpNotFound();
            }

            applicationUser.RolesNames = "";
            foreach (IdentityUserRole identityUserRole in applicationUser.Roles)
            {
                applicationUser.RolesNames += db.Roles.FirstOrDefault(r => r.Id == identityUserRole.RoleId).Name + ", ";
            }
            
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RolesNames,Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            var rolesNames = applicationUser.RolesNames.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Distinct()
                    .ToList();
            if (ModelState.IsValid)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                foreach (var identityRole in db.Roles.ToList())
                {
                    var userRole = new IdentityUserRole
                    {
                        RoleId = (db.Roles.FirstOrDefault(role => role.Name == identityRole.Name)).Id,
                        UserId = applicationUser.Id
                    };

                    if (rolesNames.Contains(identityRole.Name))
                    {
                        if (!applicationUser.Roles.Contains(userRole))
                        {
                            //applicationUser.Roles.Add(userRole);
                            userManager.AddToRole(applicationUser.Id, identityRole.Name);
                        }
                    }
                    else
                    {
                        userManager.RemoveFromRole(applicationUser.Id, identityRole.Name);
                    }
                }

                db.Users.AddOrUpdate(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void CompleteRoles()
        { }
    }
}

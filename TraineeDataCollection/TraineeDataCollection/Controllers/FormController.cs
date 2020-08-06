using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using TraineeDataCollection.Models;

namespace TraineeDataCollection.Controllers
{
    public class FormController : Controller
    {
        [Authorize(Roles = "admin, user")]
        public ActionResult Home()
        {
            return View();
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult Add()
        {

            if (User.IsInRole("user"))
            {
                User user = null;

                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

                    if (db.TraineeForms.Include(a => a.User).Where(b => b.UserId == user.Id).ToList().Count == 0)
                    {
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Home", "Form");
                    }
                }
            }
            return View();
        }

        // TODO: simplify
        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public ActionResult Add(TraineeForm form)
        {
            if (ModelState.IsValid)
            {
                using (UserContext db = new UserContext())
                {
                    TraineeForm currentForm = new TraineeForm()
                    {
                        Name = form.Name,
                        Surname = form.Surname,
                        MiddleName = form.MiddleName,
                        NameOfTheUniversity = form.NameOfTheUniversity,
                        UniversityCourse = form.UniversityCourse,
                        Faculty = form.Faculty,
                        Phone = form.Phone,
                        Email = form.Email,
                        Info = form.Info,
                    };

                    currentForm.CreateDate = DateTime.Now;
                    currentForm.ChangeDate = DateTime.Now;
                    currentForm.FormCreater = User.Identity.Name;
                    currentForm.AuthorOfLastChange = User.Identity.Name;

                    User user = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

                    db.TraineeForms.Add(currentForm);
                    user.TraineeForms.Add(currentForm);

                    db.SaveChanges();
                    return RedirectToAction("Home", "Form");
                }
            }
            return View(form);
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult Show()
        {
            using (UserContext db = new UserContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
                if (User.IsInRole("admin"))
                {
                    //var forms = db.TraineeForms.Include(a => a.User).Where(b => b.UserId == user.Id).ToList();
                    return View(db.TraineeForms.ToList());
                }
                else if (User.IsInRole("user"))
                {
                    var forms = db.TraineeForms.Include(a => a.User).Where(b => b.UserId == user.Id).ToList();
                    return View(forms);
                }
            }
            return View();
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            using (UserContext db = new UserContext())
            {
                TraineeForm form = db.TraineeForms.Find(id);
                if (form != null)
                {
                    return View(form);
                }
            }
            return HttpNotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public ActionResult Edit(TraineeForm form)
        {
            using (UserContext db = new UserContext())
            {
                db.Entry(form).State = EntityState.Modified;
                form.AuthorOfLastChange = User.Identity.Name;
                form.ChangeDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Home", "Form");
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            using (UserContext db = new UserContext())
            {
                TraineeForm form = db.TraineeForms.Find(id);
                if (form == null)
                {
                    return HttpNotFound();
                }
                return View(form);
            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            using (UserContext db = new UserContext())
            {
                TraineeForm form = db.TraineeForms.Find(id);
                if (form == null)
                {
                    return HttpNotFound();
                }
                db.TraineeForms.Remove(form);
                db.SaveChanges();
                return RedirectToAction("Home", "Form");
            }
        }
    }
}
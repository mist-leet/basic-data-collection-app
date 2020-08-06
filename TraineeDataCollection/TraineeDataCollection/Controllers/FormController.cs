using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using TraineeDataCollection.Models;

namespace TraineeDataCollection.Controllers
{
    public class FormController : Controller
    {
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
                }
                if (user.TraineeForm == null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Home", "Form");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Add(TraineeForm form)
        {
            if (ModelState.IsValid)
            {
                using (UserContext db = new UserContext())
                {
                    if (User.Identity.Name == "user")
                    {
                        TraineeForm currentForm = new TraineeForm()
                        {
                            TraineeFormId = form.TraineeFormId,
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

                        User user = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

                        if (user.TraineeForm == null)
                        {
                            currentForm.CreateDate = DateTime.Now;
                            currentForm.ChangeDate = DateTime.Now;
                            currentForm.FormCreater = User.Identity.Name;
                            currentForm.AuthorOfLastChange = User.Identity.Name;
                        }
                        user.TraineeForm = currentForm;

                        db.TraineeForms.Add(currentForm);
                        db.SaveChanges();
                        return RedirectToAction("Home", "Form");
                    }
                    
                }
            }
            return View(form);
        }

        [Authorize(Roles ="admin, user")]
        public ActionResult Show()
        {
            using (UserContext db = new UserContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
                if (User.IsInRole("admin"))
                {
                    return View(db.TraineeForms.ToList()); 
                }
                else
                {
                    return View(db.TraineeForms.Find(user.Id));
                }
            }
        }
    }
}
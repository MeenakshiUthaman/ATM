using ATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtmUi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           var users = Bank.GetAllUsers();
           return View(users);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(Account Account)
        {
            Bank.CreateAccount(Account.Type, Account.Number, Account.UserId);
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            using (var db = new BankModel1())
            {
                User user = db.Users.Where(s => s.Id ==id).FirstOrDefault();
                return View(user);
            }
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            using (var db = new BankModel1())
            {
                User user = db.Users.Where(s => s.Id == id).FirstOrDefault();
                return View(user);
            }
        }
        [HttpPost]
        [Authorize]
        public ActionResult Delete(User user)
        {
          using(var db = new BankModel1())
            {
                var foundUser = db.Users.Where(u => u.Id == user.Id).FirstOrDefault();
                 db.Users.Remove(foundUser);
                 db.SaveChanges();
                return RedirectToAction("index");
            } 
        }
        public ActionResult Edit(int id)
        {
            using (var db = new BankModel1())
            {
                User user = db.Users.Where(s => s.Id == id).FirstOrDefault();
                return View(user);
            }
        }
        [HttpPost]
        [Authorize]
        public ActionResult Edit(User user)
        {
            using (var db = new BankModel1())
            {
                User Updateuser = db.Users.Where(u => u.Id == user.Id).FirstOrDefault();
                if (Updateuser != null)
                {
                    var originaluser = Updateuser;
                    Updateuser.Name = user.Name;
                    Updateuser.Address = user.Address;
                    Updateuser.PhoneNumber = user.PhoneNumber;
                    Updateuser.SSN = user.SSN;
                    Updateuser.EmailAddress = user.EmailAddress;
                    db.Entry(originaluser).CurrentValues.SetValues(Updateuser);
                    db.SaveChanges();
               }
               
            }
            return RedirectToAction("Index");
        }
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
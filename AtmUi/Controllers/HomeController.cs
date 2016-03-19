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
        [Authorize]
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
           var user = Bank.GetUserId(id);
                return View(user);
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var user = Bank.GetUserId(id);
            return View(user);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Delete(User user)
        {
            Bank.DeleteUser(user.Id);
            return RedirectToAction("index");
         }
        public ActionResult Edit(int id)
        {
            var user = Bank.GetUserId(id);
            return View(user);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Edit(User user)
        {
            Bank.UpdateUser(user);
            return RedirectToAction("index");
        }
        [Authorize]
        public ActionResult ViewCard()
        {
            var Cards = Bank.GetAllCards();
            return View(Cards);
        }
        [Authorize]
        public ActionResult CardDetails (int id)
        {
            var Card = Bank.GetCardId(id);
            return View(Card);
        }
        [Authorize]
        public ActionResult CardDelete (int id)
        {
            var Card = Bank.GetCardId(id);
            return View(Card);
        }
        [HttpPost]
        [Authorize]
        public ActionResult CardDelete(Card card)
        {
            Bank.DeleteCard(card.Id);
            return RedirectToAction("viewCard");
        }
        [Authorize]
        public ActionResult CardEdit (int id)
        {
            var card = Bank.GetCardId(id);
            return View(card);
        }
        [HttpPost]
        [Authorize]
        public ActionResult CardEdit (Card card)
        {
            Bank.UpdateCard(card);
            return RedirectToAction("ViewCard");
        }
        public ActionResult CreateTransaction()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateTransaction(Transaction Transaction)
        {
            Bank.CreateTransation(Transaction.CardId, Transaction.Vendor, Transaction.Date, Transaction.Amount);
            return RedirectToAction("index");
        }
        public ActionResult ViewTransaction()
        {
            var Transaction = Bank.GetAllTransactions();
            return View(Transaction);
        }
        public ActionResult TransactionDetails (int id)
        {
            var Transaction = Bank.GetTransactionId(id);
            return View(Transaction);
        }
        public ActionResult TransactionDelete (int id)
        {
            var Transaction = Bank.GetTransactionId(id);
            return View(Transaction);
        }
        [HttpPost]
        [Authorize]
        public ActionResult TransactionDelete(Transaction Transaction)
        {
            Bank.DeleteTransaction(Transaction.Id);
            return RedirectToAction("viewTransaction");
        }
        public ActionResult TransactionEdit(int id)
        {
            var Transaction = Bank.GetTransactionId(id);
            return View(Transaction);
        }
        [HttpPost]
        [Authorize]
        public ActionResult TransactionEdit(Transaction Transaction)
        {
            Bank.UpdateTransaction(Transaction);
            return RedirectToAction("ViewTransaction");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Bank application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Bank contact page.";

            return View();
        }
    }
}
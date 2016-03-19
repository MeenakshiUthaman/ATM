using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Bank
    {
        #region method
        public static IEnumerable<Account> GetAllAccounts()
        {
            var db = new BankModel1();
            return db.Accounts;
        }
        public static IEnumerable<User> GetAllUsers()
        {
            var db = new BankModel1();
            return db.Users;
        }
        public static IEnumerable<Card> GetAllCards()
        {
            var db = new BankModel1();
            return db.Cards;
        }
        public static IEnumerable<Transaction> GetAllTransactions()
        {
            var db = new BankModel1();
            return db.Transactions;
        }
        public static User CreateUser(string name, string address, long phonenumber, int ssn, string emailaddress)
        {
            using (var db = new BankModel1())
            {
                User u;
                u = new User();
                u.Name = name;
                u.Address = address;
                u.PhoneNumber = phonenumber;
                u.SSN = ssn;
                u.EmailAddress = emailaddress;
                db.Users.Add(u);
                db.SaveChanges();
                return u;
            }
        }
        public static Account CreateAccount(string type, int number, int userid)
        {
            Account b = new Account
            {
                Type = type,
                Number = number,
                UserId = userid,
            };
            using (var db = new BankModel1())
            {
                Card card = db.Cards.Where(s => s.AccountId == b.Id).FirstOrDefault();
                if (card == null)
                {
                    Card c = new Card
                    {
                        Number = ++Card.LastNumber,
                        ExpiryDate = DateTime.Now.AddDays(365),
                        CVV = ++Card.Cvv,
                        Type = "visa",
                        AccountId = b.Id
                    };
                    db.Accounts.Add(b);
                    db.Cards.Add(c);
                }
                db.SaveChanges();
                return b;
            }

        }
        public static Transaction CreateTransation(int cardid, string vendor, DateTime date, decimal amount)
        {
            using (var db = new BankModel1()) 
            {
                Transaction t = new Transaction();
                {
                    t.CardId = cardid;
                    t.Vendor = vendor;
                    t.Date = date;
                    t.Amount = amount;
                    db.Transactions.Add(t);
                    db.SaveChanges();
                    return t;
                }
            }
        }
        public static User GetUserId(int id)
        {
            var db = new BankModel1();
            return db.Users.Where(s => s.Id == id).FirstOrDefault();
        }
        public static void UpdateUser (User updateuser)
        {
            using (var db = new BankModel1())
            {
                User user = db.Users.Where(u => u.Id == updateuser.Id).FirstOrDefault();
                if (user == null)
                    return;
                var originaluser = user;
                user.Name = updateuser.Name;
                user.Address = updateuser.Address;
                user.PhoneNumber = updateuser.PhoneNumber;
                user.SSN = updateuser.SSN;
                user.EmailAddress = updateuser.EmailAddress;
                db.Entry(originaluser).CurrentValues.SetValues(user);
                db.SaveChanges();
            }
        }
        public static void DeleteUser (int userid)
        {
            using (var db = new BankModel1())
            {
                User user  = db.Users.Where(u => u.Id == userid).FirstOrDefault();
                if (user == null)
                    return;
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
        public static Account GetAccountId(int Id)
        {
            var db = new BankModel1();
            return db.Accounts.Where(s => s.Id == Id).FirstOrDefault();
        }
        public static void UpdateAccount (Account updateaccount)
        {
            using (var db = new BankModel1())
            {
                Account Account = db.Accounts.Where(u => u.Id == updateaccount.Id).FirstOrDefault();
                if (Account == null)
                    return;
                var originalaccount = Account;
                Account.Type = updateaccount.Type;
                Account.Number = updateaccount.Number;
                Account.UserId = updateaccount.UserId;
                db.Entry(originalaccount).CurrentValues.SetValues(Account);
                db.SaveChanges();
            }
        }
        public static void DeleteAccount(int Accountid)
        {
            using (var db = new BankModel1())
            {
                Account account = db.Accounts.Where(u => u.Id == Accountid).FirstOrDefault();
                if (account == null)
                    return;
                db.Accounts.Remove(account);
                db.SaveChanges();
            }
        }
        public static Card GetCardId(int Id)
        {
            var db = new BankModel1();
            return db.Cards.Where(s => s.Id == Id).FirstOrDefault();
        }
        public static void DeleteCard(int cardid)
        {
            using (var db = new BankModel1())
            {
                Card card = db.Cards.Where(c => c.Id == cardid ).FirstOrDefault();
                if (card == null)
                    return;
                db.Cards.Remove(card);
                db.SaveChanges();
            }
        }
        public static void UpdateCard(Card updatecard)
        {
            using (var db = new BankModel1())
            {
                Card card = db.Cards.Where(c => c.Id == updatecard.Id).FirstOrDefault();
                if (card == null)
                    return;
                var OriginalCard = card;
                card.Number = updatecard.Number;
                card.CVV = updatecard.CVV;
                card.ExpiryDate = updatecard.ExpiryDate;
                card.Type = updatecard.Type;
                card.AccountId = updatecard.AccountId;
                db.Entry(OriginalCard).CurrentValues.SetValues(card);
                db.SaveChanges();
            }
        }
        public static Transaction GetTransactionId(int Id)
        {
            var db = new BankModel1();
            return db.Transactions.Where(s => s.Id == Id).FirstOrDefault();
        }
        public static void DeleteTransaction (int Transactionid)
        {
            using (var db = new BankModel1())
            {
                Transaction Transaction = db.Transactions.Where(u => u.Id == Transactionid).FirstOrDefault();
                if (Transaction == null)
                    return;
                db.Transactions.Remove(Transaction);
                db.SaveChanges();
            }
        }
        public static void UpdateTransaction (Transaction updatetransaction)
        {
            using (var db = new BankModel1())
            {
                Transaction Transaction = db.Transactions.Where(c => c.Id == updatetransaction.Id).FirstOrDefault();
                if (Transaction == null)
                    return;
                var OriginalTransaction = Transaction;
                Transaction.CardId = updatetransaction.CardId;
                Transaction.Vendor = updatetransaction.Vendor;
                Transaction.Date = updatetransaction.Date;
                Transaction.Amount = updatetransaction.Amount;
                db.Entry(OriginalTransaction).CurrentValues.SetValues(Transaction);
                db.SaveChanges();
            }
        }
        #endregion
    }
    }

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
        public static  IEnumerable<Account> GetAllAccounts()
        {
            var db = new BankModel1();
            return db.Accounts;
        }
        public static IEnumerable<User> GetAllUsers()
        {
            var db = new BankModel1();
             return db.Users;
        }
        public static User CreateUser(string name, string address, int phonenumber, int ssn,string emailaddress)
        {
            using (var db = new BankModel1())
            {
                User u;
                u = new User();
                u.Id = ++User.lastid;
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
            var b = new Account
            {
                Type = type,
                Number = number,
                UserId = userid,
            };
            using (var db = new BankModel1())
            {
                db.Accounts.Add(b);
                db.SaveChanges();
            }
            using (var db = new BankModel1())
            {
                var card = db.Cards.Where(s => s.AccountId == b.Id).FirstOrDefault();
                if (card == null)
                {
                    var c = new Card
                    {
                        Number = ++Card.LastNumber,
                        ExpiryDate = new DateTime(2016, 2, 9),
                        CVV = 102,
                        Type = "visa",
                        AccountId = b.Id
                    };
                    db.Cards.Add(c);
                }
                db.SaveChanges();
                return b;
            }
           
        }
       #endregion
      }
}
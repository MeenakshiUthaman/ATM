using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            User a;
            a = Bank.CreateUser("meenu", "bellevue", 425305, 112,"meenucutey018@gmail.com");
            Console.WriteLine("Id:{0},Name:{1},Address:{2},PhoneNumber:{3},SSN:{4}"
                , a.Id, a.Name, a.Address, a.PhoneNumber, a.SSN, a.EmailAddress);
            Console.ReadLine();
            User b;
            b = Bank.CreateUser("ut", "redmond", 425123, 113,"meenus@gmail.com");
            Console.WriteLine("Id:{0},Name:{1},Address:{2},PhoneNumber:{3},SSN:{4}"
                , b.Id, b.Name, b.Address, b.PhoneNumber, b.SSN,b.EmailAddress);
            Console.ReadLine();
            var c = Bank.CreateAccount("Saving", 123456,a.Id);
            Console.WriteLine("Id:{0},Type:{1},Number:{2},UserId:{3}",
                c.Id,c.Type,c.Number,c.UserId);
            using (var db = new BankModel1())
            {
              var d = db.Accounts.FirstOrDefault();
              Console.WriteLine("Id:{0},Type:{1},Number:{2},UserId:{3}",
                    d.Id,d.Type,d.Number,d.UserId);
              Console.WriteLine("User:{0}",d.User.Name);
              Console.WriteLine("card:{0}",d.Card.Number);
              Console.ReadLine();
            }

            using (var db = new BankModel1())
            {
                var u = new User();
                Console.WriteLine("Enter your Name?");
                u.Name = Console.ReadLine();
                Console.WriteLine("Enter your Address");
                u.Address= Console.ReadLine();
                var a = new Account();
                Console.WriteLine("*****Menu*******");
                Console.WriteLine("1. Checking");
                Console.WriteLine("2. Saving");
                Console.WriteLine("Enter your choice");
                var choice = Console.ReadLine();
                if (choice == "1")
                  {
                    a.Type = "checking";
                  }  
                else if (choice =="2")
                 {
                    a.Type = "saving";
                 }
                Console.ReadLine();
                Console.WriteLine("Enter your PhoneNumber");
                var PhoneNumber = (Console.ReadLine());
                long convert;
                if(!long.TryParse(PhoneNumber,out convert))
                {
                    throw new ArgumentException("Invalid phone number");
                }
                Console.WriteLine("success");
                Console.WriteLine("Enter your EmailAddress");
                u.EmailAddress = Console.ReadLine();
                db.Users.Add(u);
                db.Accounts.Add(a);
                db.SaveChanges();
            }
            IEnumerable<Account> d;
                d = Bank.GetAllAccounts();

                foreach(var ab in d)
                {
                    Console.WriteLine("{0},{1},{2},{3}",ab.Id,ab.Type,ab.Number,ab.UserId);
                }

                IEnumerable<User> e;
                e = Bank.GetAllUsers();*/
            bool c = true;
            while (c)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1.Create User");
                Console.WriteLine("2.Open Account");
                Console.WriteLine("3.Exit");
                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        using (var db = new BankModel1())
                        {

                            User a = new User();
                            Console.Write("Enter Name: ");
                            a.Name = Console.ReadLine();
                            Console.Write("Enter Address: ");
                            a.Address = Console.ReadLine();
                            Console.WriteLine("Enter your Phonenumber");
                            string PhoneNumber = (Console.ReadLine());
                            long convert;
                            if (!long.TryParse(PhoneNumber, out convert))
                            {
                                throw new ArgumentException("invalid PhoneNumber");
                            }
                            Console.WriteLine("Enter your SSN");
                            string SSN = (Console.ReadLine());
                            int convert1;
                            if (!int.TryParse(SSN, out convert1))
                            {
                                throw new ArgumentException("invalid SSN");
                            }
                            Console.WriteLine("Enter your EmailAddress");
                            a.EmailAddress = Console.ReadLine();
                            IEnumerable<User> b;
                            b = Bank.GetAllUsers();
                            foreach (var ab in b)
                            {
                                Console.WriteLine("{0},{1},{2},{3},{4},{5}",
                                    ab.Id, ab.Name, ab.Address, ab.PhoneNumber, ab.SSN, ab.EmailAddress);
                            }
                            Console.ReadLine();
                            db.Users.Add(a);
                            db.SaveChanges();
                            Console.WriteLine("User Created!");

                        }
                        break;
                    case "2":
                        using (var db = new BankModel1())
                        {

                            var b = new Account();
                            Console.Write("Enter UserId: ");
                            b.UserId = int.Parse(Console.ReadLine());
                            Console.WriteLine("1.Checking");
                            Console.WriteLine("2.saving");
                            Console.Write("Enter type: ");
                            var choice1 = Console.ReadLine();
                            if (choice1 == "1")
                            {
                                b.Type = "checking";
                            }
                            else if (choice1 == "2")
                            {
                                b.Type = " saving";

                            }
                            var d = Bank.CreateAccount(b.Type, 12345, b.UserId);
                            IEnumerable<Account> e;
                            e = Bank.GetAllAccounts();
                            foreach (var ab in e)
                            {
                                Console.WriteLine("{0},{1},{2},{3}", ab.Id, ab.Type, ab.Number, ab.UserId);
                            }
                            Console.ReadLine();
                            db.SaveChanges();
                            Console.WriteLine("Account Created!");
                        }
                        break;
                    case "3":
                        c = false;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid Choice");
                }
            }
            Console.WriteLine("Exited");
        }
    }
}
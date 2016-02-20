namespace ATM
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BankModel1 : DbContext
    {
        // Your context has been configured to use a 'BankModel1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ATM.BankModel1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BankModel1' 
        // connection string in the application configuration file.
        public BankModel1()
            : base("name=BankModel1")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<User> Users { get; set; }
         public virtual DbSet<Account> Accounts { get; set; }
         public virtual DbSet<Card> Cards { get; set; }
         public virtual DbSet<Transaction> Transactions { get; set; }
    }


    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
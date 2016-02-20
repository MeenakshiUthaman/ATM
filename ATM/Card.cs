using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    /// <summary>
    /// Any debit or credit card.
    /// </summary>
    public class Card
    {
        #region field
        public static int LastNumber = 12345;
        #endregion
        #region Properties
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Type { get; set; }
        public int CVV { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual ICollection<Transaction> Transactions{ get; set; }
        public virtual Account Account { get; set; }
        #endregion
    }
}
